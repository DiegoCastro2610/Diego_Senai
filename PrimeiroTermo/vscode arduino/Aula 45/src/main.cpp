#include <Arduino.h>

#define pinled 2
#define pinbotao 0


void setup() 
{
pinMode(pinled,OUTPUT);
pinMode(pinbotao, INPUT);
}

void loop() 
{
 bool modebotao = digitalRead(pinbotao);
if(modebotao == 0) digitalWrite(pinled, HIGH);
else digitalWrite(pinled, LOW);
}
