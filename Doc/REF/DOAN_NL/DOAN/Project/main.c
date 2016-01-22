/*LCD		EN <------ PC10	RW <------ PC11	RS <------ PC12		
				D4 <------ PC0	D5 <------ PC1
				D6 <------ PC2	D7 <------ PC3
	UART 	TX <------ PB10 RX <------ PB11                 1 0xf0 
																												2 0xf1
																												3 0xf2
																												4 0xf3
	ENCODER A<------ PA6  B	 <------ PA7						TIM3					
	PWM		PWMIN<---- PA1  PWMOUT<--- PD12						TIM4 TIM5
	MOTOR EN<------- PC8  DIR<------ PC9
*/
#include "stm32f4xx.h"
#include "math.h"
#include "stdio.h"
#include "string.h"
#include "lcd.h"
#include "UART.h"
#include "SysTick.h"
#include "Encoder.h"
#include "PWM.h"

#define graph_sample_time 100     //			ms
#define PID_sample_time		1			//			ms
#define maxspeed 2909
#define MAX_ENCODER 0xffff
#define rxsize 21
uint8_t rxbuffer[rxsize]={0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
uint8_t rxindex=0;
#define MOTOR_EN		GPIO_Pin_8
#define MOTOR_DIR		GPIO_Pin_9
#define MOTOR_GPIO	GPIOC
#define MOTOR_RCC RCC_AHB1Periph_GPIOC
GPIO_InitTypeDef 	GPIO_InitMotor;
//--------------------------------------------------------------------------------------------------------------------------

float Kp=0.75,Ki=0.25,Kd=0.2,A0,A1,A2;
int ON_OFF;
int32_t enc_value=0,enc_old_value=0,enc_diff=0;
float speed=0,sPID,setspeed,setspeed_old;
int32_t encPID_old_value=0,encPID_value=0,encPID_diff=0;
float Err[3]={0,0,0},Out=0;
float speedPID=0;
int counter=0;

//--------------------------------------------------------------------------------------------------------------------------
void DOINGTASK1(void);void TASK1(uint32_t time);                            //Gui Speed UART
void DOINGTASK2(void);void TASK2(uint32_t time);														//PID
void DOINGTASK3(void);void TASK3(uint32_t time);														//Tat dong co
void Motor_Speed_PID(uint32_t setspeed);
void TASK_RECEIVE_UART(void);
float SaveData(int i,int k);
void ONMotor(void);
void OFFMotor(void);
void ChangeDIR(void);
void ChangePWM(uint32_t speed);
void Resetmotor(void);
void Motor_Config(void);
//--------------------------------------------------------------------------------------------------------------------------
float SaveData(int i,int k)
{
	float temp;
	memcpy(&temp,&rxbuffer[i],4);
	return temp;
}
//--------------------------------------------------------------------------------------------------------------------------
int main(void)
{
	/* initialize LCD */
	//lcd_Init();		
	/* initialize UART */
	UART3_CONFIG(56000);
	/* initialize Motor */
	PWMIN_Config();
	Motor_Config();
	Resetmotor();
	OFFMotor();
	/* initialize Encoder */	
  ENC_Config(MAX_ENCODER);
	/* initialize SysTick */
 	if(SysTick_Config(SystemCoreClock / 1000)) {while(1);}
	while (1)
		{	
				TASK1(graph_sample_time);
				TASK3(3000);
		}
}
//--------------------------------------------------------------------------------------------------------------------------
void TASK1(uint32_t time)
{
		static uint32_t timetask1 = 0;
		if ((uint32_t)(timetask1+time)<=GetSticker()) 
		{
				timetask1 = GetSticker();
				DOINGTASK1();
		}
}
void DOINGTASK1(void)
{
	enc_old_value=enc_value;
	enc_value=EncoderValue();
	enc_diff=enc_value - enc_old_value;		
	if (enc_diff<=-MAX_ENCODER/2) enc_diff += MAX_ENCODER; 
	else if (enc_diff>=MAX_ENCODER/2) enc_diff -= MAX_ENCODER; 
	speed=enc_diff*(60000/graph_sample_time)/800;
	SENDFLOAT_UART(speed,0xf0);
	SENDFLOAT_UART(Out*1000,0xf1);
	SENDFLOAT_UART(setspeed,0xf2);
}
//--------------------------------------------------------------------------------------------------------------------------
void TASK2(uint32_t time)
{
		static uint32_t timetask2 = 0;
		if ((uint32_t)(timetask2+time)<=GetSticker()) 
		{
				timetask2 = GetSticker();
				DOINGTASK2();
		}
}
void DOINGTASK2(void)
{
}
//--------------------------------------------------------------------------------------------------------------------------
void TASK3(uint32_t time)
{
		static uint32_t timetask3 = 0;
		if ((uint32_t)(timetask3+time)<=GetSticker()) 
		{
				timetask3 = GetSticker();
				DOINGTASK3();
		}
}
void DOINGTASK3(void)
{
		if (ON_OFF==1)
			{
					setspeed+= 200;
					if (setspeed>=3000) setspeed=0;
				}
}
//--------------------------------------------------------------------------------------------------------------------------
void USART3_IRQHandler(void)
{
	char temp;
	if(USART_GetITStatus(USART3, USART_IT_RXNE) != RESET)
	{
		/* Read one byte from the receive data register */
		temp = USART_ReceiveData(USART3);
		rxbuffer[rxindex] = temp;
		rxindex++;
		if (rxindex==rxsize) {rxindex=0;}
		TASK_RECEIVE_UART();
	}
}

//--------------------------------------------------------------------------------------------------------------------------
void TASK_RECEIVE_UART(void)
{
	int i,j;
	for(i=0;i<=rxindex-6;i++)
	{
		if (rxbuffer[i]==0xFF)
		{ 	if (rxbuffer[i+6]==0xFE)
				{
					switch (rxbuffer[i+1])
					{		case 0xE0: OFFMotor();break;
							case 0xE1: ONMotor();break;
							case 0xEA: Kp=SaveData(i+2,4);break;
							case 0xEB: Ki=SaveData(i+2,4);break;
							case 0xEC: Kd=SaveData(i+2,4);break;
							case 0xED: setspeed=SaveData(i+2,4);
												 setspeed_old=setspeed;
												 //ChangePWM(setspeed);
												 break;
					}
					for(j=0;j<=rxsize;j++) rxbuffer[j]=0;
					rxindex=0;
				}			
		}
	}
}
//-----------------------------------------------------------------------------------------------------------------------------
void Motor_Config(void)
{
		/* initialize PWM */
		PWM_Config();
	
		RCC_AHB1PeriphClockCmd(MOTOR_RCC, ENABLE);
		//GPIO Configuration
		GPIO_InitMotor.GPIO_Pin = MOTOR_EN | MOTOR_DIR;
		GPIO_InitMotor.GPIO_Mode = GPIO_Mode_OUT;
		GPIO_InitMotor.GPIO_OType = GPIO_OType_PP;
		GPIO_InitMotor.GPIO_PuPd = GPIO_PuPd_DOWN;
		GPIO_InitMotor.GPIO_Speed = GPIO_Speed_100MHz;
		GPIO_Init(MOTOR_GPIO, &GPIO_InitMotor);
}
//-----------------------------------------------------------------------------------------------------------------------------
void Resetmotor(void)
{		
		SetDutyCycle(0);
		OFFMotor();
		GPIO_SetBits(MOTOR_GPIO, MOTOR_DIR);
}
//-----------------------------------------------------------------------------------------------------------------------------
void ONMotor(void)
{
		setspeed=setspeed_old;
		GPIO_SetBits(MOTOR_GPIO, MOTOR_EN);
		ON_OFF=1;
}
//-----------------------------------------------------------------------------------------------------------------------------
void OFFMotor(void)
{
		GPIO_ResetBits(MOTOR_GPIO, MOTOR_EN);
		setspeed_old=setspeed;setspeed=0;
		Err[0]=0;Err[1]=0;Err[2]=0;Out=0;
		ON_OFF=0;
}
//-----------------------------------------------------------------------------------------------------------------------------
void ChangeDIR(void)
{
		OFFMotor();
		GPIO_ToggleBits(MOTOR_GPIO, MOTOR_DIR);
}
//-----------------------------------------------------------------------------------------------------------------------------
void ChangePWM(uint32_t speed)
{
		SetDutyCycle(speed);
}
//-----------------------------------------------------------------------------------------------------------------------------
void TIM4_IRQHandler(void)
{
	TIM_ClearITPendingBit(TIM4, TIM_IT_Update );
	counter++;
	if (counter>=5)
	{ 	if (ON_OFF==1) Motor_Speed_PID(setspeed);
			counter=0;
	}
}
//--------------------------------------------------------------------------------------------------------------------------
void Motor_Speed_PID(uint32_t setspeed)
{
		A0= Kp + Ki + Kd;
		A1 = (-Kp ) - (2 * Kd );
    A2 = Kd;  
		// tinh so xung trong thoi gian lay mau
		encPID_old_value=encPID_value;
		encPID_value=EncoderValue();
		encPID_diff=encPID_value - encPID_old_value;				
		if (encPID_diff<=-MAX_ENCODER/2) encPID_diff += MAX_ENCODER; 
		else if (encPID_diff>=MAX_ENCODER/2) encPID_diff -= MAX_ENCODER; 
		speedPID=encPID_diff*(60000/PID_sample_time)/800;
		// tinh sai so
		Err[2]=Err[1];
		Err[1]=Err[0];
		Err[0]= (setspeed - fabs(speedPID))/(maxspeed);				
		//********* khau PID*****************//
		Out=Out+A0*Err[0]+A1*Err[1]+A2*Err[2];
		//***********************************//
		if(Out>=1) Out = 1;
		if(Out<=0)	Out = 0;
		ChangePWM((uint32_t)(Out*100));	
}
//--------------------------------------------------------------------------------------------------------------------------
