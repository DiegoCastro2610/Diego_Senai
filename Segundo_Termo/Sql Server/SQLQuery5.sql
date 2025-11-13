-- cunt: contar o total de registros

select * from Leitor

select count(*) AS QtdLeitoes
from Leitor

select * from Emprestimo
--count + group by
--(funcao agregada presisa do group by para adicionar outros atributos)
select l.nome, count(e.id_emprestimo) as QtdEmprestimo
from Emprestimo e
join Leitor l on l.id_Leitor = e.id_Leitor
group by l.nome

--min/max
select Ano from Livro

select min(Ano) as MenorAno from Livro
select max(Ano) as MaiorAno from Livro

--funcoes de texto
--len

select len('Kessia') as tamanhoString
select nome, len(nome) from Autor

--upper(maiusculo) / lower (minusculo)
select upper(nome) from Leitor
select lower(email) from Leitor

--left (esquerda) / right (direita)
--pega as letras a aesquerda e direita
select * from Livro

select left(titulo, 5) as Primeiros5 from Livro
select right(titulo, 5) as Ultimos5 from Livro

--replace
--trocar caracteres
select * from Livro

--replace(nome_atributo, valorinicial, valorfinal)
select replace(titulo, 'Harry', 'Hermione')
from Livro

--charindex
--localizar a posicao de algumas palavras

select titulo, CHARINDEX('uma', titulo) as PosicaoTexto
from Livro

--concat
--concatenar textos
--select e.id_Emprestimo, le.nome, li.titulo

select concat('Emprestimo ', e.id_Emprestimo ,
'- Leitor: ', le.nome, '- Livro: ',li.titulo)
from Emprestimo e
join Leitor le on le.id_Leitor = e.id_Leitor
join Livro li on li.id_Livro = e.id_Livro

--substring
--mostra o texto conforme o tamanho passado
select SUBSTRING(titulo, 1, 10)
from Livro

--Rtrim/ ltrim/ trim
select Nome, rtrim(nome), ltrim(nome), trim(nome)
from Leitor

--funcoes de Data e Hora

--getdate
--dia e horario atual da estancia que esta sendo execultado
select getdate()

select SYSDATETIMEOFFSET()
at time zone 'E. South America Standard Time'

--DATEADD
--Adiciona um tempo a mais dentro de uma data
--YEAR: ano, MONTH: mes, DAY: dia, WEEK: semana

SELECT id_Emprestimo, data_emprestimo,
DATEADD(YEAR, 7, data_emprestimo) AS PrevisaoDevolucao
FROM Emprestimo

--Diminuir o tempo
SELECT id_Emprestimo, data_emprestimo,
DATEADD(YEAR, -1, data_emprestimo) AS PrevisaoDevolucao
FROM Emprestimo


--DATEDIFF: diferenca de datas
SELECT id_emprestimo, data_emprestimo, data_devolucao,
DATEDIFF(DAY, data_emprestimo, ISNULL(data_devolucao, GETDATE()))
AS DiasComLivro
FROM Emprestimo

--se data_devolucao estiver vazia, ele acrescenta o GETDATE para inserir a data anual e comparar com a data emprestimo.
 
--extrair ano, mes e dia de uma data
select data_emprestimo,
year(data_emprestimo) as Ano,
month(data_emprestimo) as Mes,
day(data_emprestimo) as Dia,
from Emprestimo

set language Portuguese --mostra o retorno em portugues

--datepart / datename8
select datepart(year, data_emprestimo) as Ano,
	   datepart(weekday, data_emprestimo) as DiaSemana,
	   datename(weekday, data_emprestimo) as NomeDiaSemana,
	   datename(month, data_emprestimo) as NomeMes
from Emprestimo

-- Operadores de comparacao

--(igualdade) =



--(diferente) not like
select nome, email
from Leitor
where email not like 'kes%'

select titulo, ano
from Livro
where ano <> 2000

select titulo, ano
from Livro
where ano != 2000

--(maior que) >
select titulo, ano
from Livro
where ano > 1900

--(menor que) <
select titulo, ano
from Livro
where ano < 1900

--(maior ou igual) >=
select id_emprestimo, data_emprestimo
from Emprestimo
where data_emprestimo >= '2025-09-01'

--(menor ou igual) <=
select id_emprestimo, data_emprestimo
from Emprestimo
where data_emprestimo <= '2025-08-31'

--Operadores Logicos

--and (E)
select emprestimo.id_Emprestimo, leitor.nome,
emprestimo.data_emprestimo, emprestimo.data_devolicao
from Emprestimo
join Leitor on leitor.id_Leitor = Emprestimo.id_Leitor
where MONTH(emprestimo.data_emprestimo) = 9
and year(emprestimo.data_emprestimo) = 2026
-- duas condicoes precisam ser verdadeiras

select * from Emprestimo

-- or (ou)
select l.titulo, l.ano, a.nome
from Livro l
join Autor a on a.id_Autor = l.id_Autor
where a.nome = 'Machado de Assis'
or a.nome = 'Clarice Lispector'
--uma condicao sendo verdadeira, ja retorna o valor

--not (negacao)
select l.titulo, l.ano, a.nome
from Livro l
join Autor a on a.id_Autor = l.id_Autor
where not a.nome = 'Shakespeare'

--operadores Especiais

--between (entre)
select titulo, ano
from Livro
where ano between 1900 and 2000

-- in (verifica uma lista de valores
select * from Autor
where nome in ('Machado de Assis','Shakespeare')

-- like
select titulo
from Livro
where titulo like '%O%'
--porsentagem antes da letra - existe texto antes daquela letra
--porcentagem depois da letra - existe texto depois daquela letra
--porcentagem ante e depois da letra - existe texto tanto antes e depois daquela letra

--is null
--retorna registros vazios
select id_Emprestimo, id_livro, data_emprestimo
from Emprestimo
where data_devolucao is not null