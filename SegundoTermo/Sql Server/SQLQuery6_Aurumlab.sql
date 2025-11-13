drop database AurumLab
go

create database AurumLab
go

use AurumLab
go

create table Regra (
IdRegra int identity(1,1) primary key,
Nome varchar(40) not null unique
)
go

create table Usuario (
IdUsuario int identity (1,1) primary key,
NomeCompleto nvarchar(200) not null,
Email nvarchar(150) not null unique,
Senha varbinary(32) not null, -- armazena a hesh da senha
FotoURL nvarchar(500) null, --armazena a url da imagem
CriadoEm datetime2(0) not null default dateadd(hour, -3, sysutcdatetime()), --Zera as casas decimais de segundos
RegraId int not null,
constraint FK_Usuario_Regra foreign key (RegraId) references Regra(IdRegra)
)
go

insert into Regra (Nome) values
('aluno'),
('Professor')

select * from Regra

declare @RegraId int --declarando uma variavel RegraId
set @RegraId =
(select IdRegra from Regra where Nome = 'Aluno')
insert into Usuario (NomeCompleto, Email, Senha, FotoURL, RegraId)
values
('Usuario 1', 'usuario@senai.com', HASHBYTES('SHA2_256', 'senha123'), 'https://sdajwefjwioe.png', @RegraId)
select * from Usuario