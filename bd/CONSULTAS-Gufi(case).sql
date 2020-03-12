-- Cria o banco de dados com o nome Gufi
--DDL
CREATE DATABASE Gufi_Manha;
GO

-- Define o banco de dados que será utilizado
USE Gufi_Manha;
GO

-- Criação das tabelas
CREATE TABLE TipoUsuario (
	IdTipoUsuario INT PRIMARY KEY IDENTITY
	,TituloTipoUsuario VARCHAR (255) NOT NULL UNIQUE
);
GO

CREATE TABLE TipoEvento (
	IdTipoEvento INT PRIMARY KEY IDENTITY
	,TituloTipoEvento VARCHAR (255) NOT NULL UNIQUE
);
GO

CREATE TABLE Instituicao (
	IdInstituicao INT PRIMARY KEY IDENTITY
	,CNPJ CHAR(14) NOT NULL UNIQUE
	,NomeFantasia VARCHAR (255) NOT NULL UNIQUE
	,Endereco VARCHAR (255) NOT NULL UNIQUE
);
GO

CREATE TABLE Usuario (
	IdUsuario INT PRIMARY KEY IDENTITY
	,Nome VARCHAR (255) NOT NULL
	,Email VARCHAR (255) NOT NULL UNIQUE
	,Senha VARCHAR (255) NOT NULL
	,DataCadastro DATETIME2 
	,Genero VARCHAR (255)
	,IdTipousuario INT FOREIGN KEY REFERENCES TipoUsuario (IdTipoUsuario)
);
GO

CREATE TABLE Evento (
	IdEvento INT PRIMARY KEY IDENTITY
	,NomeEvento VARCHAR (255) NOT NULL
	,DataEvento DATETIME2 NOT NULL
	,Descricao VARCHAR (255) NOT NULL
	,AcessoLivre BIT DEFAULT (1) NOT NULL
	,IdInstituicao INT FOREIGN KEY REFERENCES Instituicao (IdInstituicao)
	,IdTipoEvento INT FOREIGN KEY REFERENCES TipoEvento (IdTipoEvento)
);
GO

CREATE TABLE Presenca (
	IdPresenca INT PRIMARY KEY IDENTITY
	,IdUsuario INT FOREIGN KEY REFERENCES Usuario (IdUsuario)
	,IdEvento INT FOREIGN KEY REFERENCES Evento (IdEvento)
	,Situacao VARCHAR (255) NOT NULL
);
GO
--DML
INSERT INTO TipoUsuario (TituloTipoUsuario)
VALUES	('Admnistrador'),('Comum');

INSERT INTO TipoEvento (TituloTipoEvento)
VALUES ('C#'),('React'),('SQL');

INSERT INTO Instituicao (CNPJ,NomeFantasia,Endereco)
VALUES ('11111111111111','Escola SENAI de Inforática','Alameda Barão de Limeira,583');

INSERT INTO Usuario (IdTipousuario,Nome,Email,Senha,DataCadastro)
VALUES (1,'Administrador','adm@adm.com','adm123','06/02/2020'),
	   (2,'Carol','carol@email.com','carol123','06/02/2020'),
	   (2,'Saulo','saulo@email.com','saulo123','06/02/2020');

INSERT INTO Evento (IdTipoEvento,IdInstituicao, NomeEvento, AcessoLivre, DataEvento, Descricao)
VALUES (7,1,'Orientação a objetos',1,'07/02/2020','Conceitos sobre os pilares da programação orientada a objetos'),
	   (8,1,'Ciclo de vida',0,'08/02/2020','Como utilizar os ciclos de vida com a biblioteca ReactJs'),
	   (9,1,'Introdução a SQL',1,'09/02/2020','Comandos básicos utilizando SQL Server');

INSERT INTO Presenca (idUsuario,idEvento,Situacao)
VALUES (2,7,'Confirmada'),
	   (2,8,'Não confirmada'),
	   (3,6,'Confirmada');

DELETE FROM TipoEvento
WHERE TiTuloTipoEvento = ('C#')

DELETE FROM TipoEvento
WHERE TiTuloTipoEvento = ('React')

DELETE FROM TipoEvento
WHERE TiTuloTipoEvento = ('SQL')


SElECT Nome,Email,Senha,DataCadastro,Genero, TipoUsuario.TituloTipoUsuario FROM Usuario
INNER JOIN TipoUsuario ON Usuario.IdTipousuario = TipoUsuario.IdTipoUsuario

SELECT CNPJ,NomeFantasia,Endereco FROM Instituicao;

SELECT TituloTipoEvento FROM TipoEvento;

SELECT NomeEvento,DataEvento,AcessoLivre,Descricao, Instituicao.Endereco,Instituicao.CNPJ,Instituicao.NomeFantasia,TipoEvento.TituloTipoEvento FROM Evento
INNER JOIN Instituicao ON Evento.IdInstituicao = Instituicao.IdInstituicao
INNER JOIN TipoEvento ON Evento.IdTipoEvento = TipoEvento.IdTipoEvento;

SELECT NomeEvento,TipoEvento.TituloTipoEvento,DataEvento,AcessoLivre,Descricao,Instituicao.CNPJ,Instituicao.Endereco,Instituicao.NomeFantasia 
FROM Evento 
INNER JOIN Instituicao ON Evento.IdInstituicao = Instituicao.IdInstituicao
INNER JOIN TipoEvento ON Evento.IdTipoEvento = TipoEvento.IdTipoEvento
WHERE AcessoLivre = 1;

SELECT NomeEvento,TipoEvento.TituloTipoEvento,DataEvento,AcessoLivre,Descricao,Instituicao.CNPJ,Instituicao.Endereco,Instituicao.NomeFantasia,
Usuario.DataCadastro,Usuario.Email,Usuario.Genero,Usuario.Nome,Usuario.Senha FROM Evento 
INNER JOIN TipoEvento ON TipoEvento.IdTipoEvento = Evento.IdTipoEvento
INNER JOIN Instituicao ON Instituicao.IdInstituicao = Evento.IdInstituicao
INNER JOIN Presenca ON Presenca.IdEvento = Evento.IdEvento
INNER JOIN Usuario ON Usuario.IdUsuario = Presenca.IdUsuario
WHERE Usuario.Nome = 'Carol'AND Situacao = 'Confirmada';

--EXTRAS 
SELECT  NomeEvento,DataEvento,Descricao,
CASE AcessoLivre
	WHEN 1 THEN 'Publico'
	WHEN 0 THEN 'Privado'
END AcessoLivre 
FROM Evento




--DQL
SELECT * FROM TipoUsuario;
SELECT * FROM Evento;
SELECT * FROM Usuario;
SELECT * FROM TipoEvento;
SELECT * FROM Instituicao;
SELECT * FROM Presenca;

