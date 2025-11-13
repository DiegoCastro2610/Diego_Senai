const elForm = document.getElementById('form-tarefa')//atribue a variavel o que tem na tag do id form-tarefa e seus filhos

const elTitulo = document.querySelector('#titulo')//atribue a variavel o que tem na tag do id titulo e seus filhos(input)

const elFiltroStatus = document.querySelector('#filtro-status')//atribue a variavel o que tem na tag do id filtro-status e seus filhos

const elFiltroBusca = document.querySelector('#filtro-busca')//atribue a variavel o que tem na tag do id filtro-busca e seus filhos

const elLista = document.querySelector('#lista-tarefas')//atribue a variavel o que tem na tag do id lista-tarefas e seus filhos

const elVazio = document.querySelector('#vazio')//atribue a variavel o que tem na tag do id vazio e seus filhos

let tarefas = [
    {id: 1, titulo: "Estudar DOM", status: "pendente"},
    {id: 2, titulo: "Criar to-do-list", status: "andamento"},
    {id: 3, titulo: "Praticar JavaScript", status: "concluida"}
]//criando um objeto tarefa para a lista de tarefas


elForm.addEventListener('submit', function(e) {
    //letra "e" na funcao: e uma referencia ao objeto de evento que o navegador cria sempre que algo acontece
    e.preventDefault();
    const titulo = elTitulo.value.trim();//tira os espacos do eltitulo e value atribue somente o que a acao nao toda a tag

    if(!titulo) return;//se nao tiver nada ele vai encerrar a funcao

    const nova = {
        id: Date.now(),
         titulo: titulo,
          status: "pendente"
        };

    tarefas.push(nova);

    elTitulo.value = "";

    render()

})//o addEventListener espera algo acontecer no form-tarefa podendo ser um submit como no exemplo


function render() {
    const termo = elFiltroBusca.value.toLowerCase();//vai atribuir a variavel termo a acao em letra minuscula

    const filtro = elFiltroStatus.value;//vai atribuir a variavel filtro a acao nao a tag toda

    const filtradas = tarefas.filter(function(tarefa) {

        const okStatus = filtro === "todas" ? true : tarefa.status === filtro;

        const okBusca = termo ? tarefa.titulo.toLowerCase().includes(termo) : true

        return okBusca && okStatus;
    })

    elLista.innerHTML = "";

    filtradas.forEach(function(t){

        const li = document.createElement('li');

        li.className = "tarefa " + t.status;
        li.dataset.id = t.id;

        const h3 = document.createElement('h3');

        h3.textContent = t.titulo;

        const acoes = document.createElement('div');
        acoes.className = "acao";

        const check = document.createElement('input');
        check.type = "checkbox";
        check.checked = t.status === "concluida";

        check.addEventListener('change', function(){
            t.status = check.checked ? "concluida" : "pendente";
            render();
        })
 
        const select = document.createElement('select')
        const listaSelect = ["pendente", "andamento", "concluida"]

        listaSelect.forEach(function(status) {
            const option = document.createElement('option');
            option.value = status;

            option.textContent = status.charAt(0).toUpperCase() + status.slice(1).toLowerCase();//charAt pega a primeira letra e o upperCase  tranforma ela em maiuscula

            if(t.status === status) option.selected = true;

            select.appendChild(option);
        })

        select.addEventListener('change', function() {
            t.status = select.value;
            render();
        })

        const botao = document.createElement('button');
        botao.textContent = "X";
        botao.className = "remover";

        botao.addEventListener('click', function() {
            tarefas = tarefas.filter(apagar => apagar.id !== t.id);
            render();
            
        })

        acoes.appendChild(check);
        acoes.appendChild(select);
        acoes.appendChild(botao);

        li.appendChild(h3);
        li.appendChild(acoes);

        elLista.appendChild(li);

    })

    elVazio.style.display = filtradas.length ? "none" : "block";

}

elFiltroStatus.addEventListener('change', render);

elFiltroBusca.addEventListener('input', render);

render()