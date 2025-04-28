#include <Arduino.h>
#include <LiquidCrystal_I2C.h>

#define pinled 4
#define pinbotao1 23
#define pinbotao2 18

LiquidCrystal_I2C lcd (0x27, 20, 4);
int multiplicacao (int a, int b);


void setup() 
{
 pinMode(pinled, OUTPUT);
 pinMode(pinbotao1, INPUT_PULLUP);
 pinMode(pinbotao2, INPUT_PULLUP);

 lcd.init();
 lcd.backlight();

 Serial.begin(9600);
}

void loop() 
{
 static bool passadobotao1;
 static bool passadobotao2;
 bool leiturabotao1 = digitalRead(pinbotao1);
 bool leiturabotao2 = digitalRead(pinbotao2);
 static int seta = 0;

 static int tempopassado1;
 int tempo1 = millis();
 static int tempopassado2;
 int tempo2 = millis();

 static bool acao1;
 static bool acao2;

 static int okA = 0;
 static int okB = 0;

 static int valorA;
 static int valorB;

 if(leiturabotao1 != passadobotao1) tempopassado1 = tempo1;

 if(50 < tempo1 - tempopassado1)
  {
   if(leiturabotao1 != acao1 )
    {
     if(leiturabotao1 == 0)
      {
       seta++; 
      }
      acao1 = leiturabotao1;
    }
  }

   if(leiturabotao2 != passadobotao2) tempopassado2 = tempo2;

 if(50 < tempo2 - tempopassado2)
  {
   if(leiturabotao2 != acao2)
    {
     if(leiturabotao2 == 0)
      {
       okA++;
       okB++;
      }
      acao2 = leiturabotao2;
    }
  }

  if(seta == 0)
   {
    lcd.setCursor(0,1);
    lcd.print("^");
    lcd.setCursor(18,1);
    lcd.print(" ");
   }
    if(seta == 1)
   {
    lcd.setCursor(2,1);
    lcd.print("^");
     lcd.setCursor(0,1);
    lcd.print(" ");
   }
    if(seta == 2)
   {
    lcd.setCursor(4,1);
    lcd.print("^");
    lcd.setCursor(2,1);
    lcd.print(" ");
   }
    if(seta == 3)
   {
    lcd.setCursor(6,1);
    lcd.print("^");
    lcd.setCursor(4,1);
    lcd.print(" ");
   }
    if(seta == 4)
   {
    lcd.setCursor(8,1);
    lcd.print("^");
    lcd.setCursor(6,1);
    lcd.print(" ");
   }
    if(seta == 5)
   {
    lcd.setCursor(10,1);
    lcd.print("^");
     lcd.setCursor(8,1);
    lcd.print(" ");
   }
    if(seta == 6)
   {
    lcd.setCursor(12,1);
    lcd.print("^");
    lcd.setCursor(10,1);
    lcd.print(" ");
   }
    if(seta == 7)
   {
    lcd.setCursor(14,1);
    lcd.print("^");
    lcd.setCursor(12,1);
    lcd.print(" ");
   }
    if(seta == 8)
   {
    lcd.setCursor(16,1);
    lcd.print("^");
    lcd.setCursor(14,1);
    lcd.print(" ");
   }
    if(seta == 9)
   {
    lcd.setCursor(18,1);
    lcd.print("^");
    lcd.setCursor(16,1);
    lcd.print(" ");
   }
   if(seta > 9)
   {
    seta = 0;
   }


   if(okA == 1 & seta == 0)
   {
    valorA = 0;
    okA = 2;
    lcd.setCursor(9,3);
    lcd.print(" ");
    digitalWrite(pinled, HIGH);
    delay(300);
    digitalWrite(pinled, LOW);
   }
   if(okA == 1 & seta == 1)
   {
    valorA = 1;
    okA = 2;
    lcd.setCursor(9,3);
    lcd.print(" ");
    digitalWrite(pinled, HIGH);
    delay(300);
    digitalWrite(pinled, LOW);
   }
   if(okA == 1 & seta == 2)
   {
    valorA = 2;
    okA = 2;
    lcd.setCursor(9,3);
    lcd.print(" ");
    digitalWrite(pinled, HIGH);
    delay(300);
    digitalWrite(pinled, LOW);
   }
   if(okA == 1 & seta == 3)
   {
    valorA = 3;
    okA = 2;
    lcd.setCursor(9,3);
    lcd.print(" ");
    digitalWrite(pinled, HIGH);
    delay(300);
    digitalWrite(pinled, LOW);
   }
   if(okA == 1 & seta == 4)
   {
    valorA = 4;
    okA = 2;
    lcd.setCursor(9,3);
    lcd.print(" ");
    digitalWrite(pinled, HIGH);
    delay(300);
    digitalWrite(pinled, LOW);
   }
   if(okA == 1 & seta == 5)
   {
    valorA = 5;
    okA = 2;
    lcd.setCursor(9,3);
    lcd.print(" ");
    digitalWrite(pinled, HIGH);
    delay(300);
    digitalWrite(pinled, LOW);
   }
   if(okA == 1 & seta == 6)
   {
    valorA = 6;
    okA = 2;
    lcd.setCursor(9,3);
    lcd.print(" ");
    digitalWrite(pinled, HIGH);
    delay(300);
    digitalWrite(pinled, LOW);
   }
   if(okA == 1 & seta == 7)
   {
    valorA = 7;
    okA = 2;
    lcd.setCursor(9,3);
    lcd.print(" ");
    digitalWrite(pinled, HIGH);
    delay(300);
    digitalWrite(pinled, LOW);
   }
   if(okA == 1 & seta == 8)
   {
    valorA = 8;
    okA = 2;
    lcd.setCursor(9,3);
    lcd.print(" ");
    digitalWrite(pinled, HIGH);
    delay(300);
    digitalWrite(pinled, LOW);
   }
   if(okA == 1 & seta == 9)
   {
    valorA = 9;
    okA = 2;
    lcd.setCursor(9,3);
    lcd.print(" ");
    digitalWrite(pinled, HIGH);
    delay(300);
    digitalWrite(pinled, LOW);
    
   }
  

   if(okB == 2 & seta == 0)
   {
    valorB = 0;
    okB = 0;
    okA = 0;
    lcd.setCursor(9,3);
    lcd.print(" ");
    digitalWrite(pinled, HIGH);
    delay(300);
    digitalWrite(pinled, LOW);
   }
   if(okB == 2 & seta == 1)
   {
    valorB = 1;
    okB = 0;
    okA = 0;
    lcd.setCursor(9,3);
    lcd.print(" ");
    digitalWrite(pinled, HIGH);
    delay(300);
    digitalWrite(pinled, LOW);
   }
   if(okB == 2 & seta == 2)
   {
    valorB = 2;
    okB = 0;
    okA = 0;
    lcd.setCursor(9,3);
    lcd.print(" ");
    digitalWrite(pinled, HIGH);
    delay(300);
    digitalWrite(pinled, LOW);
   }
   if(okB == 2 & seta == 3)
   {
    valorB = 3;
    okB = 0;
    okA = 0;
    lcd.setCursor(9,3);
    lcd.print(" ");
    digitalWrite(pinled, HIGH);
    delay(300);
    digitalWrite(pinled, LOW);
   }
   if(okB == 2 & seta == 4)
   {
    valorB = 4;
    okB = 0;
    okA = 0;
    lcd.setCursor(9,3);
    lcd.print(" ");
    digitalWrite(pinled, HIGH);
    delay(300);
    digitalWrite(pinled, LOW);
   }
   if(okB == 2 & seta == 5)
   {
    valorB = 5;
    okB = 0;
    okA = 0;
    lcd.setCursor(9,3);
    lcd.print(" ");
    digitalWrite(pinled, HIGH);
    delay(300);
    digitalWrite(pinled, LOW);
   }
   if(okB == 2 & seta == 6)
   {
    valorB = 6;
    okB = 0;
    okA = 0;
    lcd.setCursor(9,3);
    lcd.print(" ");
    digitalWrite(pinled, HIGH);
    delay(300);
    digitalWrite(pinled, LOW);
   }
   if(okB == 2 & seta == 7)
   {
    valorB = 7;
    okB = 0;
    okA = 0;
    lcd.setCursor(9,3);
    lcd.print(" ");
    digitalWrite(pinled, HIGH);
    delay(300);
    digitalWrite(pinled, LOW);
   }
   if(okB == 2 & seta == 8)
   {
    valorB = 8;
    okB = 0;
    okA = 0;
    lcd.setCursor(9,3);
    lcd.print(" ");
    digitalWrite(pinled, HIGH);
    delay(300);
    digitalWrite(pinled, LOW);
   }
   if(okB == 2 & seta == 9)
   {
    valorB = 9;
    okB = 0;
    okA = 0;
    lcd.setCursor(9,3);
    lcd.print(" ");
    digitalWrite(pinled, HIGH);
    delay(300);
    digitalWrite(pinled, LOW);
   }

  
 lcd.setCursor(0,0);
 lcd.print("0");
 lcd.setCursor(2,0);
 lcd.print("1");
 lcd.setCursor(4,0);
 lcd.print("2");
 lcd.setCursor(6,0);
 lcd.print("3");
 lcd.setCursor(8,0);
 lcd.print("4");
 lcd.setCursor(10,0);
 lcd.print("5");
 lcd.setCursor(12,0);
 lcd.print("6");
 lcd.setCursor(14,0);
 lcd.print("7");
 lcd.setCursor(16,0);
 lcd.print("8");
 lcd.setCursor(18,0);
 lcd.print("9");

 lcd.setCursor(0,3);
 lcd.print(valorA);
 lcd.setCursor(2,3);
 lcd.print("*");
 lcd.setCursor(4,3);
 lcd.print(valorB);
 lcd.setCursor(6,3);
 lcd.print("=");
 lcd.setCursor(8,3);
 lcd.print(multiplicacao (valorA, valorB));


passadobotao1 = leiturabotao1;
passadobotao2 = leiturabotao2;
}

int multiplicacao (int a, int b)
{
  int resultado;
  resultado = a * b;
  return resultado;
}