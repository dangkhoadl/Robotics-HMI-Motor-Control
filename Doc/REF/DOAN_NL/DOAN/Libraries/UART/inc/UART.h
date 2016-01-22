void UART3_CONFIG(uint32_t baudrate);
void Delay(uint32_t nCount);
void SEND(uint8_t* buffer,uint8_t size);
 void SENDSTR(unsigned char *s);
// void RECEIVE(uint8_t* buffer,uint8_t size);
int GET_BITRECEIVE(void);
int GET_FLAGRECEIVE(void);
int GET_BUFFEROVERFLOW(void);
void SENDONLY1NUM(int n);
void SENDNUM(int n);
// int RECEIVENUM(uint8_t size);
// void SET_UARTSTATUS(int a,int b,int c,int d);
void SENDFLOAT_UART(float a,uint8_t uart_num);

