#include <Arduino.h>

#define pinled 21

// prototipo da funcao
void ligadesliled (u_int8_t pin);

void setup() 
{
 pinMode(pinled, OUTPUT);
}

void loop() 
{
 ligadesliled(pinled);
}

void ligadesliled (u_int8_t pin)// oq a funcao vai fazer
{
  digitalWrite(pin, HIGH);
  delay(300);
  digitalWrite(pin, LOW);
  delay(300);
}


