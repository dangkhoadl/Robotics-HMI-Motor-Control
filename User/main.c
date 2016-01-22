/*****************************		DAMH1			*****************************************************

Encoder: 
					B: PA7(TIM 3-CH2)    A:PA6 (TIM 3-CH1)
******************************************************************************************************
PWM: 	          FW								RV
					PD12 (TIM4-CH1)		PD14(TIM4-CH3)
								
								Wiring: 	Motor 	- 	Driver							Driver  -  KIT STM								
													BLACK 		 	OUT A								INA			-		PD12
													RED  				OUT B								INB			-		PD14
******************************************************************************************************
UART: 
					TX:PB6	RX:PB7

											UART_channel														Frame
					Kp_sp						0		
					Ki_sp						1												[0xFF][0xF(channel)][Data][0xFE]
					Kd_sp						2
					speed_sp				3

					Kp_cf						0		
					Ki_cf						1
					Kd_cf						2												[0xFF][0xE(channel)][Data][0xFE]
					speed_cf				3													
					DutyCycle_fb		4
					speed_fb				5
******************************************************************************************************					
LCD config
			VCC: 5V LCD HD44780 16x2
			
			Control pin:
			
				EN <------ PC10
				RW <------ PC11
				RS <------ PC12		
				
			Data pin:
			
				D4 <------ PC0
				D5 <------ PC1
				D6 <------ PC2
				D7 <------ PC3
******************************************************************************************************/

#include "stm32f4xx.h"
#include "LED_userbutton.h"
#include "Encoder.h"
#include "PWM.h"
#include "UART_DMA.h"
#include "lcd.h"
#include "reprintf.h"
#include <stdio.h>
#include <math.h>
#include <string.h>

/************************Global variables ----------------------------------------------------------*/

uint16_t SysTicker = 0;

//Encoder section
int16_t temp1=0,temp2=0,diff=0;
float 
			speed_fb=0;
//		roundC=0;

//PWM section
uint16_t duty;

//PID1 section
float speed_sp=0,
			max_speed = 3800;

float P_part=0,I_part=0,D_part=0,		//PID1
			A0,A1,A2,											//PID2
			Kp=0,Ki=0,Kd=0,										
			e0=0,e1=0,e2=0,								// -1< Error_signal <1
			U0=0,U1=0,										// -1< Control_signal < 1
								U0_100;							// -100 < U0_ref < 100		
static float T= 1;							// sampling_interval (ms)

			
//UART_DMA section
	//Tx
	#define txsize 7
	uint8_t txbuffer[txsize];

	//RX
	#define rxsize 28 //4channel * 7 bytes
	uint8_t rxbuffer[rxsize];
	char temp;
	uint8_t rxindex=0,i;
	float rx_data;

//LCD section
	uint8_t LCD_mode=0;
/************************Subroutines_Prototype****************************/
void PID 	(uint16_t time);
void UART_TX (uint16_t time);
void LCD (uint16_t time);
//void Delay(uint32_t nCount);
/************************MAIN*********************************************/
int main(void)
{
	LED_config();
	User_button_config();
	lcd_Init();		
	ENC_Config();
	TIM_Config();
	PWM_Config();
	UART1_DMA_CONFIG(txbuffer,rxbuffer,7,56000);
	USART_config ();
	
	if (SysTick_Config(SystemCoreClock / 1000))
  {/* Capture error */ while (1);}

	while (1)
		{
			
		}
}

/************************Systick******************************************/
void SysTick_Handler(void)
{
	SysTicker ++;
	
	PID (1);
	UART_TX(200);
//	LCD(200);
}

uint16_t GetTicker(void)
{return SysTicker;}

/************************Interrupts****************************/
//UART RX
void USART1_IRQHandler(void)
{
	if(USART_GetITStatus(USART1, USART_IT_RXNE) != RESET)
	{
			/* Read 28 byte from the receive data register */
			temp = USART_ReceiveData(USART1);
			rxbuffer[rxindex] = temp;
			rxindex++;
			if (rxindex == rxsize) rxindex=0;
			for (i=0;i<=rxsize-6;i++)
			{
				if ((rxbuffer[i] == 0xFF) && (rxbuffer[i + 6] == 0xFE))
				{
					memcpy(&rx_data,&rxbuffer[i+2],4);
					switch (rxbuffer[i+1])
					{
						case 0xE0:Kp = rx_data;break;
						case 0xE1:Ki = rx_data;break;
						case 0xE2:Kd = rx_data;break;
						case 0xE3:speed_sp = rx_data;break;
					}
				}
			}
	}
}

