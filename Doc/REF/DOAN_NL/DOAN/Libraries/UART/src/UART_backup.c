#include "stm32f4xx.h"
#include "UART.h"

#define rxsize 30
uint8_t rxbuffer[rxsize]={0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
uint8_t rxindex=0;
int FLAGRECEIVE=0;
int BITRECEIVE=0;
int BUFFEROVERFLOW=0;
uint8_t buffer1[7]={0xff,0xf0,0x71,0x0f,0x77,0x3e,0xfe};
//---------------------------------------------------------------------------------------------------------------------
void UART3_CONFIG(uint32_t baudrate)  //(TX:PB10) (RX:PB11)
{
  GPIO_InitTypeDef 	GPIO_InitStructure;
  USART_InitTypeDef USART_InitStructure;
	NVIC_InitTypeDef	NVIC_InitStructure;
  
  //System Clocks Configuration
  RCC_APB1PeriphClockCmd(RCC_APB1Periph_USART3, ENABLE);
  RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOB, ENABLE);
  
  //GPIO Configuration
  GPIO_InitStructure.GPIO_Pin = GPIO_Pin_10 | GPIO_Pin_11;
  GPIO_InitStructure.GPIO_Mode = GPIO_Mode_AF;
  GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;
  GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_NOPULL;
  GPIO_InitStructure.GPIO_Speed = GPIO_Speed_100MHz;
  GPIO_Init(GPIOB, &GPIO_InitStructure);
 
  //Connect USART pins to AF
  GPIO_PinAFConfig(GPIOB, GPIO_PinSource10, GPIO_AF_USART3);
  GPIO_PinAFConfig(GPIOB, GPIO_PinSource11, GPIO_AF_USART3);

  /* USARTx configuration ------------------------------------------------------*/
  /* USARTx configured as follow:
        - BaudRate
        - Word Length = 8 Bits
        - One Stop Bit
        - No parity
        - Hardware flow control disabled (RTS and CTS signals)
        - Receive and transmit enabled
  */
  USART_InitStructure.USART_BaudRate = baudrate;
  USART_InitStructure.USART_WordLength = USART_WordLength_8b;
  USART_InitStructure.USART_StopBits = USART_StopBits_1;
  USART_InitStructure.USART_Parity = USART_Parity_No;
  USART_InitStructure.USART_HardwareFlowControl = USART_HardwareFlowControl_None;
  USART_InitStructure.USART_Mode = USART_Mode_Rx | USART_Mode_Tx;
  USART_Init(USART3, &USART_InitStructure);
 
	/* NVIC configuration */
  /* Configure the Priority Group to 2 bits */
  NVIC_PriorityGroupConfig(NVIC_PriorityGroup_2);
  
  /* Enable the USARTx Interrupt */
  NVIC_InitStructure.NVIC_IRQChannel = USART3_IRQn;
  NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 0;
  NVIC_InitStructure.NVIC_IRQChannelSubPriority = 0;
  NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;
  NVIC_Init(&NVIC_InitStructure);
 
  /* Enable the Receive interrupt */
  USART_ITConfig(USART3, USART_IT_RXNE, ENABLE);
	
  USART_Cmd(USART3, ENABLE);
}
//---------------------------------------------------------------------------------------------------------------------------
void SEND(uint8_t* buffer,uint8_t size)
{
	int i;
	for(i=0;i<size;i++)
		{	
				USART_SendData(USART3, buffer[i]);
				while(USART_GetFlagStatus(USART3,USART_FLAG_TXE) == RESET){}
				}
}
//---------------------------------------------------------------------------------------------------------------------------
void SENDNUM(int n)
{	int k=n;
	int i=0;
	int q=0;
	while (k!=0) {k=k/10;q++;}
	if (q==0) q=1;
	k=1;
	for(i=0;i<q-1;i++) k=k*10;
	while (k!=0)
	{	SENDONLY1NUM(n/k);
		n=n%k;
		k=k/10;
	}
}
//---------------------------------------------------------------------------------------------------------------------------
void SENDONLY1NUM(int n)
{	switch (n) 
	{
	case 0:USART_SendData(USART3,'0');break;
	case 1:USART_SendData(USART3,'1');break;
	case 2:USART_SendData(USART3,'2');break;
	case 3:USART_SendData(USART3,'3');break;
	case 4:USART_SendData(USART3,'4');break;
	case 5:USART_SendData(USART3,'5');break;
	case 6:USART_SendData(USART3,'6');break;
	case 7:USART_SendData(USART3,'7');break;
	case 8:USART_SendData(USART3,'8');break;
	case 9:USART_SendData(USART3,'9');break;
	}
	while(USART_GetFlagStatus(USART3,USART_FLAG_TXE) == RESET){}
			
}
//---------------------------------------------------------------------------------------------------------------------------
void SENDSTR(unsigned char *s)
{
	while (*s) 
	{			USART_SendData(USART3,*s);
				while(USART_GetFlagStatus(USART3,USART_FLAG_TXE) == RESET){}
				s++;
		}
}
//---------------------------------------------------------------------------------------------------------------------------
void SENDFLOAT_UART(float a,uint8_t uart_num)
{
	uint8_t* data=(uint8_t*)&a;
	buffer1[1]=uart_num;
	buffer1[2]=data[0];
	buffer1[3]=data[1];
	buffer1[4]=data[2];
	buffer1[5]=data[3];
	SEND(buffer1,sizeof(buffer1));
}
//---------------------------------------------------------------------------------------------------------------------------
void USART3_IRQHandler(void)
{
	char temp;
	if(USART_GetITStatus(USART3, USART_IT_RXNE) != RESET)
	{
		/* Read one byte from the receive data register */
		temp = USART_ReceiveData(USART3);
		rxbuffer[rxindex] = temp;
		rxindex++;
		if (rxindex==rxsize) rxindex=0;
	}
	if (FLAGRECEIVE==0) BITRECEIVE=1;
	if (FLAGRECEIVE==1) BITRECEIVE++;
	if (BITRECEIVE>rxsize) 
		{	BITRECEIVE=rxsize;
			BUFFEROVERFLOW=1;
		}					
	FLAGRECEIVE=1;
}
//---------------------------------------------------------------------------------------------------------------------------
void TASKRECEIVE(void)
{	
}

