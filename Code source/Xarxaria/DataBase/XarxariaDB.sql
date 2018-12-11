-- Création de la base des données
CREATE DATABASE XarxariaDB;

USE XarxariaDB;

-- Création des tables
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
	image VARCHAR(255)
)

CREATE TABLE Player (
	id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	pv INT,
	force INT,
	armor INT,
	agility INT,
	name VARCHAR(255),
	idActualPage INT FOREIGN KEY REFERENCES Page(id),
	idInventory INT FOREIGN KEY REFERENCES Inventory(id)
)

-- Insertion des données --
USE XarxariaDB

INSERT INTO Page (title, text, image) VALUES
('Introduction', 'Aller a la page deux - <2> stp', '\..\..\DataBase\images\paysage_01.jpg'),
('Désintroduction', 'Aller a la page une - <1> stp', '\..\..\DataBase\images\paysageAvecPortail_01.jpg');

INSERT INTO Inventory(goldenCoin) VALUES (18);

INSERT INTO Player (pv, force, armor, agility, name, idActualPage, idInventory) VALUES (10, 3, 1, 5, 'Godfroyd', 2, 1);

-- Modification des données (temporaire)
/*use XarxariaDB;
update Page set image = '\..\..\DataBase\images\paysage_01.jpg' where id = 1;
update Page set image = '\..\..\DataBase\images\paysageAvecPortail_01.jpg' where id = 2;
select * from Page;*/