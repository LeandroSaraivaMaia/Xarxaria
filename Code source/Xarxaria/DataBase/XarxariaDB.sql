-- Cr�ation de la base des donn�es
CREATE DATABASE XarxariaDB;

USE XarxariaDB;

-- Cr�ation des tables
CREATE TABLE Enemy (
	id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	pv INT,
	force INT,
	armor INT,
	agility INT,
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
	image image
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

-- Insertion des donn�es --
USE XarxariaDB

INSERT INTO Page (title, text) VALUES
('Introduction', 'Aller a la page deux - <2> stp'),
('D�sintroduction', 'Aller a la page une - <1> stp');

INSERT INTO Inventory(goldenCoin) VALUES (18);

INSERT INTO Player (pv, force, armor, agility, name, idActualPage, idInventory) VALUES (10, 3, 1, 5, 'Godfroyd', 2, 1);