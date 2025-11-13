/*
let valorUsuario = prompt("digite um numero: ")

let stringNum = valorUsuario.split("")

let i = 0

let soma = 0


while(stringNum.length > i ){
    soma += parseInt(stringNum[i])
    i++
}

console.log(soma)
*/
/*
let valor = parseInt(prompt("coloque um numero que vc quer o fatorial"))
let resultado2 = 0
let resultado1 = 1

while(valor >= 2){
    resultado2 = valor * (valor - 1)
    resultado1 = resultado1 * resultado2
    valor = valor - 2
}

console.log(resultado1)
*/

/*
let valor = prompt("digite um numero: ")
let stringNum = valor.split("")
let i = stringNum.length - 1
let u = 1
let valorContario = []

while(stringNum.length >= u){
valorContario.push(stringNum[i])
i = i - 1
u = u + 1
}

console.log(valorContario.join(""))
*/


let valorUsuario = parseInt(prompt("digite um numero: "))
let valorTotal = 0
let laco = []

for(i = 1; valorUsuario >= i; i++){
    if(valorUsuario % i == 0 && i != valorUsuario){
        valorTotal = i + valorTotal
    }
    if(valorTotal == valorUsuario){
    laco.push(valorUsuario)
    }
}
console.log(laco)

