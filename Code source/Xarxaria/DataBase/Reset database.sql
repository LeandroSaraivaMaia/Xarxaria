USE XarxariaDB;

-- Suppression des tables
DROP TABLE IF EXISTS Enemy;
DROP TABLE IF EXISTS Player_Item;
DROP TABLE IF EXISTS Player;
DROP TABLE IF EXISTS Item;
DROP TABLE IF EXISTS Page;
DROP TABLE IF EXISTS Inventory;

-- Création des tables
CREATE TABLE Enemy (
	id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	pv INT,
	force INT,
	armor INT,
	agility INT,
	luck INT,
	name VARCHAR(255),
	image VARCHAR (255)
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
)

CREATE TABLE Item (
	id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	name VARCHAR (50),
	pv int,
	force int,
	armor int,
	agility int,
	luck int
)

CREATE TABLE Player_Item (
	idPlayer INT FOREIGN KEY REFERENCES Player(id),
	idItem INT FOREIGN KEY REFERENCES Item(id),
	quantity INT
)

-- Insertion des données --
INSERT INTO Page (title, text, image) VALUES
-- Page 1 --
('Introduction', 'C''est l''histoire d''un pays tranquille. Un jour, un vilain drake kidnappe une des princesses du royaume.
Le Roi, furieux, convoque tous ses chevaliers à la table carrée.
Malheureusement, tous les chevaliers sont en croisade dans le pays voisin.
Mais il reste un seul chevalier à la cour, le fameux Sir Godfroyd de Monaco. C''est le chevalier le plus valeureux de tout le royaume.
Il a déjà prouvé sa valeur a de nombreuse reprises en sauvant moultes princesses.
Le courageux chevalier est très décidé à sauver la princesse du Roi. Il dépense toutes ses économies et achète le meilleur équipement du royaume pour sa quête.
Quelques lieues après être sorti du château, il est frappé par ce qui lui semble être un éclair. Une grande ombre noire déchirant les cieux à une vitesse vertigineuse le renverse. Il est violemment éjecté de la route et finit dans un caniveau boueux.
Après avoir repris ses esprits, il aperçoit une bête ailé s''éloigner, le drake. Il se rend compte que son équipement a entièrement disparu. C''est sans doute l''oeuvre de la magie noire du drake.
Il a eu beaucoup de chance de s''en réchapper vivant.
C''est là que votre aventure commence, vous êtes ce chevalier.
<0,Continuer,3>'
, 'paysage.jpg'),

