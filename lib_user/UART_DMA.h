/* ==================================================================================
File name:      USER_UART.H                                     
Originator:	    Robotechco &  Luffy D.Monkey 
Description: 	Declare defines and functions for UART1 for sending data to PC.
Target: 	    STM32F407
------------------------------------------------------------------------------------*/
#ifndef __USER_UART_H__
#define __USER_UART_H__

#include "stm32f4xx.h"


/* Exported functions ------------------------------------------------------- */
void UART1_DMA_CONFIG(uint8_t *TxAddr, uint8_t *RxAddr, uint8_t size, uint32_t baudrate);
void USART_config (void);
void DMA_TX(void);
void SENDDATA(float Value, uint8_t* TxAddr, uint8_t channel);

#endif  // __USER_UART_H__
