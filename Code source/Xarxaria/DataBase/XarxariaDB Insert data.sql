-- Insertion des donn�es --
USE XarxariaDB

INSERT INTO Page (title, text, image) VALUES
('Introduction', 'Test des différents actions <0,Cliquez ici pour change de page,2>
Liste des actions :
0 Changement de page
1 Ajouter un objet
2 Supprimer un objet
3 Modifier les pv
4 Modifier la force
5 Modifier l armure
6 Modifier l agilité
7 Modifier la chance

<1,Ajouter 3 pièces d or,0;3>
<2,Supprimer 2 pièces d or,0;2>
<3,Gagner deux pv,2>
<3,Perdre un pv,-1>
<4,Gagner deux de force,2>
<4,Perdre un de force,-1>
<5,Mettre l armure a 2,2>
<5,Mettre l armure a 9,9>
<6,Gagner deux d agilité,2>
<6,Perdre un d agilité,-1>
<7,Gagner deux de chance,2>
<7,Perdre un de chance,-1>
', '\..\..\DataBase\images\paysage_01.jpg'),


('Désintroduction', 'Test si il y a des sauts de ligne
1
2
3
4
5

Super tout ça <0,Vous pouvez retourner vers la première page ici,1>', '\..\..\DataBase\images\paysageAvecPortail_01.jpg');

INSERT INTO Inventory(goldenCoin) VALUES (18);

INSERT INTO Player (pv, force, armor, agility, luck, name, idActualPage, idInventory) VALUES (10, 3, 1, 5, 2, 'Godfroyd', 2, 1);