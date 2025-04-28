/*
=================================================master(conecta)===============================================================
#include <Arduino.h>
#include "BluetoothSerial.h"

BluetoothSerial SerialBT;


void setup() {
Serial.begin(9600);
SerialBT.begin("ESPMaster", true);

if(SerialBT.connect("ESPCaique"))
{
  Serial.println("Conectado ao dipositivo com sucesso");
}

else
{
  Serial.println("tem um noia conectando");
  while(true);//trava o ESP
}
}

void loop() {
SerialBT.print("Vai");
Serial.println("Mensagem enviada");

unsigned long timeout = millis() +3000;
while(millis() < timeout)
{
  if(SerialBT.available())
  {
    String resposta = SerialBT.readStringUntil('\r');
    Serial.printf("Resposta: %s", resposta);
    break;
  }
}
}

=======================================slave(recebe coneccao)==========================================================
#include <Arduino.h>
#include "BluetoothSerial.h"

BluetoothSerial SerialBT;

void setup()
{
  Serial.begin(9600);
  SerialBT.begin("ESPCaique, false"); //quando e um slave

  Serial.println("Esperando uma conecxao bluetooth");
}

void loop()
{
  if(Serial.available())
  {
   String comandoEnviar = Serial.readStringUntil('\n');
   ComandoEnviar.trim();
   SerialBT.println(comandoEnviar)
  }
  
  if (SerialBT.available())
  {
    -//SerialBT.readStringUntil ele vai ler a string enquanto nao fazer a funcao em parenteses

    String comandoReceber = SerialBT.readStringUntil('\n');
    comandoReceber.trim();
    Serial.printf("Mensagem Recebida: %s", mensagem);
    if (mensagem.equals("pings"))
    {
      SerialBT.print("pong");
    }
  }
}
*/

#include <Arduino.h>
#include "BluetoothSerial.h"

BluetoothSerial BT;
String palavra = "";
String resposta= "";
char nome[]= "diego";

void setup()
{
 BT.begin("espdiego1master", true);//transforma em master
 Serial.begin(9600);

 if(BT.connect("SlaveLuigi"))// conecta com outro esp normamlmente o escravo(slave)
 {
  Serial.println("voce esta conectado");
  Serial.println("escreva aqui:");
 }
 else
 {
  Serial.println("voce nao esta conectado");
 //while(true);
 }
}


void loop()
{
 
 if(Serial.available())
 {
  char letra = Serial.read();
  if(letra == '\n')
  {
   Serial.println("mensagem enviada");
   palavra.trim();
   BT.println(palavra);
   palavra = "";
  }

  if(letra != '\n')
  {
  palavra += letra;
  }
 }

if(BT.available())
 {
  resposta = BT.readStringUntil('\r' || '\n');
  Serial.printf("resposta: %s", resposta);
 }
}