#include "main.h"
#include <stdio.h>
#include <string.h>
#include <math.h>
#include "stm_init.h"
#include "lcd.h"

/* -----------------------------VAT's note -------------------------------------
	ADC Input: PA1
	PWM&DIR Output: E1->(PD12-PD15) M1->PD11
	Encoder Input: ChA->PA6 ChB->PA7
	UART: TX->PA2 RX->PA3
	LCD:
		(D4-D7)->(PC0-PC3)
		EN->PC10
		R/W->PC11
		RS->PC12
	Buttons: 	(B1,B2,B3)->(PE10-PE12-PE14)
						(B4,B5,B6)->(PE11-PE13-PE15)
------------------------------------------------------------------------------*/

/* Private variable ----------------------------------------------------------*/
uint16_t SysTicker=0,UART_tick=0,LCD_tick=0;
uint16_t ADCValue=0;
uint16_t duty=0;
uint16_t enc_value=0,enc_old_value=0;
int16_t enc_diff=0;
float fbk_speed=0,null=0;
float set_speed=0,set_speed_max=2850,set_speed_min=-2850,set_speed_adjust=150;
float Kp=1.5,Kp_max=5,Kp_min=0,Kp_adjust=0.2;
float Ki=0.5,Ki_max=2,Ki_min=0,Ki_adjust=0.1;
float Kd=0.4,Kd_max=2,Kd_min=0,Kd_adjust=0.1;
float duty_cycle=0;
float edit_temp=0,set_speed_old=0;
float e=0,e1=0,e2=0;	//e[n],e[n-1],e[n-2]
float A0,A1,A2;
float speed_factor=3000;
float speed_step[13]={0,1000,2,2500,4,1000,6,-1000,8,-2500,10,-1000,12};
float fbk_pos=0,dec=300;
float set_pos=0,set_pos_max=1000,set_pos_min=-1000,set_pos_adjust=50;
float start_spd=150,start_spd_max=300,start_spd_min=75,start_spd_adjust=75;
float top_spd=1650,top_spd_max=2850,top_spd_min=150,top_spd_adjust=150;
float acc=300,acc_max=600,acc_min=150,acc_adjust=75;
float dir_factor=1,dis_brake=0.6;
float ctrl_mode=1;
float t_acc,t_dec,t_top,dis_acc,dis_dec,dis_top;
float elapsed_time=0;
uint8_t run_state=4,state_next=0;

#include "menu.h"
item *first_line, *second_line;
menu current_menu;
menu_edit current_menu_edit;
uint8_t item_index,first_line_index,second_line_index;
uint8_t lcd_command;

#define rxsize 7
#define dmasize 70
uint8_t* txdata;
uint8_t rxbuffer[rxsize];
float rxdata;
uint8_t dmabuffer[dmasize];
uint8_t dma_index=0;
uint8_t fb_request=0;

/* Private function prototypes -----------------------------------------------*/
void TASK1(uint16_t time);	//PID Control
void TASK2(uint16_t time);	//UART Feedback
void TASK3(uint16_t time);	//LCD Refresh
void TASK4(uint16_t time);	//Auto Setspeed
void TASK5(uint16_t time);	//Trapezoid Interpolation
void DMA_Buffer (float data, uint8_t channel);
void DMA_Send (void);

void start_menu (void);
void scroll_down (void);
void scroll_up (void);
void menu_enter (void);
void menu_back (void);
void call_menu (uint8_t first_index,uint8_t second_index);
void call_menu_edit (void);
void value_down (void);
void value_up (void);
void lcd_refresh (void);
	
int main (void)
{
	TIM_Config();
	PWM_Config();
	DIR_Config();
	ENC_Config();
	BUT_Config();
	/* Reset encoder */
	enc_value=0;
	enc_old_value=0;
	enc_diff=0;
	UART2_Config(56000);
	USART_DMACmd(USART2, USART_DMAReq_Tx, ENABLE);	
	start_menu();
	
	if (SysTick_Config(SystemCoreClock / 1000))
  {/* Capture error */ while (1);}
	NVIC_SetPriority (SysTick_IRQn,0);
	
	while (1)
  {
		TASK3(200);
	}
}

void SysTick_Handler(void)
{
	SysTicker++;
	LCD_tick++;
	TASK1(1);
	TASK5(50);
	TASK2(50);
}

