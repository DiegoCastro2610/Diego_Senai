#include <Arduino.h>

#define pinled 21
#define pinbotao 23

void setup() 
{
 pinMode(pinled, OUTPUT);
 pinMode(pinbotao, INPUT_PULLUP);
 Serial.begin(9600);
}

void loop() 
{
 static bool leiturabotaopassado;
 bool leiturabotao = digitalRead(pinbotao);
 static bool led = 0;
 static int contagem = 0;
 static long tempopassado;
 static bool ultimaacao = 1;
 long tempo = millis();
 
 if(leiturabotao != leiturabotaopassado) 
  {
   tempopassado = tempo;
  }

 if(50 < tempo - tempopassado) 
   {
    if(ultimaacao != leiturabotao)
     {
      ultimaacao = leiturabotao;
      if (!leiturabotao)
      {
        led = !led;
        Serial.println(++contagem);
      }  
     }
   }

 leiturabotaopassado = leiturabotao;

 digitalWrite(pinled, led);
}  

