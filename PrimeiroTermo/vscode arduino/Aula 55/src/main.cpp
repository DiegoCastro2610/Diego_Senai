#include <Arduino.h>
#include "BluetoothSerial.h" //adiciona o bluetooth no esp

String palavra ="";//adiciona uma palavra mais nao e recomendado

//instancia de objetos

BluetoothSerial BT;

void setup() 
{
 Serial.begin(9600);
 Serial.println("digite algo:");
 pinMode(2, OUTPUT);
 BT.begin("espCastro");//da o nome no bluetooth
}

void loop() 
{
 if(Serial.available())// vai virar verdadeiro quando algo algo na serial
 {
  char caractere = Serial.read(); // vai ler oq esta na serial
  Serial.printf("voce digitou %c \n\r", caractere);
//--------------------------------------------------------------------------------------------------
  if(caractere == 'l')
  {
    digitalWrite(2, HIGH);
    Serial.println("esta ligado");
  }
  else if(caractere == 'd')
  {
    digitalWrite(2, LOW);
    Serial.println("esta desligado");
  }
  else
  {
    Serial.println("seu idiota e so d e l burro");
  }
//----------------------------------------------------------------------------------------------------
  if(caractere == '\n')
  {
    Serial.println(palavra);
    palavra == "";
  }
  else if(caractere != '\n')
  {
    palavra += caractere;
  }
//------------------------------------------------------------------------------------------------------
 if(palavra.equals("ligar"))//copara se a palavra na String e igual 
 {
  digitalWrite(2, HIGH);
 }

 if(palavra.equals("desligar"))
 {
  digitalWrite(2, LOW);
 }
}
//--------------------------------------bluetoof-------------------------------------------------------------------------

if(BT.available())
{
 char caracterebt = BT.read();
 if(caracterebt == '\n')
 {
  BT.println(palavra);
  palavra = "";
 }
 else if(caracterebt != '\n')
 {
  palavra += caracterebt;
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
 //BT.println("Guilherme gay"); manda para a serial do bluetoohf
}
// equalsignorcase nao liga se e maiuscula e minuscula