#include <Arduino.h>

struct pessoa //agrupa variaveis e cria uma struct de nome pessoa
{
char nome[20];
int idade;
float altura;
bool sexo; // true = homem / false = mulher
};

//----------------------------------------------------------------------------

struct rgb
{
char red;
char green;
char blue;
};

//-------------------------------------------------------------------------------

struct pessoa aluno; // inicia a struct como uma variavel de nome aluno

void setup() 
{
  Serial.begin(9600);
 
 stpcpy(aluno.nome, "Diego"); // copia uma palavra para uma variavel com uma string
 aluno.idade = 17;
 aluno.altura = 1.85;
 aluno.sexo = true;

// Serial.printf = serve para dar print em uma struct e no final com virgula vc coloca de qual struct vc vai usar e qual variavel vai dentro dessa intrutura vc vai usar
// \n = quebra linhas / \r = volta para o comeco da linha
// %s(string(palavras)), %d(decimal(int)) e %f(float) = serve para escolher o tamanho da variavel que vai ser escrito da struct e %.(valor de casa depois da virgula)f para escolher o numero da casa depois da virgula
 Serial.printf("meu nome e: %s \n\r", aluno.nome);
 Serial.printf("e tenho %d anos \n\r", aluno.idade);
 Serial.printf("tenho %.2f metros de altura \n\r", aluno.altura);
 Serial.printf("e %s \n\r", aluno.sexo ? "sou macho" : "sou femea"); // Condicao ? (se for verdadeiro vai fazer um comando) : (se for falso vai ser esse)


 /*if(aluno.sexo) Serial.println("sou macho");
 else 
 {
  Serial.println("sou femea");
 }*/

//----------------------------------------------------------------------------------------------------------------------------------

struct rgb t1;

t1.red = 130;
t1.blue = 255;
t1.green = 56;


Serial.printf("valor vermelho: %d \n\r", t1.red);
Serial.printf("valor azul: %d \n\r", t1.blue);
Serial.printf("valor verde: %d \n\r", t1.green);

if(t1.red == 130 & t1.blue == 255 & t1.green == 56)
 {
  Serial.println("esse valor e roxo");
 }

}

void loop() 
{

}
