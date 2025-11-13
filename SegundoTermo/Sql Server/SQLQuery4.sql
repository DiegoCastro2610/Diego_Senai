drop database Loja

create database Loja
go

use Loja
go

create table Cliente(
ClienteId int identity(100, 1),
Nome Varchar(100) not null,
Email Varchar(100) unique,
constraint Pk_Cliente primary key (ClienteId)
--PK: Primary key(chave primaria)
);
go

Create table Pedido(
PedidoId int identity(100,1),
DataPedido date not null,
valor decimal(10,2),
ClienteId int,
constraint Pk_Pedido Primary key (PedidoId),
constraint Fk_Pedido Foreign key (ClienteId),
references Cliente(ClienteId)
--FK: Foreign key (chave estrangeira)
)

insert into Cliente values -- nome, email
('Thiago Augusto', 'titi@senai.com'),
('Kessia Milena', null),
('Odilei', 'odilei@senai.com')

insert into Pedido values
('2025-10-01', '100.80', 100),
('2025-09-10', '49.99', 100),
('2025-09-23', '350', 101)

select * from Cliente
select * from Pedido

update Cliente set Email = 'kessia@senai.com'
where ClienteId = 101

select * from Pedido
update pedido set valor = valor + '10'
where PedidoId = 101

select * from Pedido

--renomeia a tabela Cliente para funcionario
exec sp_rename 'Cliente', 'Funcionario'

select * from Cliente
select * from Funcionario

-- Renomear a coluna ClienteId para FuncionarioId
exec sp_rename 'Funcionario.ClienteId', 'FuncionarioId', 'column'

--alterar o tamanho do tipo de dado
alter table Funcionario
alter column Nome varchar(150) not null

--ver a estrutura da tabela
exec sp_help 'Funcionario'

--deletar um funcionario
delete Funcionario
where FuncionarioId = 100

--apagando a atributo de chave primaria de PedidoId
alter table Pedido
drop constraint PK_Pedido

select * from Pedido

--Recriando a chave Primaria
alter table Pedido
add constraint PK_Pedido Primary key (PedidoId)

--apagando a atributo de chave secundaria de ClienteId
alter table Pedido
drop constraint FK_Pedido

--recriando a chave secundaria
alter table Pedido
foreign key (ClienteId) references Funcionario(FuncionarioId)
on delete cascade

--deletar um funcionario
delete Funcionario
where FuncionarioId = 105

--adicionar nova coluna 
alter Funcionario
add Cargo varchar(50)

select * from Pedido