// BUTTON PA0 EXTI_INT
	void EXTI0_IRQHandler(void)
{
  if(EXTI_GetITStatus(EXTI_Line0) != RESET)
  {
    if(GPIO_ReadInputDataBit(GPIOA, GPIO_Pin_0)==1)
		{
			LCD_mode = (!LCD_mode) && 0x01;											//toggle LCD 
		}
    /* Clear the EXTI line 0 pending bit */
    EXTI_ClearITPendingBit(EXTI_Line0);
  }
//		Delay(1680000);																			//Anti-bouncing Delay 40ms
}

/************************Subroutines****************************/
void PID (uint16_t time)
{
	static uint16_t ticker = 0;
	
	if ((uint16_t)(ticker+time)==GetTicker()) 
	{
		ticker = GetTicker();
			
		//Encoder section
		temp2 = temp1;
		temp1 = EncoderValue();
		diff = temp1 - temp2;
		
		if (diff> 10000) diff=(temp1-0xFFFF)+(temp2);//overflow while counting down
		if (diff<-10000) diff=(0xFFFF-temp2)+(temp1);//overflow while counting up
		
		speed_fb = diff*1000.0*60.0/1336.0;		// RPM = (pulse/1336/0.001s)*60 // encoder 334 pulses per round*4= 1336
		//roundC = (float)EncoderValue()/1336;
		
		if (speed_fb >=0) GPIO_ResetBits(GPIOD,GPIO_Pin_13);							// Reverse alarm = false
		else GPIO_SetBits(GPIOD,GPIO_Pin_13);															// Reverse alarm = true
		
		//PID1 section			
		P_part =  Kp* 		(e0 - 	e1);
		I_part =  Ki*T/2*	(e0 + 	e1);
		D_part = 	Kd/T*   (e0 - 2*e1 + e2);
		
		e2 = e1;
		e1 = e0;
		e0 = (speed_sp - speed_fb)/ (2*max_speed);
		if (e0<-1) {e0=-1;}
		if (e0>1)  {e0= 1;}
		
		U1 = U0;
		U0 = U0_100 / 100;
		U0 = U1 + P_part + I_part + D_part;
		
		
		//PID2 section
		/*A0 = Kp + Ki + Kd;
		A1 = (-Kp) - (2 * Kd);
		A2 = Kd;
		e2= e1;
		e1= e0;
		e0= (speed_sp - speed_fb) / max_speed;
		if (e0<-1) {e0=-1;}
		if (e0>1)	{e0=1;}
		
		U0 = U0_100 / 100;
		U0 = U0 + A0 * e0 + A1 * e1 + A2 * e2;*/

		//PWM section
		if (speed_fb*U0<0) U0=0;
		if (U0<-1) 				 U0=-1;
		if (U0>1)					 U0=1;
			
		if (U0>0)																					//Forward
		{
			duty = (uint16_t)(U0 *16800);
			//Reset PD14
			TIM_SetCompare3(TIM4,0);												
			GPIO_ResetBits(GPIOD,GPIO_Pin_14);
			//TIM_OC3PreloadConfig(TIM4, TIM_OCPreload_Disable);
			//set PWM PD12
			TIM_SetCompare1(TIM4,duty);
		}
				
		if (U0<0)																					//Reverse
		{
			duty = (uint16_t)(-U0 *16800);
			//Reset PD12
			TIM_SetCompare1(TIM4,0);
			GPIO_ResetBits(GPIOD,GPIO_Pin_12);
			//TIM_OC1PreloadConfig(TIM4, TIM_OCPreload_Disable);
			//set PWM PD14
			TIM_SetCompare3(TIM4,duty);
		}
	
		if (speed_sp == 0)																	//Stop
		{
			TIM_SetCompare1(TIM4,0);
			TIM_SetCompare3(TIM4,0);
			GPIO_ResetBits(GPIOD,GPIO_Pin_12);
			GPIO_ResetBits(GPIOD,GPIO_Pin_14);
			Kp=0,Ki=0,Kd=0;
		}
				
		U0_100 = U0 * 100; 
	}
}

void UART_TX (uint16_t time)
{
	static uint16_t ticker=0;
	if ((uint16_t)(ticker+time)==GetTicker()) 
	{
		ticker = GetTicker();
		
		SENDDATA(Kp,txbuffer, 0);
		SENDDATA(Ki,txbuffer,1);
		SENDDATA(Kd,txbuffer,2);
		SENDDATA(speed_sp,txbuffer,3);
		
		SENDDATA(U0_100,txbuffer,4);
		SENDDATA(speed_fb,txbuffer,5);
	}
}

void LCD (uint16_t time)
{
	if (LCD_mode == 0)
	{
		lcd_GotoXY(0,0);
		printf ("sp");
		lcd_GotoXY(1,0);
		printf ("fb");
	}
	else
	{
		
	}
}

/*void Delay(uint32_t nCount)
{
  while(nCount--);// tdelay (s)= (4/168000000) * nCount
}*/
