-- Création de la base des donn�es
CREATE DATABASE XarxariaDB;
GO

USE XarxariaDB;

-- Création des tables
CREATE TABLE Enemy (
	id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	pv INT,
	force INT,
	armor INT,
	agility INT,
	luck INT,
	name VARCHAR(255),
)

CREATE TABLE Inventory (
	id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	goldenCoin INT
)

CREATE TABLE Page (
	id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	title VARCHAR(255),
	text text,
	image VARCHAR(255)
)

CREATE TABLE Player (
	id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	pv INT,
	force INT,
	armor INT,
	agility INT,
	luck INT,
	name VARCHAR(255),
	idActualPage INT FOREIGN KEY REFERENCES Page(id),
	idInventory INT FOREIGN KEY REFERENCES Inventory(id)
)