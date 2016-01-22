#include <msp430g2553.h>
#include "UART.h"
volatile long int  Sample_count,Pulse,Prepulse,Err,Ctrl_speed,pPart,iPart,dPart,PreErr,Output;
volatile long int  Kp,Kd,Ki,Rspeed,Sample_time,inv_Sample_time;
char b[9];
void config_init()
{
	  //PWM Config 0 -> 10000
	  P1DIR |= BIT6;
	  P1SEL |= BIT6;
	  TA0CCR0 = 8000;
	  TA0CCR1 =  0;
	  TA0CCTL1 = OUTMOD_7;
	  TA0CTL = TASSEL_2 + MC_1;
	  //SET FREQUENCY MCU 1MHZ
	  BCSCTL1 = CALBC1_1MHZ;
	  DCOCTL = CALDCO_1MHZ;
	  WDTCTL = WDTPW + WDTHOLD;
	  // PORT INTERRUPT
	  P1IE |= BIT5;
	  P1IES &= ~BIT5;
	  P1IFG &= ~BIT5;
	  //SET TIMER 25MS
	  TA1CCTL0 = CCIE;// CCR0 interrupt enabled
	  TA1CCR0 = 25000;
	  TA1CTL = TASSEL_2  + MC_1;
}
void config_value()
{
	Kp=0;
	Ki=0;
	Kd=0;
	dPart=0;
	iPart=0;
	pPart=0;
	Err = 0;
	PreErr=0;
	Sample_time=25;
	inv_Sample_time=40;
	Ctrl_speed = 0 ;
	Sample_count = 0;
}

void getuart()
{
	int i;
	for (i=0;i<10;i++) 
	{
		b[i]=uart_getc();
	}
	for (i=0;i<9;i++) 
	{
		b[i]=b[i]-48;
	}
	Kd = b[0]*10+b[1];
	Ki = b[2]*10+b[3];
	Kp = b[4]*10+b[5];
	Ctrl_speed = b[6]*100+b[7]*10+b[8];
	Ctrl_speed= Ctrl_speed*10;
}

void main(){
	config_init();
	config_value();
	uart_init();
	IE2 |= UCA0RXIE;
	__enable_interrupt();
    _BIS_SR(GIE);

	while (1)
	{
		if (Sample_count >=10)
		{
			Rspeed=Rspeed/10;
			uart_put_num(Rspeed,0,0);
			b[9]=10;
			uart_putc(b[9]);
			Sample_count=0;
		}
	}
}

;






#pragma vector=TIMER1_A0_VECTOR
__interrupt void Timer_A (void)
{

	  Rspeed = Pulse - Prepulse;
	  Prepulse = Pulse;
	  Err = Ctrl_speed - abs(Rspeed);
	  PreErr = Err;
	  // PID
	  pPart = Kp*Err;
	  dPart = Kd * (Err - PreErr) * inv_Sample_time  ;
	  iPart += Ki * Err * Sample_time/1000  ;

	  Output+= pPart + dPart + iPart;

	  if (Output >= 8000) Output= 8000 - 1;
	  if (Output <= 0)	Output= 1;

	  TA0CCR1 = Output;
	  Sample_count++;
}

#pragma vector = PORT1_VECTOR
  __interrupt void P1_ISR(void)
  {
	 Pulse++;
	 P1IFG &= ~BIT5;// Clear P1.5 interrupt flag
  }

#pragma vector = USCIAB0RX_VECTOR
__interrupt void USCIAB0RX_ISR(void)
{
	getuart();
}

