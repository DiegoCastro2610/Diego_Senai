//receber informacao do usuario

/*
let NumeroCartao = prompt("Qual o numero do seu cartao:");
alert("obg vou clonar seu cartao " + NumeroCartao);
*/

// if/else if/else

/*
let nota = parseInt(prompt("digite sua nota: "));

if(nota >= 6)
{
    console.log("aprovado(a)");
}

else if(nota == 5)
{
    console.log("recuperacao");
}

else
{
    console.log("reprovado(a)");
}
*/

//if ternario(condicao na propria variavel)

/*
let saldo = 90;

let mensagem = saldo > 100 ? console.log("compra aprovado") : console.log("compra recusada")
? + condicao(condicao verdadeira)
: + condicao(condicao falsa)
*/

//Condicional aninhada
//multiplas verificacoes

/*
let hora = 8;
let diaDaSemana = "terca";

if(hora >= 6 && hora < 12){
    console.log("Bom dia!");
}
else{
    if(hora >= 12 && hora < 18){
        if(diaDaSemana == "segunda"){
            console.log("Boa tarde! Otima semana!");
        }
        else{
            console.log("Boa tarde!");
        }
    }
    else{
        console.log("Boa noite!");
    }
}
*/

//swich case

let dia = 2;

switch(dia){
 case 1:
    console.log("domingo!");
    break;
 case 2:
    console.log("Segunda-feira");
    break;
 case 3:
    console.log("Terca-feira");
 default:
    console.log("Dia invalido");
    break;
}