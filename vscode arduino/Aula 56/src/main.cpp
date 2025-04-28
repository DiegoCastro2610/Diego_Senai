#include <Arduino.h>
#include "BluetoothSerial.h"

BluetoothSerial BT;

String palavra = "";

void setup() 
{
 BT.begin("ESPDIEGO1");
 pinMode(2, OUTPUT);
}

void loop() 
{
 static bool conectado = false;
 if(BT.hasClient() != conectado)//le quando tem alguem conectado por bluetoofh e vira 1
 {
  conectado = !conectado;
  if(conectado == true)
  {
    digitalWrite(2 ,HIGH);
  }
  else
  {
   digitalWrite(2 ,LOW);
  }
 }
 while(BT.available())//analisa a serial para quando receber algo
 {
  char letra = BT.read();//le oq tem escrito na serial e atribue a uma variavel

  if(letra == '\n')
  {
   palavra = "";
  }

  if(letra != '\n')
  {
   palavra += letra;
  }

  if(palavra.equals("ligar"))
  {
   digitalWrite(2, HIGH);
  }
  if(palavra.equals("desligar"))
  {
   digitalWrite(2, LOW);
  }
 }
}


