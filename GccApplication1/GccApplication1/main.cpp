/*
 * GccApplication1.cpp
 *
 * Created: 05.05.2026 14:00:37
 * Author : 13626533
 */ 

#include <avr/io.h>


class a
{
	public:
	uint8_t count;
	
	a(){
		count=7;
	}
	
	};

int main(void)
{
	a i = a();
	i.count=0;
    
	uint8_t j =0;
	/* Replace with your application code */
    while (1) 
    {
		j++;
		if(j%2==0) i.count++;
    }
}