uint16_t GetTicker(void)
{return SysTicker;}

void TASK1(uint16_t time)
{
	static uint16_t ticker=0;
	if ((uint16_t)(ticker+time)==GetTicker()) 
	{
		ticker = GetTicker();
		//Read encoder
		enc_old_value=enc_value;
		enc_value=TIM_GetCounter (TIM3);
		enc_diff=enc_value-enc_old_value;
		if (enc_diff>10000)	//overflow while counting down
		{enc_diff=(enc_value-0xFFFF)+(enc_old_value);}
		if (enc_diff<-10000)	//overflow while counting up
		{enc_diff=(0xFFFF-enc_old_value)+(enc_value);}
		fbk_speed=enc_diff*1000*60/800.0;
		//PID Speed Control
		A0 = Kp + Ki + Kd;
    A1 = (-Kp) - (2 * Kd);
    A2 = Kd;
		e2= e1;
		e1= e;
		e= (set_speed - fbk_speed) / (2*speed_factor);
			if (e<-1)
			{e=-1;}
			if (e>1)
			{e=1;}
		duty_cycle = duty_cycle / 100;
		duty_cycle = duty_cycle + A0 * e + A1 * e1 + A2 * e2;
			if (fbk_speed*duty_cycle<0)
			{
				duty_cycle=0;
				duty=0;
			}
			if (duty_cycle<-1)
			{duty_cycle=-1;}
			if (duty_cycle>1)
			{duty_cycle=1;}
			if (duty_cycle<0)
			{
				GPIO_ResetBits(GPIOD,GPIO_Pin_11);
				duty = (uint16_t)(-duty_cycle *16800);
			}
			if (duty_cycle>0)
			{
				GPIO_SetBits(GPIOD,GPIO_Pin_11);
				duty = (uint16_t)(duty_cycle *16800);
			}
			if ((set_speed==0)&(fbk_speed==0))
			{
				duty_cycle=0;
				duty=0;
			}
		duty_cycle = duty_cycle * 100;
		TIM_SetCompare1(TIM4,duty);
		TIM_SetCompare2(TIM4,duty);
		TIM_SetCompare3(TIM4,duty);
		TIM_SetCompare4(TIM4,duty);
		//Position Control
		if (ctrl_mode==2)
		{
			dir_factor=set_pos/fabs(set_pos);
			fbk_pos+=enc_diff/800.0;
			if ((run_state==2)&((dir_factor*fbk_pos)>=(dis_acc+dis_top)))
			{run_state=3;}
			if ((dir_factor*fbk_pos)>=(dir_factor*(set_pos-dir_factor*dis_brake)))
			{
				run_state=4;
				set_speed=0;
			}
			if (run_state!=4)
			{elapsed_time++;}
		}		
	}
}

void TASK5(uint16_t time)
{
	static uint16_t ticker=0;
	if ((uint16_t)(ticker+time)==GetTicker()) 
	{
		ticker = GetTicker();
		if (ctrl_mode==2)
		{
			if (run_state==0)
			{
				t_acc=(top_spd-start_spd)/(acc*60000/time);
				t_dec=(top_spd-start_spd)/(dec*60000/time);
				dis_acc=start_spd*t_acc+0.5*(acc*60000/time)*t_acc*t_acc;
				dis_dec=start_spd*t_dec+0.5*(dec*60000/time)*t_dec*t_dec;
				dis_top=dir_factor*set_pos-dis_acc-dis_dec;
				t_top=dis_top/top_spd;
				set_speed=dir_factor*start_spd;
				fbk_pos=0;
				state_next=1;
			}
			if (run_state==1)
			{
				set_speed+=dir_factor*acc;
				if ((dir_factor*set_speed)>=top_spd)
				{
					set_speed=dir_factor*top_spd;
					state_next=1;
				}
			}
			if (run_state==3)
			{
				set_speed-=dir_factor*dec;
				if ((dir_factor*set_speed)<=start_spd)
				{set_speed=dir_factor*start_spd;}
			}
			if (state_next==1)
			{
				state_next=0;
				run_state++;
			}
		}
	}
}

