/*
conso notas = [4,7,9,3,10,5]

const pasou = pasou.filter(nota => nota >= 7)

console.log(pasou)
*/

/*
const palavras = ["sol", "mar", "computador", "lua"]

const mais4 = palavras.filter(palavra => palavra.length > 4 )

console.log(mais4)
*/

/*
const animais = ["gato","cachorro","peixe","elefante","abelha"]

const letraC = animais.filter(animal => animal.startsWith("c"))

console.log(letraC)
*/
//-------------------------------------------------------------------------
/*
const filmes = ["Avatar", "Batman", "Vingadores", "Matrix", "Barbie"]

const letraB = filmes.find(filme => filme.startsWith("B"))

console.log(letraB)
*/

/*
const numeros = [2, 4, 6, 9, 12, 15]

const nimp = numeros.find(numero => numero % 2 != 0)

console.log(nimp)
*/

/*
const alunos = [{nome: "Ana", nota: 8},
     {nome: "Carlos", nota: 5},
      {nome: "Beatriz", nota: 9}]

const aluno7 = alunos.find(aluno => aluno.nota >= 7)

console.log(aluno7)
*/
//-------------------------------------------------------------------------
/*
const temperaturas = [20, 25, 30, 15]

const fihrenheit = temperaturas.map(temperatura => temperatura * 1.8 + 32)

console.log(fihrenheit)
*/

/*
const produtos = ["camisa", "calça", "sapato"]

const maiusculoPrefixo = produtos.map(produto => "Produto: " + produto.toUpperCase())

console.log(maiusculoPrefixo)
*/

/*
const numeros = [1, 2, 3, 4]

const valorAOquadrado = numeros.map(numero => numero ** 2)

console.log(valorAOquadrado)
*/
//-------------------------------------------------------------------------
/*
const valores = [100, 200, 50, 150]

const total = valores.reduce((soma, valore) => soma + valore, 0)

console.log(total)
*/

/*
const palavras = ["JS", "é", "muito", "legal"]

const junto = palavras.reduce((unica, palavra) => unica + palavra + " ","")

console.log(junto)
*/

/*
const numeros = [1, 2, 3, 4, 5]

const media = numeros.reduce((total, numero) => total + numero, 0) / numeros.length

console.log(media)
*/
//-------------------------------------------------------------------------
/*
const livros = [
      { titulo: "Dom Casmurro", paginas: 300 },
      { titulo: "O Hobbit", paginas: 295 },
      { titulo: "A Revolução dos Bichos", paginas: 112 }
    ]

const mais200 = livros.filter(livro => livro.paginas > 200)

console.log(mais200)

const titulos = livros.map(livro => livro.titulo)

console.log(titulos)

const somaP = livros.reduce((total, pagina) => total + pagina.paginas, 0)

console.log(somaP)
*/


/*
const carrinho = [
      { produto: "Notebook", preco: 2500 },
      { produto: "Mouse", preco: 100 },
      { produto: "Teclado", preco: 200 }
    ]

const novoFormato = carrinho.map(formato => "produto: " + formato.produto + " - R$ " + formato.preco)

console.log(novoFormato)

const total = carrinho.reduce((soma, valor) => soma + valor.preco, 0)

console.log(total)

const achar = carrinho.find(mouse => mouse.produto == "Mouse")

console.log(achar)
*/