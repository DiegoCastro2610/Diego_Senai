#include <Arduino.h>
#include <LiquidCrystal_I2C.h>

LiquidCrystal_I2C lcd (0x27, 20, 4);

int valorrolagem(int valorporta, int valorportapassado);

void setup() 
{
 lcd.init();
 lcd.backlight();
 Serial.begin(1500000);
 pinMode(5,INPUT);
 pinMode(18,INPUT);
 pinMode(19,INPUT);
}

void loop() 
{
 int porta1;

 static int portapassado;


 bool leitura18 = digitalRead(18);
 bool leitura19 = digitalRead(19);

if(leitura18 == 1 & leitura19 == 1)
{
 porta1 = 0;
}
if(leitura18 == 1 & leitura19 == 0)
{
 porta1 = 1;
}
if(leitura18 == 0 & leitura19 == 0 )
{
 porta1 = 2;
}
if(leitura18 == 0 & leitura19 == 1)
{
 porta1 = 3;
}



Serial.println(valorrolagem(porta1, portapassado));
portapassado = porta1;
}


int valorrolagem(int valorporta, int valorportapassado)
{ 
static int contagem;

  if(valorporta == 1 && valorportapassado == 0)
  {
   contagem++;
  }
  if(valorporta == 0 && valorportapassado == 1)
  {
   contagem--;
  }
  
  return contagem;
}