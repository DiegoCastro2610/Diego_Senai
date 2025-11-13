let input = document.querySelector('.texto')
let button = document.querySelector('.buscar')
let section = document.querySelector('.informacao')
var gen = 0






button.addEventListener('click', function (evento) {
    evento.preventDefault()
    var texto = input.value
    API(texto)
})




async function API(texto) {
    let verificaoDeDuasPalavras = texto.split(' ')

    texto = verificaoDeDuasPalavras.join('-')

    const resposta = await fetch('https://pokeapi.co/api/v2/pokemon/' + texto)

    if (resposta.status === 200) {
        const obj = await resposta.json()
        if (obj.id >= 0 && obj.id <= 151) {
            gen = 1
        }
        else if (obj.id >= 152 && obj.id <= 251) {
            gen = 2
        }
        else if (obj.id >= 252 && obj.id <= 386) {
            gen = 3
        }
        else if (obj.id >= 387 && obj.id <= 493) {
            gen = 4
        }
        else if (obj.id >= 494 && obj.id <= 649) {
            gen = 5
        }
        else if (obj.id >= 650 && obj.id <= 721) {
            gen = 6
        }
        else if (obj.id >= 722 && obj.id <= 809) {
            gen = 7
        }
        else if (obj.id >= 810 && obj.id <= 905) {
            gen = 8
        }
        else if (obj.id >= 906 && obj.id <= 1025) {
            gen = 9
        }

        let id = obj.id
        let name = obj.name
        const urlImagem = obj.sprites.other.dream_world.front_default

        let nova = document.createElement('div')
        let textoinfo = document.createElement('p')
        let imagem = document.createElement('img')

        textoinfo.textContent = name + " | " + "Numero:" + id + " | " + "Geracao:" + gen
        imagem.src = urlImagem
        imagem.className = "imagem"
        imagem.alt = `Imagem do Pokemon ${name}`

        nova.appendChild(textoinfo)
        nova.appendChild(imagem)
        section.appendChild(nova)

    }


    else {
        alert("pokemon nao encontrado")
    }

}

