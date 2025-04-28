#include <Arduino.h>

int calcula2grau (int a, int b, int c);

void setup() 
{ 
 Serial.begin(9600);
 int resultado = calcula2grau(-1,-1,20);
 Serial.println(resultado);
}

void loop() 
{

}

int calcula2grau (int a, int b, int c)
{
int baska;
float delta = (b * b) - (4 * a * c);
baska = (-b + sqrt(delta)) / (2 * a);
return baska;
}
