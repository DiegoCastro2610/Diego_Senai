select titulo from Livro

select AVG(ano) as ano_medio from Livro 

select * from Emprestimo
select l.nome, count(e.id_Emprestimo) as mais_emprestimo 
from Emprestimo e join Leitor l on l.id_Leitor = e.id_Leitor
group by l.nome

----------------------------------------------------------------------
select left (nome, 1) from Autor

select LOWER(titulo) from Livro

select nome, email from Leitor
where right (email, 4) = '.com'

select a.nome, REPLACE(l.titulo, 'estrela', 'sol') from Livro l
join Autor a on a.id_Autor = l.id_Autor
where a.nome = 'Clarice Lispector'

---------------------------------------------------------------------