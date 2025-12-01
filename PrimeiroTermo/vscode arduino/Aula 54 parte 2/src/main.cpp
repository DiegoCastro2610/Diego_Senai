#include <Arduino.h>

char nome[20];
char nome2[20];

void setup() 
{
 Serial.begin(9600);
 strcpy(nome, "Diego");

 strcat( nome, "Castro");// adiciona algo na string

 strcpy(nome2, "Isaque Silva");

 int tamanho = strlen(nome);// fala qual e o tamanho do dado que tem na string

  Serial.println(tamanho);

  // Compara strings e retorna ZERO se forem IGUAIS
  if (strcmp("DiegoCastro", nome) == 0)
    Serial.println("Sao iguais");
  else
    Serial.println("Sao diferentes");

  if (strcmp("IsaqueSilva", nome2) == 0)
    Serial.println("Sao iguais");
  else
    Serial.println("Sao diferentes");

  // COMPARA N caracteres a partir da esquerda entre 2 NOMES
  if (strncmp(nome, nome2, 6) == 0)
    Serial.println("Os 6 primeiros digitos sao iguais");
  else
    Serial.println("Os 6 primeiros digitos sao diferentes");

  // CONCATENA informacoes em uma VARIAVEL
  char buffer[50];
  int temperatura = 25;
  sprintf(buffer, "Temperatura: %d°C", temperatura); //* Adiciona a um vetor um texto como um printf
  Serial.println(buffer);
}


void loop() 
{
 
}
