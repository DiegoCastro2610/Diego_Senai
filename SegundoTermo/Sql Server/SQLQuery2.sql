create database Secretaria

use Secretaria

create table Aluno(
IdAluno int primary key,
Nome nvarchar(100),
Idade int,
Cidade nvarchar(100)
);

insert into Aluno values (1, 'Carlos Pinto', 21, 'Pal Preto'),
(2, 'Diego Castro', 17, 'Santo Andre'),
(3, 'Alexandra Beatriz', 17, 'Santo Andre'),
(4, 'Augusto Silva', 15, 'Sao Paulo'),
(5, 'Rafael Eloia', 18, 'xique-xique');

select * from Aluno;

select * from Aluno
where Idade > 20

select * from Aluno
where Cidade = 'Sao Paulo'

-------------------------------------------------------------------------

create database GameStore

use GameStore

create table Jogo(
IdJogo int primary key,
Titulo nvarchar(100),
Genero nvarchar(100),
Preco float
);

insert into Jogo values (1, 'Free Fire', 'Battle Royale', 0.00),
(2, 'Fortnite', 'Battle Royale', 50.00),
(3, 'Outlast', 'Terror', 14.50),
(4, 'Minecraft', 'Sendbox', 99.00),
(5, 'God of War', 'Acao', 45.95),
(6, 'Brawl Stars', 'MOBA', 210.85)

select * from Jogo
where Genero = 'Acao'

select * from Jogo
where Preco > 200

select Titulo, Preco from Jogo

--------------------------------------------------------------------------

create database BibiliotecaVirtual

use BibiliotecaVirtual

create table livro(
IdLivro int primary key,
Titulo nvarchar(100),
Autor nvarchar(100),
AnoPublicacao int
);

insert into Livro values (1, 'Pequeno Princepe', 'Antoine de Saint-Exupéry', 1943),
(2, 'Diario de um Banana', 'Jeff Kinney', 2007),
(3, 'O diário perdido de Gravity falls', ' Alex Hirsch', 2020),
(4, 'Harry Potter e a Pedra Filosofal', 'J. K. Rowling', 1997),
(5, 'O Senhor dos Anéis', 'J. R. R. Tolkien', 1954)

select * from Livro
where AnoPublicacao > 2010

select * from Livro
where Autor = 'Jeff Kinney'

select Titulo from Livro

--------------------------------------------------------------------------------

create database Cadastro

use Cadastro

create table Funcionario(
IdFunc int primary key,
Nome nvarchar(100),
Cargo nvarchar(100),
Salario float
);

insert into Funcionario values (1, 'Carlos Henrique', 'Pedreiro', 2500),
(2, 'Pedro Pinto', 'Padeiro', 99.99),
(3, 'Diego Castro', 'engenheiro de computadores', 700000),
(4, 'Guilherme Ribeiro', 'cientista de computadores', 750000),
(5, 'Luigi Berlato', 'cientista de computadores', 10000000.01)

select * from Funcionario
where Salario > 3000

select * from Funcionario
where Cargo = 'cientista de computadores'

select Nome, Cargo from Funcionario

----------------------------------------------------------------------------------------

create database SistemaPedidos

use SistemaPedidos

create table Pedido(
IdFunc int primary key,
Cliente nvarchar(100),
Produto nvarchar(100),
Quantidade int
);

insert into Pedido values (1, 'Carlos Henrique', 'teclado', 25),
(2, 'Pedro Pinto', 'mouse', 10),
(3, 'Diego Castro', 'placa de video', 7000),
(4, 'Guilherme Ribeiro', 'notebook', 4),
(5, 'Luigi Berlato', 'geladeira', 2),
(6, 'Rafael Eloia', 'airfrayer', 10000000)

select * from Pedido
where Cliente = 'Diego Castro'

select * from Pedido
where Produto = 'mouse'

select Cliente, Quantidade from Pedido