-- Page 2 --
('Liste des actions', 'Liste des actions :
0 Changement de page
1 Modifier un objet
2 Modifier les pv
3 Mettre la force
4 Modifier l armure
5 Modifier l agilité
6 Modifier la chance

<1,Ajouter 3 pièces d or,0;3>
<1,Supprimer 2 pièces d or,0;-2>
<2,Gagner deux pv,2>
<2,Perdre un pv,-1>
<3,Mettre la force à deux,2>
<4,Ajouter 2 d''armure,2>
<4,Enlever 1 d''armure,-1>
<5,Gagner deux d agilité,2>
<5,Perdre un d agilité,-1>
<6,Gagner deux de chance,2>
<6,Perdre un de chance,-1>
<0,Allez à la page 3 (Le commencement,3>', 'paysageAvecPortail.jpg'),

-- Page 3 --
('Le commencement', 'Vous vous relevez avec le peu de dignité qui vous reste. Pendant une seconde vous pensez retournez au château pour retrouver de l''équipement. Mais vous vous ravisez, avec une telle dégaine, vous ne passerez jamais les grilles du château.
Et revenir voir le Roi à peine 1 heure après être sortit pour sauver sa fille, quel honte !
De toute façon vous arriverez à trouver du nouvel équipement, après-tout vous êtes le meilleur chevalier du pays !
A présent il vous faut du matériel, que voulez-vous faire ?
<0,Continuer vers le village,11>, à la sortie du château ou <0,oublier son honneur et aller au château,4>', 'villageEtChateau.jpg'),

-- Page 4 --
('Oublier son honneur et aller au château', 'Finalement vous vous résignez à retourner au château. Combattre un drake avec uniquement de l''équipement trouvé sur la route est une mauvaise idée.
Vous faites le chemin inverse et apercevez que deux gardes royaux ont été postés à côtés de la grille du château. Une fois à l''intérieur de la grande cour, vous pourrez facilement passer vers les quartiers du Roi grâce à un passage secret qui y mène directement.
Le ponts levis est abaissé et vous pourriez vous approcher des gardes et espérer qu''ils vous laissent passer. Vous évaluez la situation et vous vous souvenez du vieux mur ouest qui sépare la cour du monde extérieur.
Ce mur du château est mal entretenu et de solides lianes ont investi la paroi. Vous connaissez l''endroit et vous savez que le Roi n''entretient que les murs les plus visible pour ne pas montrer que le royaume est ruiné. Vous pouvez tenter d''escalader le mur en vous aidant des lianes mais c''est plutôt risqué car la muraille doit bien faire 5 m de haut.
Après quelques minutes supplémentaires, aucun autre moyen d''entrer dans le château ne vous vient à l''esprit.
Vous devez choisir entre <0,passer par l''entrée principale,8> en espérant que les gardes vous reconnaissent ou <0,escalader le mur,5> en espérant que les lianes ne lâchent pas.
Vous pouvez aussi choisir de <0,rebrousser chemin(continuer au village),11>', 'chateau.jpg'),

-- Page 5 --
('Escalader le mur du château', 'Vous faîtes un grand détour pour ne pas que les gardes vous voient et vous vous approchez discrètement de la muraille.
Vous regardez le haut du mur que vous vous êtes décidé à grimper. De là il a l''air bien plus imposant.
Vous vous échauffez les articulations en appréhendant la monté qui vous attend, vous ne percevez aucun garde patrouillant le long du mur.
Après avoir choisi le parcours avec les plus grosses lianes, vous entamez l''escalade avec énergie. Vous aviez déjà eu affaire à des parois escarpées auparavant et cette grimpette ne vous semble pas si difficile.
Soudain, vous sentez que vous perdez prise.
Si vous êtes assez agile pour vous rattraper (4 points d''agilité ou plus), rendez-vous <0,ici,7>. Si vous êtes un peu plus pataud, alors allez <0,ici,6>.
', 'murailleAvecLierre.jpg'),

-- Page 6 --
('Vous n''arrivez pas à escalader le mur', 'Vous vous accrochez de toute vos forces aux lianes.
Cependant vous semblez quand même tomber, ce ne sont pas les lianes qui vous lâchent mais la brique !
Vous chutez inévitablement et essayez de trouver une position pour moins morfler à l''atterrissage. Vous vous ramassez par terre en tombant sur les fesses et <2,perdez 2 points de vie,-2>.
Par chance la brique qui a chuté avec vous retombe un mètre sur votre gauche et non sur votre tête. Par contre elle cause un bruit très fort et soudain qui a à coup sûr alerté les gardes.
Vous vous relevez péniblement et vous entendez des cris. Les gardes vous ont repérés. Ils sortent leurs armes et vous ordonne de vous rendre.
Vous courez à toute allure en direction du village sans parvenir à semer les gardes.
Décidé à leurs échapper, vous sautez dans ce qui vous semble être la meilleur cachette à l''heure actuelle : le caniveau.
Vous bondissez dans la rigole et vous vous tapissez au fond en ayant presque de l''eau jusqu''à la bouche. Vous apercevez les gardes en haut depuis votre planque. Votre cachette fonctionne à merveille, vous êtes invisible pour eux.
Après quelques minutes les deux gardes abandonnent la poursuite, ça tombe bien vous commenciez à avoir froid. Vous sortez du caniveau après être sûr que les gardes soient partie et vous vous nettoyer du mieux que vous pouvez avec la végétation alentoure.
Vous ne pouvez décemment pas retentez d''entrer dans le château en passant par la grille principale car les gardes vous reconnaîtront et vous chasserons.
Vous devez donc <0,continuer votre route en direction du village,11> pour dénicher des informations sur le drake.', 'chuteDuMur.jpg'),

-- Page 7 --
('Vous réussissez à grimper le mur', 'In extremis, vous lâchez la prise de votre main droite et bondissez en forçant sur vos jambes pour atteindre le sommet de la muraille. Il s''en est fallu de peu, car ce n''est pas les lianes qui vous ont lâchées mais une brique de la muraille. Vous craignez que le bruit est attiré les gardes alors vous devez faire vite.
Vous vous hisser péniblement pour atteindre le haut du mur et appréciez alors votre nouvelle vue de la splendide cour du château entourée de sa muraille de roche de luxe. Vous savez que ce château ne sert qu''aux visites diplomatiques et qu''il est stratégiquement obsolète.
A présent il vous faut passer par le passage secret à l''intérieur de la cour. Vous remarquez une énorme botte de foin juste en bas de la muraille côté intérieur, ce sera parfait pour amortir votre chute.
Vous sautez gracieusement tel un assassin et atterrissez en douceur sur le lit de paille.
Vous vous dirigez rapidement vers l''arrière de l''écurie et redécouvrez la trappe secrète désormais couverte de végétation.
Vous dégagez les plantes et ouvrez la trappe avec difficulté. Vous glissez avec lenteur dans ce tunnel étroit et complètement sombre pendant 5 bonnes minutes avant de tâter la sortie des doigts.
Vous ouvrez avec vitalité la sortie pour récupérer un peu d''air frais. Alors que vous vous étirer, vous constatez que vous n''êtes pas dans la chambre du Roi mais dans celle de ses filles.
Vous reconnaissez instantanément toutes les princesses : Amélia, Anastasia, Amanda, Anna, Aphrodita, Adelinda, Agatha, Adriana, Antonella, Angélica, Alessandra, Antoinetta et Angella. Il manque Anabella, la princesse que vous êtes chargé de sauver.
Vous semblez avoir interrompu les princesses pendant qu''elles se coiffaient mutuellement. Elles forment un cercles autour de vous.
- “Aaah, alors c''est à ça que servait cette trappe” lança Amanda.
- “Nous sommes toutes ravies de vous revoir Sir !” continua Anna.
- “Vous allez sauver notre soeur pas vrai ?” s''inquiéta Alessandra.
- “Encore merci de m''avoir sauvé de cette ogre l''autre fois !” s''exclama Adelinda.
Après d''autres acclamations, vous expliquez la situation et Amélia vous réponds :
- “Notre père est occupé avec ses bibelots, c''est à croire qu''il se souci plus de son armure que de nous…”
Toutes les princesses prennent une mine triste et, après un court silence, Anastasia reprends la conversation :
- “Il ne vous donnera pas d''équipement de qualité, cependant nous pouvons vous donner ceci :”
Antonella s''empresse de regarder sous un lit pour y sortir avec l''aide d''Aphrodita <3,une hache d''armes en acier trempé (Passe votre attaque a 5),5>
Après de chaleureuses salutations Agatha vous montre un passage secret qui mène directement à l''extérieur du château.
Vous repartez en <0,direction du village,11> bien décidé à sauver Anabella.', 'courDuChateau.jpg'),

-- Page 8 --
('Passer par l''entrée principale', 'Vous décidez d''aller directement vers la porte principale en espérant que les gardes vous laissent entrer, ils reconnaîtront sûrement le meilleur chevalier du royaume.
Il y en a un tout gros et un tout maigre, le premier pèse sans doute le double du deuxième. 
Vous vous lancez sur le pont levis d''un pas décidé. Au fur et à mesure de votre avancée, les gardes vous dévisagent de plus en plus.
Vous vous rappelez que vous sentez encore les excréments et que vous êtes un peu trempé. C''est alors que vous vous souvenez que les gardes ont pour ordre de chasser les mendiants de l''enceinte du château.
Vous appréhender moins bien la situation et une fois à la hauteur des gardes le plus maigre vous adresse la parole d''un ton agressif :
- “Z''êtes qui et qu''est-ce que vous faite là ?, c''est pas pour les mendiants ici”
Vous rétorquez en étant faussement sûr de vous :
- “Je suis Sir Godfroy de Monaco, je vous ordonne de me laisser passer !”
Si vous avez plus de 4 points de chance, rendez-vous <0,ici,9> et si vous êtes malchanceux, rendez-vous à cette <0,page,10>.
', 'garde.jpg'),

-- Page 9 --
('Les gardes vous reconnaissent', 'Immédiatement, les gardes se raidissent et le plus maigre vous dit :
- “Oh, navré Sir je ne vous avais pas reconnu, je vous en pris entrez”
Soulagé, vous imitez un air de dédain et entrez à grand pas dans la cour.
Les nobles vous dévisagent pendant que vous vous dirigez rapidement vers la salle du trône. Étonnamment il n''y a aucun autres gardes à l''intérieur et vous pouvez entrer sans problème dans la chambre du Roi.
Vous frappez contre la porte et vous entendez une voix familière :
- ”Encore vous ?! Je vous ai dit que je n''étais pas intéressé à vendre le Royaume !”
Vous ouvrez la porte et entrez.
- ”Sir Godfroyd ? … Mais que vous ait-il arrivé ? Je croyais que c''était encore ces foutus marchands de Capital +”
Vous surprenez le Roi en train de polir son casque en or. Sa chambre est extrêmement bien décorée comparée au reste du château. Une immense vitrine ouverte contenant un équipement complet en or trône en face de son lit à baldaquin.
Il vous regarde d''un air ahuri et vous rétorquez:
- ”Je me suis fait directement attaqué par le drake à la sortie du château. Il m''a renversé et a utilisé sa magie noire pour faire disparaître tout mon équipement.”
Il se remet à astiquer son casque et prend un air désintéressé.
- “Ah ce maudit drake, il attaque de plus en plus près… En quoi puis-je vous être utile ?”
- ”J''aurais besoin d''équipement pour tuer le drake et sauver votre fille Anabella. Toutes mes économies étaient passé dans mon armure, mon arme et mon cheval”
- “Oui, je vois mais... Tu sais que le royaume n''a pas au top niveau finance, je vais voir ce que je peux te prêter”
Il saisit un vieux coffre sous son lit et en sort un plastron et une arme.
- “C''est tout ce que je peux me permettre de te prêter, tiens et n''oublie pas de me les rendres hein.”
Vous recevez <4,un plastron en fer rouillé (armure + 3),3> et <3,une épée d''entrainement (passe votre force à 2),2>. Après de bref salutations vous reprenez votre route <0,vers le village,11> à la sortie du château.', 'chambreRoi.jpg'),

-- Page 10 --
('Les gardes ne vous reconnaissent pas', 'Après un long moment gênant, le plus gros des gardes reprend la conversation :
- “Ordre. Halte. Clodo. ”
L''autre garde continue :
- “Vous pouvez pas rester ici m''sieur, partez maintenant”
Il vous jette <1,une pièce d''or,0;1> au visage et les deux gardes lèvent leurs armes.
Dans une dernière tentative vous dites :
- ”Vous ne me reconnaissez pas ?, Godfroyd le meilleur chevalier du royaume, j''ai sauvé un tas de princesse !”
Vous semblez être la seul distraction de ces deux gardes depuis longtemps, ils vous poussent et vous menace de leurs armes :
- “Dehors l''ivrogne ! La seul chose que vous pourriez sauver c''est une bouteille de vin”
Vous commencer à courir quand vous remarquez que les deux gardes se mettent à vous suivre. Non, il vous poursuive !
Vous courrez pendant au moins 3 quart d''heure en direction du village, Finalement vous parvenez à semer les gardes, ils rebroussent chemin en vous injuriant.
Vous reprenez votre souffle. Pas question de retourner au château avec ces deux gardes aux aguets.
Vous devez donc <0,explorer le village,11> à la recherche d''indice pour savoir où s''est envolé le drake qui vous a attaqué récemment, peut-être que les villageois l''ont vu passer.', 'fuite.jpg'),

-- Page 11 --
-- Page temporaire de fin de version
('Fin de la démo !', 'Félicitations !
Vous êtes arrivé à la fin de la version 1.0 !
Merci d''avoir joué !'
, 'casseRoc.jpg'),
/*
('Casse-Roc', 'Vous vous dirigez donc vers le village situé à la sortie du château.
C''est un petit hameau tranquille nommé Casse-Roc où les habitants sont principalement des mineurs. Il y a de grandes carrières de pierre tout autour du village. Non en faite… le village est une carrière de pierre !
Vous n''avez jamais mis les pieds ici car vous êtes toujours au château ou en croisade dans les pays voisins. Cependant vous avez entendu des rumeurs sur cette endroit. Un jour petit un feu s''est déclaré et la quasi-totalité du village s''est embrasé car toutes les maisons étaient en bois à l''époque. La plupart des habitants étaient à la rue. Depuis ce jour les habitants se sont mis à construire leur maison directement dans la roche et maintenant le village vit de l''extraction de la pierre.
Vous remarquez aussi que l''intégralité du village est abaissé d''une dizaine de mètres dans le sol. L''extraction massive de pierre doit en être la cause, en effet pendant que vous marchez, vous croisez des mineurs qui creusent directement sur le sol du village.
Le village est principalement un terrain vague peuplé de mineurs acharnés. Il y a beaucoup de personnes et beaucoup d''agitation avec les éclats de pierre et les pioches qui volent dans tous les sens. Des rails, en pierre, ont été installés pour faciliter les allées et venues incessantes de wagons remplis de roche.
Ce qui vous perturbe le plus est l''omniprésence de la roche dans ce village. Les pioches, les wagons, les poteaux, les banderoles, les bâtiments et même les casquettes des habitants sont en pierre ! Vous vous sentez rassuré en voyant un habitant manger des pommes de terre.
Comme vous aviez prévu initialement, vous devez trouver des informations concernant le drake, vous devez maintenant choisir ce que vous allez faire :
<0,Aller dans le quartier marchand,12>
<0,Interroger les villageois,13>
<0,Mendier pour essayer d''obtenir de l''or,14>
<0,Piller l''église,15>
<0,Essayer de trouver du travail,20>'
, 'casseRoc.jpg'),
*/

-- Page 12 --
('Le forgeron', 'Vous vous promener un peu et vous trouvez un quartier marchand. A pars quelques mineurs à la tâche, le marché est quasiment désert. Il fait encore tôt donc cela ne vous étonne pas trop.
Vous remarquez que toute l''économie locale est basée sur la pierre. Des bijoux aux ustensiles de cuisine, la plupart des articles sont en pierre. Alors que vous pensez reconnaître les briques du château dans une échoppe de maçonnerie, vous trouvez enfin une boutique intéressante, l''armurerie.
C''est le plus petit magasin du marché avec ce qui semble être le forgeron du village au vue de son tablier et de l''enclume en pierre derrière lui. Vous n''êtes plus surpris que les articles proposés sont exclusivement fait en pierre.
Les objets suivants sont présentés sur l''étale de la marchande :
<3,Une massue en pierre,3>(Votre force passe à 3) pour <1,4 pièce d''or,0;-4>
<4,Une casquette de mineur en pierre,1>(armure + 1) pour <1,2 pièce d''or,0;-2>
<3,Une dague en pierre,2>(Votre force passe à 2) pour <1,2 pièce d''or,0;-2>
<1,Une étrange perle luisante,1;1> pour <1,1 pièce d''or,0;-1>
Une fois vos achats effectués, vous pouvez :
<0,Interroger les villageois,13>
<0,Mendier pour essayer d''obtenir de l''or,14>
<0,Piller l''église,15>
<0,Essayer de trouver du travail,20>'
, 'forgeron.jpg'),

-- Page 13 --
('La Taverne du mineur assoifé', 'Vous savez que le meilleur moyen d''obtenir des informations se trouve dans les tavernes.
Sans attendre un instant de plus vous vous dirigez vers un bâtiment nommé selon la banderole placée devant “La taverne du mineur assoiffé”.
Vous êtes accueilli par la douce chaleur d''un feu de cheminée ainsi que par le brouhaha si commun à un lieu de ce genre. Vous vous frayez difficilement un chemin à travers les client pour finalement vous asseoir devant le comptoire et interpeller le tavernier.
Un chauve de grande taille s''approche de vous, une chope en pierre à la main et vous dit :
- ”Que puis je faire pour vous mon brave ?”
Vous lui répondez :
- “Un drake est passé par ici ce matin, sauriez-vous dans quelle direction est-il parti ?”
- “Ma femme a remarqué une bête ailée s''éloigner vers l''est.”
- “Auriez vous une idée d''ou elle aurait put aller ?”
- “Il n''y qu''un seul endroit en ce monde qui puisse accueillir un tel monstre : L''Antre des Ténèbres.”
Vous réprimez un frissonnement, vous avez entendu tant de choses sur cet endroit, on dit que le soleil ne perce jamais ses nuages, que de la lave en fusion coule en permanence des collines et que seul les damnés osent entrer dans les tours sombres qui hantent ce lieu.
Mais après tout n''êtes-vous pas Sir Godfroy de Monaco, le champion du roi, le pourfendeur de démons, ce n''est pas un volcan ou un gros lézard qui vous fera douter de votre mission.
Vous remerciez le barman et quittez la taverne. ,Vous pouvez désormais reprendre votre chasse au drake en <0,quittant le village,23> ou continuer de vagabonder dans Casse-Roc :
<0,Aller dans le quartier marchand,12>
<0,Mendier pour essayer d''obtenir de l''or,14>
<0,Piller l''église,15>
<0,Essayer de trouver du travail,20>
', 'taverne.jpg'),

-- Page 14 --
('Mendiant', 'Vous devez trouver de l''or mais vous savez que vous n''arriverez pas à trouver un travail, il ne vous reste plus qu''une solution : mendier.
C''est avec honte que vous vous vêtissez d''un haillon en pierre gisant sur le sol et que vous rejoignez un groupe de sans-abris.
Durant plusieurs jours vous vous traînez dans les rues suppliant la générosité des passants.
Votre errance vous rapporte <1,3 pièces d''or,0;3>, une grande quantitée de cailloux au visage et vous fait perdre <2,2 PV,-2> à cause de la fatigue.
Vous devez désormais continuer :
<0,Aller dans le quartier marchand,12>
<0,Interroger les villageois,13>
<0,Piller l''église,15>
<0,Essayer de trouver du travail,20>
', 'mendiant.jpg'),

-- Page 15 --
('L''église', 'Vous savez que l''église de casse roc est connue pour entreposer des richesses extraites des mines. En voler une partie vous permettrai de vous racheter un équipement.
Vous inspectez le bâtiment et repérez le grand vitrail à l''arrière. Il a l''air très ancien au vu de l''agglomération de verre en bas du cadre. Vous examinez les alentours pour vérifier qu''il n''y ait pas de témoins éventuels, l''endroit est isolé et vous pourrez agir en toute discrétion. Après un rapide coup d''oeil vous remarquez sous l''autel un panier en osier qui doit certainement servir pour les donations. Il est vide mais une porte surveillé par un garde à moitié endormi se trouve au fond de l''église, les biens précieux doivent sûrement se trouver à l''abri des regards.
Une fois la nuit tombée, vous prenez une pierre et brisez la fenêtre pour vous infiltrez. L''impact fait moins de bruit que prévu, vous entrez lentement à l''intérieur de l''église quand vous entendez soudainement des bruits de pas.
Malgré l''heure tardive, vous apercevez des prêtres et des chevalier déambuler à travers les couloirs.
Si vous avez plus de 4 d''agilité et plus de 3 de chance rendez-vous <0,ici,16>, si malheureusement vous êtes un piètre voleur, rendez vous <0,ici,17>.', 'eglise.jpg'),

-- Page 16 --
('Voleur d''églises', 'C''est avec l''agilité du serpent que vous vous glissez derrière une statue et évitez les occupants.
Plaqué contre le mur, vous traversez les différents couloirs de l''église jusqu''à atteindre la porte du coffre. Malheureusement un garde est posté devant et il serait impossible de l''affronter sans alerter les chevaliers et les prêtres. 
Cela ne vous décourage pas, vous prenez une coupe en pierre qui traînait par là et la lancez dans un couloir à côté.
La garde sursaute et se précipite dans le couloir en se lançant à lui-même :
- “Eh...Y''a quelqu''un ?”
Vous profitez de l''opportunité pour sprinter dans la caverne d''ali baba.
Vous n''êtes pas déçu, la salle est remplie de diverses richesses : des croix serties de pierres précieuses, des épées faites de diamant, des coffres débordant d''or, etc.
Vous êtes tellement obnubilé par ce trésor que vous ne remarquez pas votre pied butter contre un fil tendu.
Soudainement vous entendez le bruit d''un mécanisme se mettre en marche suivi du lourd son d''une cloche, toute l''église doit être désormais au courant qu''il y à un voleur.
Vous vous précipitez vers la fenêtre précédemment détruite, emportant avec vous la seul bourse que vous avez eu le réflexe de prendre dans votre fuite.
Par chance vous ne rencontrez personne durant votre escapade et vous parvenez à quitter l''église en un seul morceau, emportant avec vous <1,20 pièces d''or,0;20>, une somme rondelette.
Vous devez faire profile-bas maintenant, que choisissez vous de faire ?
<0,Aller dans le quartier marchand,12>
<0,Interroger les villageois,13>
<0,Mendier pour essayer d''obtenir de l''or,14>
<0,Essayer de trouver du travail,20>
', 'tasDOr.png'),

-- Page 17 --
('Piètre voleur', 'Vous tentez de vous glisser vers une statue mais c''est un échec. Sans attendre un moment, les paladins se jettent sur vous et vous immobilisent.
Ils vous emmènent sans plus tarder et vous balancent dans une cellule de la prison de Casse-Roc.
Tenter de piller une église est un crime grave mais heureusement un prêtre arrive près de votre cellule. Il est prêt à vous pardonner mais ce ne sera pas gratuit. Il demande 8 pièces d''or. Souhaitez-vous <0,accepter,19> et <1,payer les pièces d''or,0;-8> ou <0,refuser,18> ?'
, 'prison.jpg'),

-- Page 18 --
('Prison à vie', 'Le prêtre vous lance un regard de mépris et quitte votre cellule. Vous êtes un chevalier du roi, vous ne tarderez pas à être libéré.
Vous attendez des heures puis des jours, puis des mois. C''est à ce moment que vous vous rendez compte que le prêtre était votre seule chance de sortie, personne d''autre ne viendra.
C''est ainsi que fini votre espoir d''être libéré ainsi que votre vie.
', 'mortEnPrison.jpg'),

-- Page 19 --
('Libéré, délivré', '- “Vous avez fait le bon choix Sir Godfroy.”
Dit le prêtre non sans un sourire de satisfaction sur le visage.
Les gardes vous emmène dans une salle avec toutes vos affaires hormis les 8 pièces d''or prisent par le prêtre. Vous exprimez un soupire de soulagement en voyant la lumière du jour et les toits de pierre du village.
Maintenant que vous êtes libre, que faites-vous ?
<0,Aller dans le quartier marchand,12>
<0,Interroger les villageois,13>
<0,Mendier pour essayer d''obtenir de l''or,14>
<0,Essayer de trouver du travail,20>
', 'libre.jpg'),

-- Page 20 --
('A la recherche d''un emploi', 'Si vous voulez avoir de l''or, pas le choix, il faut travailler.
Vous rejoignez la grande place et consultez le panneau des annonces à la recherche d''une offre intéressante.
Le gros du panneau est occupé par les offres des deux grande factions marchandes : Capital + et La Faucille Rouge.
Si vous avez plus de 4 de chance, allez <0,ici,22>, sinon allez <0,ici,21>.', 'annonces.png'),

-- Page 21 --
('Chômage', 'Vous parcourez le village pendant des heures en espérant trouver du labeur. Malgré toutes vos recherches vous ne trouvez aucun habitant qui aurait besoin d''aide. Il semblerait que tous les travaux manuels soient occupés, le business de la pierre est décidément florissant.
Malheureusement vous n''avez pas réussi à trouver une quelqu''on offre qui pourrait vous aider.
Que faites-vous maintenant ?
<0,Aller dans le quartier marchand,12>
<0,Interroger les villageois,13>
<0,Mendier pour essayer d''obtenir de l''or,14>
<0,Piller l''église,15>
', 'sansTravail.png'),

-- Page 22 --
('Un dur labeur', 'Au milieu de tous ces papiers vous apercevez dans le coin une affiche proposant un travail dans un atelier de tailleur de pierre.
Vous travaillez durant quelques jours au milieu des pierres et des statues , votre rôle est surtout de créer et transporter des briques nécessaires à la construction c''est un travail particulièrement éprouvant car les briques sont très lourdes et les horaires sont épouvantables.
Finalement vos efforts s''avèrent être payant : vous obtenez <1,10 pièces d''or,0;10>.
Maintenant que vous avez de l''argent que faites vous ?
<0,Aller dans le quartier marchand,12>
<0,Interroger les villageois,13>
<0,Mendier pour essayer d''obtenir de l''or,14>
<0,Piller l''église,15>
', 'gagnerArgent.png');

INSERT INTO Player (pv, force, armor, agility, luck, name, idActualPage) VALUES (10, 3, 1, 5, 2, 'Godfroyd', 3);

INSERT INTO Item (name, pv, force, armor, agility, luck) VALUES
('Plastron rouillé', 0, 0, 2, 0, 0),
('Casque de mineur en pierre', 0, 0, 1, 0, 0),
('Jambières encombrantes', 0, 0, 2, -1, 0),
('Manteau de fourrure', 0, 0, 1, 0, 0),
('Bottes de Pégase', 0, 0, 0, 2, 0),
('Vieux foulard', 0, 0, 0, 0, 1),
('Talisman gravé', 0, 0, 0, 0, 1),
('Epée du Soleil Levant', 0, 10, 0, 0, 0),
('Lance du champion en argent', 0, 9, 0, 0, 0),
('Hache d''arme en acier trempé', 0, 8, 0, 0, 0),
('Epée en acier', 0, 7, 0, 0, 0),
('Massue en pierre', 0, 6, 0, 0, 0),
('Dague en pierre', 0, 4, 0, 0, 0),
('Epée d''entraînement', 0, 4, 0, 0, 0),
('Pièce d''or', 0, 0, 0, 0, 0),
('Perle luisante', 0, 0, 0, 0, 0),
('Eau bénite', 0, 0, 0, 0 ,0),
('Anneau en argent', 0, 0, 0, 0, 0),
('Potion de vitalité', 6, 0, 0, 0, 0),
('Potion du serpent', 0, 0, 0, 1, 0),
('Potion de trèfle à quatre feuille', 0, 0, 0, 0, 1);

INSERT INTO Enemy (pv, force, armor, agility, luck, name, image) VALUES 
(10, 5, 1, 4, 3, 'Gobelin', 'gobelin.jpg'),
(16, 3, 2, 5, 4, 'Chef gobelin', 'chefGobelin.jpg'),
(35, 5, 1, 2, 3, 'Bandit', 'bandit.jpg'),
(25, 4, 3, 3, 0, 'Araignée squelette', 'araigneeSquelette.png'),
(30, 4, 1, 6, 2, 'Wendigo', 'wendigo.jpg'),
(20, 3, 0, 3, 1, 'Wendigo affaibli', 'wendigoAffaibli.jpg'),
(50, 7, 3, 4, 0, 'Drake', 'drake.jpg');