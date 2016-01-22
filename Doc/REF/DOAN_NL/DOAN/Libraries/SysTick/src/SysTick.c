#include "stm32f4xx.h"
#include "SysTick.h"

uint32_t sticker=0;

//----------------------------------------------------------------------------------------------------------------------------
uint32_t GetSticker(void)
{	return sticker;}
//----------------------------------------------------------------------------------------------------------------------------
void SysTick_Handler(void)
{
			sticker++;
}
//----------------------------------------------------------------------------------------------------------------------------
void Delay_ms(uint16_t nCount)
{
		uint16_t tdelay=sticker;
		while(sticker!=(uint16_t)tdelay+nCount);
}
