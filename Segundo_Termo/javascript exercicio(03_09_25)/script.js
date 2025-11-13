//adv 1
/*
let lado1 = prompt("insira o lado 1")
let lado2 = prompt("insira o lado 2")
let lado3 = prompt("insira o lado 3")

if(lado1 == lado2 && lado1 == lado3 && lado2 == lado3){
    alert("triangulo equilatero")
}
else if(lado1 != lado2 && lado1 == lado3 || lado1 == lado2 && lado1 != lado3 || lado2 == lado3 && lado2 != lado1){
    alert("triangulo isosiles")
}

else{
    alert("trangulo escaleno")
}
*/

//adv 2
/*
let nota = prompt("sua nota")

if(100 >= nota && nota >= 90 ){
    alert("Nota A");
}

else if(89 >= nota && nota >= 80){
    alert("Nota B");
}

else if(79 >= nota && nota >= 70){
    alert("Nota C");
}

else if(69 >= nota && nota >= 60){
    alert("Nota D");
}

else{
    alert("nota Figma")
}
*/

//adv 3
/*
let peso = parseFloat(prompt("seu pesso em kg"))
let altura = parseFloat(prompt("sua altura em Metros"))

let imc = peso / (altura * altura)

if(imc <= 18.49){
    alert("seu imc e " + imc + " e vc esta abaixo do peso")
}
else if(imc <= 24.99 && imc >= 18.5){
    alert("seu imc e " + imc + " e vc esta Normal")
}
else if(imc <= 29.99 && imc >= 25){
    alert("seu imc e " + imc + " e vc esta acima do normal")
}
else if(imc >= 30){
    alert("seu imc e " + imc + " e vc esta obeso")
}
*/

//adv 4

let ano = parseFloat(prompt("que ano vc esta"))

if(ano % 100 != 0 || ano % 4 == 0 && ano % 400 == 0){
    alert("e um ano bixesto")   
}

else{
    alert("nao e um ano bixesto")
}
