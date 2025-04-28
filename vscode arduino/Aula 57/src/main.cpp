#include <Arduino.h>

String msg = "";
String passadomsg = "";

void setup() 
{
 Serial.begin(9600);
 Serial.println("escreva o comando:");
 pinMode(2, OUTPUT);
}

void loop() 
{
 static bool estadoled;
 static bool piscaled;
 static int velocidade = 3000;
 if(Serial.available())
 {
  msg = Serial.readStringUntil('\n');
 }
 if(msg.equals("desliga"))
 {
  estadoled = false;
  piscaled = false;
 }
 else if(msg.equals("liga"))
 {
  estadoled = true;
  piscaled = false;
 }
 if(msg.equals("velocidade")) Serial.println("qual velocidade vc deseja:");
  
 if(passadomsg.equals("velocidade")) velocidade = msg.toInt(); 

 if(msg.equals("pisca"))
 {
  estadoled = false;
  static int tempopassado;
  int tempoled = millis();
  if(tempoled - tempopassado > velocidade)
  {
    piscaled = !piscaled;
    tempopassado = tempoled;
  }
 }

passadomsg = msg;

 digitalWrite(2, estadoled);
 digitalWrite(2, piscaled);
}
