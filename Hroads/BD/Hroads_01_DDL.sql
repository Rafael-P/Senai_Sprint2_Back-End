--DDL Data Definition Language

create database SENAI_HROADS_MANHA;

use SENAI_HROADS_MANHA;

create table TipoHabilidade
(
	idTipoHabilidade	int		primary key		identity
	,Tipo				varchar(20)
);

create table Habilidade
(
	idHabilidade		int		primary key		identity
	,Nome				varchar(30)
	,idTipoHabilidade	int		foreign key		references TipoHabilidade(idTipoHabilidade)
);

create table Classe
(
	idClasse			int		primary key		identity
	,Nome				varchar(50)
);

create table ClasseHabilidade
(
	idClasse			int		foreign key		references Classe(idClasse)
	,idHabilidade		int		foreign key		references Habilidade(idHabilidade)
);

create table Personagem
(
	idPersonagem		int		primary key		identity
	,Nome				varchar(20)
	,Classe				varchar(50)
	,idClasse			int		foreign key		references Classe(idClasse)
	,VidaMax			tinyint
	,ManaMax			tinyint
	,DataDeAtualizacao	varchar(20)
	,DataDeCriacao		varchar(20)
);

CREATE TABLE tipoUsuario
(
	idTipoUsuario		INT PRIMARY KEY IDENTITY
	,tipoUsuario		VARCHAR(50)
);

CREATE TABLE usuario
(
	idUsuario		INT PRIMARY KEY IDENTITY
	,email			VARCHAR(50)
	,senha			VARCHAR(50)
	,idTipoUsuario	INT FOREIGN KEY REFERENCES tipoUsuario(idTipoUsuario)
);