void TASK2(uint16_t time)
{
	static uint16_t ticker=0;
	if ((uint16_t)(ticker+time)==GetTicker())
	{
		ticker = GetTicker();
		//Send monitoring data
		DMA_Buffer(set_speed,0);
		DMA_Buffer(fbk_speed,1);
		if (ctrl_mode==1)
		{DMA_Buffer(duty_cycle,2);}
		if (ctrl_mode==2)
		{
			DMA_Buffer(fbk_pos,2);
			DMA_Buffer(elapsed_time,9);
		}
		//Send confirmation for parameters change
		if (fb_request==1)
		{
			DMA_Buffer(set_speed,3);
			DMA_Buffer(Kp,4);
			DMA_Buffer(Ki,5);
			DMA_Buffer(Kd,6);
			fb_request=0;
		}
		if (fb_request==2)
		{
			DMA_Buffer(set_pos,3);
			DMA_Buffer(start_spd,4);
			DMA_Buffer(top_spd,5);
			DMA_Buffer(acc,6);
			DMA_Buffer(dec,7);
			fb_request=0;
		}
		if (fb_request==3)
		{
			DMA_Buffer(ctrl_mode,8);
			fb_request=0;
		}
		DMA_Send();
	}
}

void TASK3(uint16_t time)
{
// 	static uint16_t ticker=0;
// 	if (((uint16_t)(ticker+time)<=GetTicker())|(time<=GetTicker()))
	if (LCD_tick>=time)
	{
// 		ticker = GetTicker();
		LCD_tick=0;
		switch (lcd_command)
		{ case 0:
				lcd_refresh();
				break;
			case 1:
				switch ((int)(ctrl_mode))
				{	case 1:
						ctrl_mode=2;
						current_menu=position_menu;
						call_menu(0,1);
						fb_request=3;
						break;
					case 2:
						ctrl_mode=1;
						current_menu=speed_menu;
						call_menu(0,1);
						fb_request=3;
						break;}
				lcd_command=0;
				break;
			case 2:
				switch ((int)(ctrl_mode))
				{	case 1:
						switch (set_speed==0)
						{	case 0:
								set_speed_old=set_speed;
								set_speed=0;
								fb_request=1;
								break;
							case 1:
								set_speed=set_speed_old;
								fb_request=1;
								break;}
						break;
					case 2:
						run_state=0;
						fbk_pos=0;
						elapsed_time=0;
						break;}
				lcd_command=0;
				break;
			case 3:
				menu_back();
				lcd_command=0;
				break;
			case 4:
				if (((*first_line).parent_id==0)|((*first_line).parent_id==2))
				{scroll_up();}
				if (((*first_line).parent_id==1)|((*first_line).parent_id==3))
				{value_up();}
				lcd_command=0;
				break;
			case 5:
				if (((*first_line).parent_id==0)|((*first_line).parent_id==2))
				{scroll_down();}
				if (((*first_line).parent_id==1)|((*first_line).parent_id==3))
				{value_down();}
				lcd_command=0;
				break;
			case 6:
				menu_enter();
				lcd_command=0;
				break;
			case 7:
				switch ((int)(ctrl_mode))
				{	case 2:
						current_menu=position_menu;
						call_menu(0,1);
						break;
					case 1:
						current_menu=speed_menu;
						call_menu(0,1);
						break;}
				lcd_command=0;
				break;}
	}
}

void TASK4(uint16_t time)
{
	static uint16_t ticker=0,i=0;
	static float time_index=0;
	if ((uint16_t)(ticker+time)==GetTicker()) 
	{
		ticker = GetTicker();
		if (time_index==speed_step[i])
		{
			set_speed=speed_step[i+1];
			i+=2;
		}
		time_index+=1;
		if (time_index==speed_step[sizeof(speed_step)/4-1])
			{
				time_index=0;
				i=0;
			}
	}
}

void DMA_Buffer (float data, uint8_t channel)
{
	dmabuffer[dma_index]=0xFF;
	dmabuffer[dma_index+6]=0xFE;
	dmabuffer[dma_index+1]=0xF0+channel;
	txdata=(uint8_t*)&data;
	memcpy(&dmabuffer[dma_index+2],&txdata[0],4);
	dma_index+=7;
}

void DMA_Send (void)
{
	DMA_Config(dmabuffer,dma_index);
  DMA_Cmd(DMA1_Stream6, ENABLE);
	dma_index=0;
}

