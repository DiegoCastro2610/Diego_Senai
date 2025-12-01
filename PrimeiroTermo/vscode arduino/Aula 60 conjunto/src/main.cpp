#include <Arduino.h>
#include "RoboCore_MMA8452Q.h"
#include <FastLED.h>

MMA8452Q acelerometro;

#define pinBotao 23
#define pinLed 5     // Saída
#define NUM_LEDS 25  // Número de LEDs
CRGB leds[NUM_LEDS]; // Array de LEDs

// * Variáveis globais
uint8_t r = 16;
uint8_t g = 16;
uint8_t b = 16;
int i;
int valor1;
int valor2;
int sequencia[15] = {3, 6, 1, 0, 7, 2, 5, 4, 3, 1, 6, 0, 2, 7, 5};


// * Protótipos
void setaEsquerda(uint8_t r, uint8_t g, uint8_t b);
void setaDireita(uint8_t r, uint8_t g, uint8_t b);
void setaFrente(uint8_t r, uint8_t g, uint8_t b);
void setaTras(uint8_t r, uint8_t g, uint8_t b);
void setaFrenteEsquerda(uint8_t r, uint8_t g, uint8_t b);
void setaFrenteDireita(uint8_t r, uint8_t g, uint8_t b);
void setaTrasEsquerda(uint8_t r, uint8_t g, uint8_t b);
void setaTrasDireita(uint8_t r, uint8_t g, uint8_t b);
void sorriso();

void setup()
{
  Serial.begin(115200);
  acelerometro.init();

  FastLED.addLeds<WS2812, pinLed, GRB>(leds, NUM_LEDS); // Funciona tipo um pinMode para os LEDs
  sorriso();

  pinMode(pinBotao, INPUT_PULLUP);
}
void loop()
{
  Serial.println("posicao:");
  /*Serial.printf("x = %f ", acelerometro.x);
  Serial.printf("y = %f ", acelerometro.y);
  Serial.printf("z = %f ", acelerometro.z);*/
  Serial.println("");

  
for(i; i <= 15; ++i)
  {
   if(sequencia[i] == 0)
   {
    setaTrasEsquerda(r, g, b);
   }
   if(sequencia[i] == 1)
   {
    setaFrenteEsquerda(r, g, b);
   }
   if(sequencia[i] == 2)
   {
    setaTrasDireita(r, g, b);
   }
    if(sequencia[i] == 3)
   {
    setaFrenteDireita(r, g, b);
   }
    if(sequencia[i] == 4)
   {
    setaEsquerda(r, g, b);
   }
    if(sequencia[i] == 5)
   {
    setaDireita(r, g, b);
   }
    if(sequencia[i] == 6)
   {
    setaTras(r, g, b);
   }
    if(sequencia[i] == 7)
   {
    setaFrente(r, g, b);
   }
  delay(3000);
  fill_solid(leds, NUM_LEDS, CRGB::Black);
  FastLED.show();

  delay(1500);
  acelerometro.read();
  int horizontal = 0;
  int vertical = 0;

if (acelerometro.x > 0.2)
  {
    horizontal = 1;
  }
  else if (acelerometro.x < -0.2)
  {
    horizontal = 2;
  }

  if (acelerometro.y > 0.2)
  {
    vertical = 1;
  }
  else if (acelerometro.y < -0.2)
  {
    vertical = 2;
  }

  if (horizontal == 1 && vertical == 1)
  {
    Serial.println("TRAS ESQUERDA");
    setaTrasEsquerda(r, g, b);
    valor1 = 0;
  }
  else if (horizontal == 1 && vertical == 2)
  {
    Serial.println("FRENTE ESQUERDA");
    setaFrenteEsquerda(r, g, b);
    valor1 = 1;
  }
  else if (horizontal == 2 && vertical == 1)
  {
    Serial.println("TRAS DIREITA");
    setaTrasDireita(r, g, b);
    valor1 = 2;
  }
  else if (horizontal == 2 & vertical == 2)
  {
    Serial.println("FRENTE DIREITA");
    setaFrenteDireita(r, g, b);
    valor1 = 3;
  }
  else if (horizontal == 1 && vertical == 0)
  {
    Serial.println("ESQUERDA");
    setaEsquerda(r, g, b);
    valor1 = 4;
  }
  else if (horizontal == 2 && vertical == 0)
  {
    setaDireita(r, g, b);
    Serial.println("DIREITA");
    valor1 = 5;
  }
  else if (horizontal == 0 && vertical == 1)
  {
    Serial.println("TRAS");
    setaTras(r, g, b);
    valor1 = 6;
  }
  else if (horizontal == 0 && vertical == 2)
  {
    Serial.println("FRENTE");
    setaFrente(r, g, b);
    valor1 = 7;
  }

  if (valor2 == i)
  {
   if(sequencia[i] == valor1)
   {
    i = 0;
    Serial.println("0");
   }
   if(sequencia[i] != valor1)
   {
    while(true)
    {
    Serial.println("voce perdeu");
    }
   }
  }
  valor2 += 1; 
}
 
  // BOTAO + LCD

  const unsigned long tempoDebounce = 50;
  static unsigned long tempoAnteriorDebounce = 0;
  unsigned long tempoAtual = millis();

  // lcd.setCursor(9,2);
  // lcd.print("Baixo");
  // lcd.print("Cima ");

  bool estadoAtualBotao = digitalRead(pinBotao);
  static bool estadoAnteriorBotao = 0;
  static bool ultimaAcao = 1;

  static int cont = 0;
  if (estadoAtualBotao != estadoAnteriorBotao)
  {
    tempoAnteriorDebounce = tempoAtual;
  }

  if ((tempoAtual - tempoAnteriorDebounce) > tempoDebounce)
  {
    if (estadoAnteriorBotao != ultimaAcao)
    {
      ultimaAcao = estadoAtualBotao;
      if (!estadoAtualBotao)
      {
        switch (cont)
        {
        case 0:
          r = 32;
          g = 0;
          b = 0;
          cont++;
          break;

        case 1:
          r = 0;
          g = 32;
          b = 0;
          cont++;
          break;

        case 2:
          r = 0;
          g = 0;
          b = 32;
          cont++;
          break;

        case 3:
          r = 32;
          g = 32;
          b = 32;
          cont++;
          break;

        case 4:
          r = 32;
          g = 16;
          b = 0;
          cont++;
          break;

        case 5:
          r = 32;
          g = 32;
          b = 0;
          cont++;
          break;

        case 6:
          r = 16;
          g = 0;
          b = 32;
          cont++;
          break;

        case 7:
          r = 0;
          g = 32;
          b = 32;
          cont++;
          break;

        case 8:
          cont = 0;
          break;
        }
      }
    }
  }
  estadoAnteriorBotao = estadoAtualBotao;
}

