#include "main.h"

void BUT_Config (void);
void DIR_Config (void);
void TIM_Config(void);
void PWM_Config(void);
void ADC_Config(void);
void ENC_Config(void);
void UART2_Config(uint32_t baudrate);  //(TX:PA2) (RX:PA3)
void DMA_Config(uint8_t *buffer,uint8_t buffersize);
