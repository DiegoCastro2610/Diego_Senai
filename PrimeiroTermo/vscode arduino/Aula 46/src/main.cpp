#include <Arduino.h>
#include <LiquidCrystal_I2C.h> //criando o objeto

LiquidCrystal_I2C lcd(0x27,20,4); //adicionando o objeto(instanciano o objeto)

void setup() 
{
Serial.begin(115200);
pinMode(0, INPUT);

lcd.init();
lcd.backlight();
lcd.print("quantas vezes");
}

void loop() 
{ 
 static int contagem;
 static bool botaoanterior;
 bool botao = digitalRead(0);
 
 if(botao == 0 & botaoanterior == 1)  contagem++;
 
 botaoanterior = botao;

 switch (contagem)
 {
 case 1:
    lcd.setCursor(0,0);
    lcd.print("comi o cu seu");
    break;

    case 2:
    lcd.setCursor(0,0);
    lcd.print("comi da sua mae");
    break;

    case 3:
    lcd.setCursor(0,0);
    lcd.print("comi do seu pai");
    break;
 }
    if(contagem >= 4)  
    {
    lcd.setCursor(0,0);
    lcd.print("vc quer mais?  ");
    }
    
}