// * Funções das setas e sorriso (mesmas de antes, não alteradas)
void setaEsquerda(uint8_t r, uint8_t g, uint8_t b)
{
  fill_solid(leds, NUM_LEDS, CRGB::Black);
  leds[2] = leds[8] = leds[10] = leds[11] = leds[12] = leds[13] = leds[14] = leds[18] = leds[22] = CRGB(r, g, b);
  FastLED.show();
}
void setaDireita(uint8_t r, uint8_t g, uint8_t b)
{
  fill_solid(leds, NUM_LEDS, CRGB::Black);
  leds[2] = leds[6] = leds[10] = leds[11] = leds[12] = leds[13] = leds[14] = leds[16] = leds[22] = CRGB(r, g, b);
  FastLED.show();
}
void setaFrente(uint8_t r, uint8_t g, uint8_t b)
{
  fill_solid(leds, NUM_LEDS, CRGB::Black);
  leds[2] = leds[7] = leds[10] = leds[12] = leds[14] = leds[16] = leds[17] = leds[18] = leds[22] = CRGB(r, g, b);
  FastLED.show();
}
void setaTras(uint8_t r, uint8_t g, uint8_t b)
{
  fill_solid(leds, NUM_LEDS, CRGB::Black);
  leds[2] = leds[6] = leds[7] = leds[8] = leds[10] = leds[12] = leds[14] = leds[17] = leds[22] = CRGB(r, g, b);
  FastLED.show();
}
void setaFrenteEsquerda(uint8_t r, uint8_t g, uint8_t b)
{
  fill_solid(leds, NUM_LEDS, CRGB::Black);
  leds[4] = leds[6] = leds[10] = leds[12] = leds[18] = leds[19] = leds[20] = leds[21] = leds[22] = CRGB(r, g, b);
  FastLED.show();
}
void setaFrenteDireita(uint8_t r, uint8_t g, uint8_t b)
{
  fill_solid(leds, NUM_LEDS, CRGB::Black);
  leds[0] = leds[8] = leds[12] = leds[14] = leds[15] = leds[16] = leds[22] = leds[23] = leds[24] = CRGB(r, g, b);
  FastLED.show();
}
void setaTrasEsquerda(uint8_t r, uint8_t g, uint8_t b)
{
  fill_solid(leds, NUM_LEDS, CRGB::Black);
  leds[0] = leds[1] = leds[2] = leds[8] = leds[9] = leds[10] = leds[12] = leds[16] = leds[24] = CRGB(r, g, b);
  FastLED.show();
}
void setaTrasDireita(uint8_t r, uint8_t g, uint8_t b)
{
  fill_solid(leds, NUM_LEDS, CRGB::Black);
  leds[2] = leds[3] = leds[4] = leds[5] = leds[6] = leds[12] = leds[14] = leds[18] = leds[20] = CRGB(r, g, b);
  FastLED.show();
}
void sorriso()
{
  fill_solid(leds, NUM_LEDS, CRGB::Black);
  leds[1] = leds[2] = leds[3] = leds[5] = leds[9] = leds[16] = leds[18] = CRGB(r, g, b);
  FastLED.show();
}