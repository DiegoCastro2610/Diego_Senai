--DDL
-- APAGAR BASE DE DADOS CASO EXISTA
--DROP DATABASE CLINICAMEDICA


-- CRIAR BASE DE DADOS
CREATE DATABASE Clinica_Medica
GO

USE Clinica_Medica
GO

--TABELA PACIENTE
CREATE TABLE Paciente(
	CPF VARCHAR(14) PRIMARY KEY,
	Nome VARCHAR(40),
	Telefone VARCHAR(30),
	NumeroPlano INT,
	NomePlano VARCHAR(20),
	TipoPlano VARCHAR(10)
)
GO

--TABELA MEDICO
CREATE TABLE Medico (
 CRM INT PRIMARY KEY,
 NomeMedico VARCHAR(30),
 Especialidade VARCHAR(20)
)
GO

--TABELA CONSULTA
CREATE TABLE Consulta(
NumeroConsulta INT PRIMARY KEY IDENTITY(100,1) ,  --INCREMENTA O VALOR INICIAL
DataConsulta DATE ,
HorarioConsulta TIME,
CRM_Medico INT FOREIGN KEY REFERENCES Medico(CRM),
CPF_Paciente VARCHAR(14) FOREIGN KEY REFERENCES Paciente(CPF)
)
GO

SELECT * FROM Paciente
SELECT * FROM Medico
SELECT * FROM Consulta
go


------------------------------------------------------------------------------------------------------------------

--exercicio

insert into Paciente values
('11111111111', 'Pedro Pinto', '2541587514', 158, 'Bradesco','gold'),
('22222222222', 'Zeca Gado', '15482647154', 458, 'Hapvida','platinum'),
('33333333333', 'Oscar Alho', '15481842594', 254, 'SulAmérica','silver'),
('44444444444', 'Paula Tejando', '15482699875', 485, 'Amil','silver'),
('55555555555', 'Diego Castro', '11841548471', 784, 'Unimed','dimond'),
('66666666666', 'Guilherme Ribeiro', '18484547845', 054, 'Notre Dame','bronze')
go

insert into Medico values 
(251485, 'Roberto Castro', 'dermatologista'),
(846471, 'Luiji Berlato', 'Ginegologista'),
(785514, 'Caique Lima', 'coloproctologista'),
(657125, 'Pedro Eduardo', 'ortopedista'),
(425135, 'Augusto da Silva', 'cardiologista')
go

insert into Consulta values
('2025/10/26', '10:30:30', 251485, '44444444444'),
('2025/9/10', '12:50:50', 785514, '55555555555'),
('2025/8/04', '8:25:40', 425135, '33333333333'),
('2025/7/08', '15:40:20', 846471, '66666666666'),
('2025/6/29', '19:00:10', 657125, '11111111111')
go

select * from Paciente
select NomeMedico, Especialidade from Medico
go

select * from Consulta
where CPF_Paciente = 55555555555
go

select * from Consulta
where CRM_Medico = 846471
go

update Paciente
set NumeroPlano = 487
where Nome = 'Pedro Pinto'
go
update Paciente
set NumeroPlano = 069
where Nome = 'Diego Castro'
go
update Paciente
set NumeroPlano = 067
where Nome = 'Guilherme Ribeiro'
go

delete from Paciente
where CPF = '22222222222'
go
delete from Paciente
where CPF = '33333333333'
go

insert into Medico values
(184912, 'Eneias do Pastel', 'otorrinolaringologista'),
(841654, 'robson Castro', 'Pediatra'),
(768754, 'Laurinha do Camarao', 'Radioterapeuta')
go

insert into Paciente values
('77777777777', 'Pedro do grau', '11741717499', 785, 'Uni','wood'),
('88888888888', 'Thiago Morand', '11754974349', 767, 'med','VIP')
go

update Medico
set Especialidade = 'Angiologista'
where CRM = 425135
go
update Medico
set Especialidade = 'Infectologista'
where CRM = 657125
go

--------------------------------------------------------------------------

--join



select C.NumeroConsulta, P.Nome, M.NomeMedico, C.DataConsulta, C.HorarioConsulta
from  Paciente P
inner join Consulta C
on P.CPF = C.CPF_Paciente
inner join Medico M
on M.CRM = C.CRM_Medico
go

select * from sys.tables --saber as tabelas

select * from sys.columns
where object_id = OBJECT_ID('Paciente')

select * from sys.types

select tabelas.name AS tabela, colunas.name AS coluna,
tipo.name AS Tipo, colunas.max_length AS tamanho,
colunas.is_nullable AS permiteNulo
from sys.tables tabelas
join sys.columns colunas ON tabelas.object_id = colunas.object_id
join sys.types tipo ON colunas.user_type_id = tipo.user_type_id
order by tabelas.name, colunas.column_id

select * from INFORMATION_SCHEMA.columns