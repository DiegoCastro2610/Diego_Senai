drop database Clinica_Medica;

create database clinica_Medica;
go

use Clinica_Medica
go

create table Paciente(
CPF varchar(14) primary key,
Nome varchar(40),
Telefone varchar(30),
NumeroPlano int,
NomePlano varchar(20),
TipoPlano varchar(10)
);
go

create table Medico(
CRM int primary key,
NomeMedico varchar(30),
especialidade varchar(20)
);
go

create table Consulta(
NumeroConsulta int primary key identity(100, 1),--(valor inicial, incremento)
DataConsulta date,
HorarioConsulta time,
CRM_Medico int foreign key references Medico(CRM),--Chave estrangeira
CPF varchar(14) foreign key references Paciente(CPF)
);
go
