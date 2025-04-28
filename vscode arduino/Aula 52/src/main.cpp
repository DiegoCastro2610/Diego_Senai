#include <Arduino.h>
#include <LiquidCrystal_I2C.h>

#define canalA 19
#define canalB 18

LiquidCrystal_I2C lcd(0x27, 20, 4);

const int8_t tabelaTransicao [4][4]={
/* +1 horário
    0 parado
   -1 anti horário
*/
      /* 1  2 3 4 */
/* 0 */ {0,-1,1,0},
/* 1 */ {1,0,0,-1},
/* 2 */ {-1,0,0,1},
/* 3 */ {0,1,-1,0},
};
//10231023 AntiHorario
//32013201 Horario


void setup()
{
lcd.init();
lcd.backlight();
pinMode(canalA,INPUT);
pinMode(canalB,INPUT);
Serial.begin(1500000);
}


void loop()
{
bool leituraCanalA=digitalRead(canalA);
bool leituraCanalB=digitalRead(canalB);

int estadoAtualEnconder=((leituraCanalA << 1)| leituraCanalB);
static int estadoAnteriorEncoder =3;
static int posicao =0;

posicao=posicao + tabelaTransicao[estadoAnteriorEncoder][estadoAtualEnconder];
Serial.println(posicao); 

// meu codigo

static int decer = 0;
static int valormenu = 0;
if(posicao == 4)
{
 valormenu++;
 posicao = 0;
}

if(posicao == -4)
{
 valormenu--;
 posicao = 0;
}

  lcd.setCursor(0,valormenu);
  lcd.print(">");     

 if(valormenu == 4)
 {
  valormenu = 0;
 } 

estadoAnteriorEncoder=estadoAtualEnconder;

}