//---------------------------------------------------------------------------------------------------------------------------
void RECEIVE(uint8_t* buffer,uint8_t size)
{	
	int i;
	int k=rxindex-1;
	if (size>rxsize) size=rxsize;
	for(i=0;i<=size;i++)
		{	if (k<0) k=rxsize; 
			buffer[size-i-1]=rxbuffer[k];
			k--;
				}
}
//---------------------------------------------------------------------------------------------------------------------------
int RECEIVENUM(uint8_t size)
{	
	int i=0;
	int n=0;	
	int q=1;
	int k=rxindex-1;
	if (size>rxsize) size=rxsize;
	for(i=0;i<size;i++)
		{	if (k<0) k=rxsize; 
			n=n+(rxbuffer[k]-0x30)*q;
			q=q*10;
			k--;
				}
	return n;
}
//---------------------------------------------------------------------------------------------------------------------------
int GET_FLAGRECEIVE(void)
{	return FLAGRECEIVE;
}
//---------------------------------------------------------------------------------------------------------------------------
int GET_BITRECEIVE(void)
{	return BITRECEIVE;
}
//---------------------------------------------------------------------------------------------------------------------------
int GET_BUFFEROVERFLOW(void)
{	return BUFFEROVERFLOW;
}
//---------------------------------------------------------------------------------------------------------------------------
void SET_UARTSTATUS(int a,int b,int c,int d)
{	
	BUFFEROVERFLOW=a;
	FLAGRECEIVE=b;
	BITRECEIVE=c;
	rxindex=d;
}
