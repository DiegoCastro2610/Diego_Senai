#include <Arduino.h>
#include "BluetoothSerial.h"

BluetoothSerial BT;

char palavra[20];

void setup() 
{
 BT.begin("espDiego1");
 BT.print("Qual led vc quer de 1 a 4:");
}

void loop() 
{
 if(BT.available())
 {
  char uninumero = BT.read();
  if(uninumero == '\n')
  {
   BT.printf("voce escolheu %c", palavra);
   strcpy(palavra, "");
  }
  else if(uninumero == '1')
  {
   
  }
 }
}
