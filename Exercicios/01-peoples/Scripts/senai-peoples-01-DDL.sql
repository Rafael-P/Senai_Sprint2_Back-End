--DDL

--cria um banco de dados chamado M_Peoples
CREATE DATABASE M_Peoples
GO

--define o banco que sera utilizado
USE M_Peoples
GO

--cria uma tabela chamada Funcionarios 
CREATE TABLE Funcionarios
(
	idFuncionario		INT		PRIMARY KEY		IDENTITY
	,nome				VARCHAR(50)		NOT NULL
	,sobrenome			VARCHAR(50)		NOT NULL
)
GO