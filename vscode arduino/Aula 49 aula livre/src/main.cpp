#include <Arduino.h>
#include <LiquidCrystal_I2C.h>

#define pinbotao 23
#define pinled 4

LiquidCrystal_I2C lcd (0x27,20,4);

void tempolimpesa (u_int8_t);

void setup() 
{
 Serial.begin(9600);
 pinMode(pinbotao, INPUT_PULLUP);
 pinMode(pinled, OUTPUT);

 lcd.init();
 lcd.backlight();
}

void loop() 
{
static bool passadobotao;
static unsigned int tempopassado;
static bool acao;
bool leiturabotao = digitalRead(pinbotao);
unsigned int tempo = millis();

lcd.setCursor(0,0);
 lcd.print("iniciar limpeza");
 lcd.setCursor(0,1);
 lcd.print("aperte o botao");

if (leiturabotao != passadobotao) tempopassado = tempo;

if(50 < tempo - tempopassado)
 {
  if(leiturabotao != acao)
  {
    if(leiturabotao == 0)
     {
      lcd.setCursor(0,0);
      lcd.print("limpeza iniciada");
      lcd.setCursor(0,1);
      lcd.print("                  ");
      tempolimpesa(pinled);
      lcd.setCursor(0,0);
      lcd.print("limpeza finalizada");
      lcd.setCursor(0,1);
      lcd.print("                  ");
      delay(5000);
     }
    acao = leiturabotao;
  }
 }
 passadobotao = leiturabotao;
}

void tempolimpesa (u_int8_t pin)
{
for(int v = 1; v < 11; ++v)
 {
  lcd.setCursor(0,1);
  lcd.print(v);
  lcd.setCursor(2,1);
  lcd.print(" segundos");
  digitalWrite(pin, HIGH);
  delay(500);
  digitalWrite(pin, LOW);
  delay(500);
  }
}

