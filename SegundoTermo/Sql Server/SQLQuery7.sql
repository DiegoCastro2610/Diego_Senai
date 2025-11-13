-- BANCO DE DADOS - Vendas Online
CREATE DATABASE VendasOnline;
GO
USE VendasOnline;
GO

CREATE TABLE StatusPedido (
    StatusId INT IDENTITY(1,1) PRIMARY KEY,
    Nome     VARCHAR(40) NOT NULL
);
GO

CREATE TABLE Categoria (
    CategoriaID INT IDENTITY(1,1) PRIMARY KEY,
    Nome        VARCHAR(60) NOT NULL
);

GO

CREATE TABLE Cliente (
    ClienteID    INT IDENTITY(1,1) PRIMARY KEY,
    Nome         VARCHAR(50) NOT NULL,
    Sobrenome    VARCHAR(50) NOT NULL,
    Email        VARCHAR(100) UNIQUE,
    Telefone     VARCHAR(20),
    DataCadastro DATE NOT NULL DEFAULT DATEADD(HOUR, -3, SYSUTCDATETIME())
);

GO

CREATE TABLE Produto (
    ProdutoID          INT IDENTITY(1,1) PRIMARY KEY,
    CategoriaID        INT NOT NULL,
    Nome               VARCHAR(120) NOT NULL,
    Preco              DECIMAL(10,2) NOT NULL CHECK (Preco >= 0),
    QuantidadeEstoque  INT NOT NULL CHECK (QuantidadeEstoque >= 0),
    CONSTRAINT FK_Produto_Categoria FOREIGN KEY (CategoriaID) REFERENCES Categoria(CategoriaID)
);

GO

CREATE TABLE Pedido (
    PedidoID    INT IDENTITY(1,1) PRIMARY KEY,
    ClienteID   INT NOT NULL,
    DataPedido  DATE NOT NULL DEFAULT DATEADD(HOUR, -3, SYSUTCDATETIME()),
    ValorTotal  DECIMAL(10,2) NOT NULL DEFAULT 0,
    StatusID    INT NOT NULL,
    CONSTRAINT FK_Pedido_Cliente FOREIGN KEY (ClienteID) REFERENCES Cliente(ClienteID),
    CONSTRAINT FK_Pedido_Status  FOREIGN KEY (StatusID)  REFERENCES StatusPedido(StatusId)
);

GO

CREATE TABLE DetalhesPedido (
    DetalheID     INT IDENTITY(1,1) PRIMARY KEY,
    PedidoID      INT NOT NULL,
    ProdutoID     INT NOT NULL,
    Quantidade    INT NOT NULL CHECK (Quantidade > 0),
    PrecoUnitario DECIMAL(10,2) NOT NULL CHECK (PrecoUnitario >= 0),
    CONSTRAINT FK_Detalhes_Pedido  FOREIGN KEY (PedidoID)  REFERENCES Pedido(PedidoID),
    CONSTRAINT FK_Detalhes_Produto FOREIGN KEY (ProdutoID) REFERENCES Produto(ProdutoID)
);

GO

-- INSERINDO DADOS

INSERT INTO StatusPedido (Nome) VALUES 
('Novo'), 
('Enviado'), 
('Cancelado');

GO

INSERT INTO Categoria (Nome) VALUES 
('Informática'), 
('Acessórios');

GO

INSERT INTO Cliente (Nome, Sobrenome, Email, Telefone, DataCadastro) VALUES
('João', 'Silva', 'joao@email.com', '11999999999', '2025-04-09');
GO

INSERT INTO Produto (CategoriaID, Nome, Preco, QuantidadeEstoque) VALUES
(1, 'Notebook X', 4500.00, 10),
(2, 'Mouse Óptico', 50.00, 100);
GO

-----------------------------------------------------------------------------------------------------------

--procedures

-- procedure 1: Inserir Cliente
create procedure InserirCliente
    @Nome varchar(50),
    @Sobrenome varchar(50),
    @Email varchar(100),
    @Telefone varchar(20),
    @DataCadastro date
as
begin
    set nocount on -- desativa as linhas afetadas no procedures
    insert into Cliente(Nome, Sobrenome, Email, Telefone, DataCadastro)
    values (@Nome, @Sobrenome, @Email, @Telefone, @DataCadastro)
end

exec InserirCliente
'Ana', 'Souza', 'ana@email.com', '119999999999', '2025-10-13'

select * from Cliente

--Procedure 2 : inserir pedido
Create procedure InserirPedido2
    @ClienteId int,
    @DataPedido date,
    @ValorTotal decimal(10, 2),
    @StatusId int
as
begin
    set nocount on
    insert into Pedido (ClienteId, DataPedido, ValorTotal, StatusId)
    values (@ClienteId, @DataPedido, @ValorTotal, @StatusId)
end

--Testando Procedure
exec InserirPedido2
1,'2025-10-13', 250.00, 1

select * from Pedido

-- Procedure 3: Atualizar preço de produto
CREATE PROCEDURE AtualizarPrecoProduto
	@ProdutoId INT,
	@PercentualAumento DECIMAL(5,2)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE Produto
		SET Preco = Preco * (1 + @PercentualAumento / 100.0)
	WHERE ProdutoID = @ProdutoId;
END

-- TESTANDO PROCEDURE
SELECT * FROM Produto;
EXEC AtualizarPrecoProduto 2, 10;
SELECT * FROM Produto;

--produce 4: total de vendas por cliente (saida)
create procedure ObterTotalVendas
    @ClienteId int,
    @TotalVendas decimal(10,2) output
as
begin
    set nocount on
    select @TotalVendas = coalesce(sum(ValorTotal),0)
    --substitui valores nulos por zero
    from Pedido
    where ClienteId = @ClienteId
end

drop procedure ObterTotalVendas

--Testando procedure
declare @Total decimal(10,2)
exec ObterTotalVendas 2, @Total output
select @Total as TotalDeVendas

select * from Pedido
where ClienteID = 1

--Procedure 5: Relatorio de Vendas por Cliente
create procedure VendasPorCliente
    @DataLimite date
as
begin
    select C.ClienteId, C.Nome,
    sum(D.Quantidade * D.PrecoUnitario) as TotalGasto
    from Cliente C
    join Pedido P on P.ClienteId = C.ClienteId
    join DetalhesPedido D on D.PedidoId = P.PedidoId
    where P.DataPedido < @DataLimite
    group by C.ClienteId, C.Nome
end

--Testando Procedure
insert into DetalhesPedido (PedidoId, ProdutoId, Quantidade, PrecoUnitario)
values (1, 1, 1, 4500.00)

select * from Pedido

exec VendasPorCliente '2025-10-14'

--procedure 6 historico de precos 
create procedure AtualizarPrecoProdutoComHistorico
    @ProdutoId int,
    @NovoPreco decimal(10,2)
as
begin
    set nocount on
    declare @PrecoAntigo decimal(10,2)

    select @PrecoAntigo = Preco
    from Produto
    where ProdutoId = @ProdutoId

    update Produto set Preco = @NovoPreco
    where ProdutoId = @ProdutoId

    insert into HistoricoPrecos
    (ProdutoId, PrecoAntigo, PrecoNovo, DataModificacao)
    values (@ProdutoId, @PrecoAntigo, @NovoPreco, dateadd(hour, -3, sysutcdatetime()))
end
    