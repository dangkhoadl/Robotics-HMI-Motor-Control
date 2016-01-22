#include "stm32f4xx.h"
#include "PWM.h"

GPIO_InitTypeDef GPIO_InitStructure;
TIM_TimeBaseInitTypeDef  TIM_TimeBaseStructure;
TIM_OCInitTypeDef  TIM_OCInitStructure;
TIM_ICInitTypeDef  TIM_ICInitStructure;
NVIC_InitTypeDef NVIC_InitStructure;

uint16_t IC2Value,DutyCycle,Frequency;
uint16_t f=5000,period=16800,pulse=8400;		//period=8400*10000/f

//--------------------------------------------------------------------------------------------------------------------------
/* Configure PWM mode */
void PWM_Config(void)
{
  /* TIM4 clock enable */
  RCC_APB1PeriphClockCmd(RCC_APB1Periph_TIM4, ENABLE);

  /* GPIO? clock enable */
  RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOD, ENABLE);
  
  /* GPIO? Configuration: */
  GPIO_InitStructure.GPIO_Pin = GPIO_Pin_12;
  GPIO_InitStructure.GPIO_Mode = GPIO_Mode_AF;
  GPIO_InitStructure.GPIO_Speed = GPIO_Speed_100MHz;
  GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;
  GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_NOPULL ;
  GPIO_Init(GPIOD, &GPIO_InitStructure); 
  
  /* Connect TIM? pins to AF */  
  GPIO_PinAFConfig(GPIOD, GPIO_PinSource12, GPIO_AF_TIM4); 
  
    /* Time base configuration */
  TIM_TimeBaseStructure.TIM_Period = period-1; //8400=>10k
  TIM_TimeBaseStructure.TIM_Prescaler = 0;
  TIM_TimeBaseStructure.TIM_ClockDivision = 0;
  TIM_TimeBaseStructure.TIM_CounterMode = TIM_CounterMode_Up;

  TIM_TimeBaseInit(TIM4, &TIM_TimeBaseStructure);
	
  /* PWM Mode configuration: Channel1 */
  TIM_OCInitStructure.TIM_OCMode = TIM_OCMode_PWM1;
  TIM_OCInitStructure.TIM_OutputState = ENABLE;
  TIM_OCInitStructure.TIM_Pulse = pulse-1;		//
  TIM_OCInitStructure.TIM_OCPolarity = TIM_OCPolarity_High;

  TIM_OC1Init(TIM4, &TIM_OCInitStructure);

  TIM_OC1PreloadConfig(TIM4, TIM_OCPreload_Enable);

  TIM_ARRPreloadConfig(TIM4, ENABLE);
	
	/* Configure enable TIM1 Update Interrupt */
  TIM_ITConfig(TIM4, TIM_IT_Update, ENABLE);
	
  /* Set up vector TIM1 update interrupt */
	NVIC_InitStructure.NVIC_IRQChannel = TIM4_IRQn;
	NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 1;
	NVIC_InitStructure.NVIC_IRQChannelSubPriority = 1;
	NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;
	NVIC_Init(&NVIC_InitStructure);

  /* TIM? enable counter */
  TIM_Cmd(TIM4, ENABLE);
}
//--------------------------------------------------------------------------------------------------------------------------
void PWMIN_Config(void)
{
  /* TIM5 configuration: PWM Input mode ------------------------
     The external signal is connected to TIM5 CH2 pin (PA.01), 
     The Rising edge is used as active edge,
     The TIM5 CCR2 is used to compute the frequency value 
     The TIM5 CCR1 is used to compute the duty cycle value
  ------------------------------------------------------------ */
  
  /* TIM5 & GPIOA clock enable */
  RCC_APB1PeriphClockCmd(RCC_APB1Periph_TIM5, ENABLE);
  RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOA, ENABLE);
  
  /* TIM4 chennel2 configuration : PA.01 */
  GPIO_InitStructure.GPIO_Pin   = GPIO_Pin_1;
  GPIO_InitStructure.GPIO_Mode  = GPIO_Mode_AF;
  GPIO_InitStructure.GPIO_Speed = GPIO_Speed_100MHz;
  GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;
  GPIO_InitStructure.GPIO_PuPd  = GPIO_PuPd_UP ;
  GPIO_Init(GPIOA, &GPIO_InitStructure);
  
  /* Connect TIM pin to AF2 */
  GPIO_PinAFConfig(GPIOA, GPIO_PinSource1, GPIO_AF_TIM5);
  
  /* TIM5 configuration: PWM Input mode */
  TIM_ICInitStructure.TIM_Channel = TIM_Channel_2;
  TIM_ICInitStructure.TIM_ICPolarity = TIM_ICPolarity_Rising;
  TIM_ICInitStructure.TIM_ICSelection = TIM_ICSelection_DirectTI;
  TIM_ICInitStructure.TIM_ICPrescaler = TIM_ICPSC_DIV1;
  TIM_ICInitStructure.TIM_ICFilter = 0x0;

  TIM_PWMIConfig(TIM5, &TIM_ICInitStructure);

  /* Select the TIM5 Input Trigger: TI2FP2 */
  TIM_SelectInputTrigger(TIM5, TIM_TS_TI2FP2);

  /* Select the slave Mode: Reset Mode */
  TIM_SelectSlaveMode(TIM5, TIM_SlaveMode_Reset);
  TIM_SelectMasterSlaveMode(TIM5,TIM_MasterSlaveMode_Enable);

  /* TIM enable counter */
  TIM_Cmd(TIM5, ENABLE);

  /* Enable the CC2 Interrupt Request */
  TIM_ITConfig(TIM5, TIM_IT_CC2, ENABLE);
  
  /* Enable the TIM5 global Interrupt */
  NVIC_InitStructure.NVIC_IRQChannel = TIM5_IRQn;
  NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 0;
  NVIC_InitStructure.NVIC_IRQChannelSubPriority = 1;
  NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;
  NVIC_Init(&NVIC_InitStructure);
}
//--------------------------------------------------------------------------------------------------------------------------
void TIM5_IRQHandler(void)
{
  /* Clear TIM5 Capture compare interrupt pending bit */
  TIM_ClearITPendingBit(TIM5, TIM_IT_CC2);

  /* Get the Input Capture value */
  IC2Value = TIM_GetCapture2(TIM5);
  /*-----------------------------------------------------------------
  Frequency = TIM5 counter clock / TIM5_CCR2 in Hz, 
  DutyCycle = (TIM5_CCR1*100)/(TI5_CCR2) in %.
  ------------------------------------------------------------------*/
  if (IC2Value != 0)
  {
    /* Duty cycle computation */
    DutyCycle = (TIM_GetCapture1(TIM5) * 100) / IC2Value;

    /* Frequency computation =  TIM5 Counter Clock / IC2Value*/
    Frequency = (84000000)/ (IC2Value);
  }
  else
  {
    DutyCycle = 0;
    Frequency = 0;
  }
}
//--------------------------------------------------------------------------------------------------------------------------
uint16_t GetFrequency(void)
{return Frequency;}
//--------------------------------------------------------------------------------------------------------------------------
uint16_t GetDutyCycle(void)
{return DutyCycle;}
//--------------------------------------------------------------------------------------------------------------------------
void SetDutyCycle(uint32_t Duty)
{	TIM_SetCompare1(TIM4,Duty*period/100);
	}
//--------------------------------------------------------------------------------------------------------------------------
