--InLock DDL

CREATE DATABASE inlock_games_manha
GO

USE inlock_games_manha
GO

CREATE TABLE Estudios(
			 idEstudio			INT PRIMARY KEY IDENTITY
			,nomeEstudio		VARCHAR(200) NOT NULL
)
GO

CREATE TABLE Jogos(
			 idJogo				INT PRIMARY KEY IDENTITY
			,nomeJogo			VARCHAR(200) NOT NULL
			,descricao			VARCHAR(500)
			,dataLancamento		DATE NOT NULL
			,valor				INT NOT NULL
			,idEstudio			INT FOREIGN KEY REFERENCES Estudios(idEstudio)
)
GO

CREATE TABLE TipoUsuario(
			 idTipoUsuario		INT PRIMARY KEY IDENTITY
			,titulo				VARCHAR(100) NOT NULL
)
GO

CREATE TABLE Usuarios(
			 idUsuario			INT PRIMARY KEY IDENTITY
			,email				VARCHAR(100) UNIQUE NOT NULL
			,senha				VARCHAR(20) NOT NULL
			,idTipoUsuario		INT FOREIGN KEY REFERENCES TipoUsuario(idTipoUsuario)
)
GO