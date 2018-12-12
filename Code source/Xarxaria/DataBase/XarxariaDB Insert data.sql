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
<0,Allez à la page 3,3>
', '\..\..\DataBase\images\paysage_01.jpg'),


('Liste des pages', 'Test si il y a des sauts de ligne
1
2
3
4
5

Super tout ça <0,Vous pouvez retourner vers la première page ici,1>', '\..\..\DataBase\images\paysageAvecPortail_01.jpg'),

-- Page 3 --
('Le commencement', 'Vous vous relevez avec le peu de dignité qui vous reste. Pendant une seconde vous pensez retournez au château pour retrouver de l’équipement. Mais vous vous ravisez, avec une telle dégaine, vous ne passerez jamais les grilles du château.
Et revenir voir le Roi à peine 1 heure après être sortit pour sauver sa fille, quel honte !
De toute façon vous arriverez à trouver du nouvel équipement, après-tout vous êtes le meilleur chevalier du pays !
A présent il vous faut du matériel, que voulez-vous faire ?
<0,Continuer vers le village, à la sortie du château,11> ou <0,oublier son honneur et aller au château,4>', '\..\..\DataBase\images\villageEtChateau_01.jpg'),

-- Page 4 --
('Oublier son honneur et aller au château', 'Finalement vous vous résignez à retourner au château. Combattre un drake avec uniquement de l’équipement trouvé sur la route est une mauvaise idée.
Vous faites le chemin inverse et apercevez que deux gardes royaux ont été postés à côtés de la grille du château. Une fois à l’intérieur de la grande cour, vous pourrez facilement passer vers les quartiers du Roi grâce à un passage secret qui y mène directement.
Le ponts levis est abaissé et vous pourriez vous approcher des gardes et espérer qu’ils vous laissent passer. Vous évaluez la situation et vous vous souvenez du vieux mur ouest qui sépare la cour du monde extérieur.
Ce mur du château est mal entretenu et de solides lianes ont investi la paroi. Vous connaissez l’endroit et vous savez que le Roi n’entretient que les murs les plus visible pour ne pas montrer que le royaume est ruiné. Vous pouvez tenter d’escalader le mur en vous aidant des lianes mais c’est plutôt risqué car la muraille doit bien faire 5 m de haut.
Après quelques minutes supplémentaires, aucun autre moyen d’entrer dans le château ne vous vient à l’esprit.
Vous devez choisir entre <0,passer par l’entrée principale,8> en espérant que les gardes vous reconnaissent ou <0,escalader le mur,5> en espérant que les lianes ne lâchent pas.
Vous pouvez aussi choisir de <0,rebrousser chemin(continuer au village),11>', '\..\..\DataBase\images\chateau_01.jpg'),

-- Page 5 --
('Escalader le mur du château', 'Vous faîtes un grand détour pour ne pas que les gardes vous voient et vous vous approchez discrètement de la muraille.
Vous regardez le haut du mur que vous vous êtes décidé à grimper. De là il a l’air bien plus imposant.
Vous vous échauffez les articulations en appréhendant la monté qui vous attend, vous ne percevez aucun garde patrouillant le long du mur.
Après avoir choisi le parcours avec les plus grosses lianes, vous entamez l’escalade avec énergie. Vous aviez déjà eu affaire à des parois escarpées auparavant et cette grimpette ne vous semble pas si difficile.
Soudain, vous sentez que vous perdez prise.
Si vous êtes assez agile pour vous rattraper (4 points d’agilité ou plus), rendez-vous <0,ici,7>. Si vous êtes un peu plus pataud, alors allez <0,ici,6>.
', '\..\..\DataBase\images\murailleAvecLierre_01.jpg'),

INSERT INTO Inventory(goldenCoin) VALUES (18);

INSERT INTO Player (pv, force, armor, agility, luck, name, idActualPage, idInventory) VALUES (10, 3, 1, 5, 2, 'Godfroyd', 2, 1);

-- Updates
USE XarxariaDB

UPDATE Page SET text = 
'Page 1 : <0,Introduction,1>
 Page 3 : <0,Le commencement,3>
 Page 4 : <0,Oublier son honneur et aller au chateau,4>' 
WHERE id = 2;