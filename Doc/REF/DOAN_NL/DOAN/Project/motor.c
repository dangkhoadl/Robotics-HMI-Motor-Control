#include "stm32f4xx.h"
#include "PWM.h"
#include "motor.h"
#include "Encoder.h"
#include "math.h"
#define MOTOR_EN		GPIO_Pin_8
#define MOTOR_DIR		GPIO_Pin_9
#define MOTOR_GPIO	GPIOC
#define MOTOR_RCC RCC_AHB1Periph_GPIOC
GPIO_InitTypeDef 	GPIO_InitMotor;
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
		SetDutyCycle(50);
		GPIO_ResetBits(MOTOR_GPIO, MOTOR_EN);
		GPIO_SetBits(MOTOR_GPIO, MOTOR_DIR);
}
//-----------------------------------------------------------------------------------------------------------------------------
void ONMotor(void)
{
		GPIO_SetBits(MOTOR_GPIO, MOTOR_EN);
}
//-----------------------------------------------------------------------------------------------------------------------------
void OFFMotor(void)
{
		GPIO_ResetBits(MOTOR_GPIO, MOTOR_EN);
}
//-----------------------------------------------------------------------------------------------------------------------------
void ToggleMotor(void)
{
		GPIO_ToggleBits(MOTOR_GPIO, MOTOR_EN);
}
//-----------------------------------------------------------------------------------------------------------------------------
void ChangeDIR(void)
{
		OFFMotor();
		GPIO_ToggleBits(MOTOR_GPIO, MOTOR_DIR);
}
//-----------------------------------------------------------------------------------------------------------------------------
void ChangeSpeed(uint32_t speed)
{
		SetDutyCycle(speed);
}

//-----------------------------------------------------------------------------------------------------------------------------


