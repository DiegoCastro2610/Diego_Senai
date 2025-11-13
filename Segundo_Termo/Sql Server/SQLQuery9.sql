--trigger

--trigger 1: Auditoria Cliente Inseridos
create table Auditoria_Cliente(
AuditoriaId int identity primary key,
ClienteId int foreign key references Cliente(ClienteId),
DataInsercao date
);

create trigger trg_AuditoriaCliente
on Cliente -- tabela que vai disparar o trigger
after insert
as
begin
	set nocount on
	insert into Auditoria_Cliente (ClienteId, DataInsercao)
	select ClienteId, dateadd(hour, -3, SYSUTCDATETIME())
	from inserted
	--Armazena insert e update de forma temporaria
end

--testando trigger:
insert into Cliente(Nome, Sobrenome, Email, Telefone, DataCadastro)
values
('Carlos', 'pereira', 'carlos@email.com', '11999999999', '2025-10-14')

select * from Auditoria_Cliente
select * from Cliente

--trigger 2: atualizar estoque ao inserir um pedido
create trigger trg_AtualizarEstoque
on DetalhesPedido
after insert
as
begin
	set nocount on
	update Produto
	set QuantidadeEstoque = QuantidadeEstoque - i.Quantidade
	from Produto p
	join inserted i on p.ProdutoID = i.ProdutoID
end

--testando trigger
select * from Produto
select * from Pedido

insert into DetalhesPedido (PedidoID, ProdutoID, Quantidade, PrecoUnitario)
values (1, 2, 3 ,75.00)

-- Trigger 3: Prevenir exclusao de produto com pedido
create trigger trg_PrevenirExclusaoProdutos
on Produto
instead of delete -- ao inves de deletar
as
begin
	set nocount on
	if exists (
		select 1
		from DetalhesPedido dp
		join deleted d on dp.ProdutoID = d.ProdutoID
	)
	begin
		raiserror('nao e possivel excluir produto com pedidos associado', 16, 1)
		--cod de erro do usuario
	end

	delete from Produto
	where ProdutoID in (select ProdutoID from deleted)
end

--testando trigger
delete from Produto Where ProdutoID = 2

-- trigger 4: Criar log de funcionarios
create table Funcionario(
FuncionarioId int identity primary key,
Nome varchar(100),
CPF varchar(14) unique
)

create table logFuncionario(
LogId int identity primary key,
FuncionarioId int foreign key References Funcionario(FuncionarioId),
Nome varchar(100),
DataCadastro datetime2(0) default dateadd(hour, -3, sysutcdatetime())
)

create trigger trg_LogFuncionario
on Funcionario
after insert
as
begin
	set nocount on
	insert into LogFuncionario(FuncionarioId,nome)
	select FuncionarioId, Nome
	from inserted
end

insert into funcionario (Nome, CPF)
values ('kessia', '13312548555')

select * from Funcionario

Select * from LogFuncionario