void USART2_IRQHandler(void)
{
	if(USART_GetITStatus(USART2, USART_IT_RXNE) != RESET)
	{
		/* Read one byte from the receive data register */
		int8_t i=0;
		for (i=0;i<rxsize;i++)
		{rxbuffer[i]=rxbuffer[i+1];}
		rxbuffer[rxsize-1]=USART_ReceiveData(USART2);
		i=0;
// 		for (i=0;i<rxsize-6;i++)
// 		{
			if ((rxbuffer[i]==0xFF)&(rxbuffer[i+6]==0xFE))
			{
				memcpy(&rxdata,&rxbuffer[i+2],4);
				switch (rxbuffer[i+1])
				{ case 0xE0:
						ctrl_mode=rxdata;
						lcd_command=7;
						fb_request=3;
						break;
					case 0xEA:
						set_speed=rxdata;
						fb_request=1;
						break;
					case 0xEB:
						Kp=rxdata;
						fb_request=1;
						break;
					case 0xEC:
						Ki=rxdata;
						fb_request=1;
						break;
					case 0xED:
						Kd=rxdata;
						fb_request=1;
						break;
					case 0xE1:
						set_pos=rxdata;
						fb_request=2;
						break;
					case 0xE2:
						start_spd=rxdata;
						fb_request=2;
						break;
					case 0xE3:
						top_spd=rxdata;
						fb_request=2;
						break;
					case 0xE4:
						acc=rxdata;
						fb_request=2;
						break;
					case 0xE5:
						dec=rxdata;
						fb_request=2;
						break;
					case 0xE6:
						run_state=0;
						fbk_pos=0;
						elapsed_time=0;
						//fb_request=2;
						break;}
			}
// 		}
	}
}

void EXTI15_10_IRQHandler(void)
{
  if(EXTI_GetITStatus(EXTI_Line10) != RESET)	//B1
  {
    /* User Code */
		lcd_command=1;
    /* Clear the EXTI line 10 pending bit */
    EXTI_ClearITPendingBit(EXTI_Line10);
  }
	if(EXTI_GetITStatus(EXTI_Line11) != RESET)	//B4
  {
    /* User Code */
		lcd_command=4;
    /* Clear the EXTI line 11 pending bit */
    EXTI_ClearITPendingBit(EXTI_Line11);
  }
	if(EXTI_GetITStatus(EXTI_Line12) != RESET)	//B2
  {
    /* User Code */
		lcd_command=2;
    /* Clear the EXTI line 12 pending bit */
    EXTI_ClearITPendingBit(EXTI_Line12);
  }
	if(EXTI_GetITStatus(EXTI_Line13) != RESET)	//B5
  {
    /* User Code */
		lcd_command=5;
    /* Clear the EXTI line 13 pending bit */
    EXTI_ClearITPendingBit(EXTI_Line13);
  }
	if(EXTI_GetITStatus(EXTI_Line14) != RESET)	//B3
  {
    /* User Code */
		lcd_command=3;
    /* Clear the EXTI line 14 pending bit */
    EXTI_ClearITPendingBit(EXTI_Line14);
  }
	if(EXTI_GetITStatus(EXTI_Line15) != RESET)	//B6
  {
    /* User Code */
		lcd_command=6;
    /* Clear the EXTI line 15 pending bit */
    EXTI_ClearITPendingBit(EXTI_Line15);
  }
}

void start_menu (void)
{
	lcd_Init();
	current_menu=speed_menu;
	call_menu(0,1);
}

void scroll_down (void)
{
		item_index++;
		if (item_index==current_menu.num_items)
		{
			item_index=0;
			first_line_index=0;
			second_line_index=1;
		}
		else if (item_index==(current_menu.num_items-1))
		{
			first_line_index=item_index;
			second_line_index=0;
		}
		else
		{
			first_line_index=item_index;
			second_line_index=item_index+1;
		}
		call_menu(first_line_index,second_line_index);
}

void scroll_up (void)
{
		if (item_index==0)
		{
			item_index=current_menu.num_items-1;
			first_line_index=item_index;
			second_line_index=0;
		}
		else
		{
			item_index--;
			first_line_index=item_index;
			second_line_index=item_index+1;
		}
		call_menu(first_line_index,second_line_index);
}

