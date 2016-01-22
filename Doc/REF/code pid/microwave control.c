double pid (double e0)
{
    double a0 = 0, a1 = 0, a2 = 0, u = 0;
    a0=Kp+Ki*T/2+Kd/T;
    a1=-Kp+Ki*T/2-2*Kd/T;
    a2=Kd/T;
    u=u_1+a0*e0+a1*e_1+a2*e_2;
    if(u>200) u = 200;
    if(u<0)    u = 0;
    u_1 = u;
    e_1 = e0;
    e_2 = e_1;
    return u;
}