void menu_enter (void)
{
		//Speed Edit Menus
		if ((strncmp((*first_line).label,"Set Spd: ",16)==0)&((*first_line).parent_id==0))
		{
			current_menu_edit=edit_set_spd;
			call_menu_edit();
		}
		if ((strncmp((*first_line).label,"Kp: ",16)==0)&((*first_line).parent_id==0))
		{
			current_menu_edit=edit_Kp;
			call_menu_edit();
		}
		if ((strncmp((*first_line).label,"Ki: ",16)==0)&((*first_line).parent_id==0))
		{
			current_menu_edit=edit_Ki;
			call_menu_edit();
		}
		if ((strncmp((*first_line).label,"Kd: ",16)==0)&((*first_line).parent_id==0))
		{
			current_menu_edit=edit_Kd;
			call_menu_edit();
		}
		//Position Edit Menus
		if ((strncmp((*first_line).label,"Set Pos: ",16)==0)&((*first_line).parent_id==2))
		{
			current_menu_edit=edit_set_pos;
			call_menu_edit();
		}
		if ((strncmp((*first_line).label,"StartSpd: ",16)==0)&((*first_line).parent_id==2))
		{
			current_menu_edit=edit_start_spd;
			call_menu_edit();
		}
		if ((strncmp((*first_line).label,"Top Spd: ",16)==0)&((*first_line).parent_id==2))
		{
			current_menu_edit=edit_top_spd;
			call_menu_edit();
		}
		if ((strncmp((*first_line).label,"Acc/Dec: ",16)==0)&((*first_line).parent_id==2))
		{
			current_menu_edit=edit_acc_dec;
			call_menu_edit();
		}
}

void menu_back (void)
{
	switch ((*first_line).parent_id)
	{	case 1:
			current_menu=speed_menu;
			fb_request=1;
			break;
		case 3:
			current_menu=position_menu;
			if (strncmp((*first_line).label,"Acc/Dec: ",16)==0)
			{dec=edit_temp;}
			fb_request=2;
			break;}
	if (((*first_line).parent_id==1)|((*first_line).parent_id==3))
	{
		*((*first_line).data)=edit_temp;
		lcd_Clear();
		first_line=current_menu.item[item_index];
		if (item_index==(current_menu.num_items-1))
		{second_line=current_menu.item[0];}
		lcd_GotoXY(0,0);
		printf((*first_line).label);
		if ((*first_line).withdata==1)
		{printf("%4.3f",*((*first_line).data));}
		lcd_GotoXY(1,0);	
		printf((*second_line).label);
		if ((*second_line).withdata==1)
		{printf("%4.3f",*((*second_line).data));}
	}
}

void call_menu (uint8_t first_index,uint8_t second_index)
{
	lcd_Clear();
	item_index=first_index;
	first_line=current_menu.item[first_index];
	second_line=current_menu.item[second_index];
	lcd_GotoXY(0,0);
	printf((*first_line).label);
	if ((*first_line).withdata==1)
	{printf("%4.3f",*((*first_line).data));}
	lcd_GotoXY(1,0);	
	printf((*second_line).label);
	if ((*second_line).withdata==1)
	{printf("%4.3f",*((*second_line).data));}
}

void call_menu_edit (void)
{
	lcd_Clear();
	first_line=current_menu_edit.item[0];
	edit_temp=*((*first_line).data);
	lcd_GotoXY(0,0);
	printf((*first_line).label);
	printf("%4.3f",*((*first_line).data));
}

void value_down (void)
{
	edit_temp-=*((*first_line).data_adjust);;
	if (edit_temp<*((*first_line).data_min))
	{edit_temp=*((*first_line).data_min);}
	lcd_Clear();
	lcd_GotoXY(0,0);
	printf((*first_line).label);
	printf("%4.3f",edit_temp);
}

void value_up (void)
{
	edit_temp+=*((*first_line).data_adjust);
	if (edit_temp>*((*first_line).data_max))
	{edit_temp=*((*first_line).data_max);}
	lcd_Clear();
	lcd_GotoXY(0,0);
	printf((*first_line).label);
	printf("%4.3f",edit_temp);
}

void lcd_refresh (void)
{
	if (((*first_line).parent_id==0)|((*first_line).parent_id==2))
	{
		if ((*first_line).withdata==1)
		{
			lcd_GotoXY(0,strlen((*first_line).label));
			printf("%4.3f",*((*first_line).data));
		}
		if ((*second_line).withdata==1)
		{
			lcd_GotoXY(1,strlen((*second_line).label));
			printf("%4.3f",*((*second_line).data));
		}
	}
}
