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
	hp INT,
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
	hp INT,
	force INT,
	armor INT,
	agility INT,
	luck INT,
	name VARCHAR(255),
	inactiveLinks INT,
	idActualPage INT FOREIGN KEY REFERENCES Page(id),
)

CREATE TABLE Item (
	id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	name VARCHAR (50),
	hp int,
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
Le Roi, furieux, convoque tous ses chevaliers de la table ovale.
Malheureusement, tous les chevaliers sont en croisade dans le pays voisin.
Fort heureusement, il reste encore un chevalier à la cour, le fameux Sir Godfroyd de Monaco. C''est le chevalier le plus valeureux de tout le royaume.
Il a déjà prouvé sa valeur à de nombreuse reprises en sauvant moultes princesses.
Le courageux chevalier est très décidé à sauver la princesse disparue. Il dépense toutes ses économies et achète le meilleur équipement du royaume pour sa quête.
Quelques lieues après être sorti du château, il est frappé par ce qui lui semble être un éclair. Une grande ombre noire déchirant les cieux à une vitesse vertigineuse le renverse. Il est violemment éjecté de la route et finit dans un caniveau boueux.
Après avoir repris ses esprits, il aperçoit une bête ailée s''éloigner, le drake. Il se rend compte que son équipement a entièrement disparu. C''est sans doute l''oeuvre de la magie noire du drake.
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

<1,Ajouter 3 pièces d or,14;3>
<1,Supprimer 2 pièces d or,14;-2>
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
('Le commencement', 'Vous vous relevez avec le peu de dignité qu''il vous reste. Pendant une seconde vous pensez retournez au château pour retrouver de l''équipement. Mais vous vous ravisez, avec une telle dégaine, vous ne passerez jamais les grilles du château.
Et retourner voir le Roi à peine 1 heure après être sortit pour sauver sa fille, quel honte !
De toute façon vous arriverez à trouver du nouvel équipement, après tout vous êtes le meilleur chevalier du pays !
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
Vous regardez le haut du mur que vous vous êtes décidé à grimper. De là, il a l''air bien plus imposant.
Vous vous échauffez les articulations en appréhendant la montée qui vous attend, vous ne percevez aucun garde patrouillant le long du mur.
Après avoir choisi le parcours avec les plus grosses lianes, vous entamez l''escalade avec énergie. Vous aviez déjà eu affaire à des parois escarpées auparavant et cette grimpette ne vous semble pas si difficile.
Soudain, vous sentez que vous perdez prise.
Si vous êtes assez agile pour vous rattraper *(4 points d''agilité ou plus)*, rendez-vous <0,ici,7>. Si vous êtes un peu plus pataud, alors allez <0,ici,6>.
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
('Vous réussissez à grimper le mur', 'In extremis, vous lâchez la prise de votre main droite et bondissez en forçant sur vos jambes pour atteindre le sommet de la muraille. Il s''en est fallu de peu, car ce n''est pas les lianes qui vous ont lâchées mais une brique de la muraille. Vous craignez que le bruit ait attiré les gardes, alors vous devez faire vite.
Vous vous hissez péniblement pour atteindre le haut du mur et appréciez alors votre nouvelle vue de la splendide cour du château entourée de sa muraille de roche de luxe. Vous savez que ce château ne sert qu''aux visites diplomatiques et qu''il est stratégiquement obsolète.
A présent, il vous faut passer par le passage secret à l''intérieur de la cour. Vous remarquez une énorme botte de foin juste en bas de la muraille, côté intérieur, cela sera parfait pour amortir votre chute.
Vous sautez gracieusement tel un assassin et atterrissez en douceur sur le lit de paille.
Vous vous dirigez rapidement vers l''arrière de l''écurie et redécouvrez la trappe secrète désormais couverte de végétation.
Vous dégagez les plantes et ouvrez la trappe avec difficulté. Vous glissez avec lenteur dans ce tunnel étroit et complètement sombre pendant 5 bonnes minutes avant de tâter la sortie des doigts.
Vous ouvrez avec vitalité la sortie pour récupérer un peu d''air frais. Alors que vous vous étirez, vous constatez que vous n''êtes pas dans la chambre du Roi mais dans celle de ses filles.
Vous reconnaissez instantanément toutes les princesses : Amélia, Anastasia, Amanda, Anna, Aphrodita, Adelinda, Agatha, Adriana, Antonella, Angélica, Alessandra, Antoinetta et Angella. Il manque Anabella, la princesse que vous êtes chargé de sauver.
Vous semblez avoir interrompu les princesses pendant qu''elles se coiffaient mutuellement. Elles forment un cercle autour de vous.
- "Aaah, alors c''est à ça que servait cette trappe.", lança Amanda.
- "Nous sommes toutes ravies de vous revoir Sir !", continua Anna.
- "Vous allez sauver notre soeur pas vrai ?", s''inquiéta Alessandra.
- "Encore merci de m''avoir sauvée de cette ogre l''autre fois !", s''exclama Adelinda.
Après d''autres acclamations, vous expliquez la situation et Amélia vous réponds :
- "Notre père est occupé avec ses bibelots, c''est à croire qu''il se soucie plus de son armure que de nous ..."
Toutes les princesses prennent une mine triste et, après un court silence, Anastasia reprends la conversation :
- "Il ne vous donnera pas d''équipement de qualité, cependant nous pouvons vous donner ceci :"
Antonella s''empresse de regarder sous un lit pour y sortir avec l''aide d''Aphrodita <3,une hache d''armes en acier trempé (Passe votre attaque a 8),8>.
Après de chaleureuses salutations, Agatha vous montre un autre passage secret qui mène directement à l''extérieur du château.
<0,Vous partez en direction du village,11>, bien décidé à sauver Anabella.
', 'courDuChateau.jpg'),

-- Page 8 --
('Passer par l''entrée principale', 'Vous décidez d''aller directement vers la porte principale en espérant que les gardes vous laissent entrer, ils reconnaîtront sûrement le meilleur chevalier du royaume.
Il y en a un tout gros et un tout maigre, le premier pèse sans doute le double du deuxième. 
Vous vous lancez sur le pont levis d''un pas décidé. Au fur et à mesure de votre avancée, les gardes vous dévisagent de plus en plus.
Vous vous rappelez que vous sentez encore les excréments et que vous êtes un peu trempé. C''est alors que vous vous souvenez que les gardes ont pour ordre de chasser les mendiants de l''enceinte du château.
Vous appréhender moins bien la situation et une fois à la hauteur des gardes le plus maigre vous adresse la parole d''un ton agressif :
- "Z''êtes qui et qu''est-ce que vous faite là ?, c''est pas pour les mendiants ici"
Vous rétorquez en étant faussement sûr de vous :
- "Je suis Sir Godfroy de Monaco, je vous ordonne de me laisser passer !"
Si vous avez *au moins 4 points de chance*, rendez-vous <0,ici,9> et si vous êtes malchanceux, <0,rendez-vous à cette page,10>.
', 'garde.jpg'),

-- Page 9 --
('Les gardes vous reconnaissent', 'Immédiatement, les gardes se raidissent et le plus maigre vous dit :
- "Oh, navré Sir je ne vous avais pas reconnu, je vous en pris entrez"
Soulagé, vous imitez un air de dédain et entrez à grand pas dans la cour.
Les nobles vous dévisagent pendant que vous vous dirigez rapidement vers la salle du trône. Étonnamment il n''y a aucun autres gardes à l''intérieur et vous pouvez entrer sans problème dans la chambre du Roi.
Vous frappez contre la porte et vous entendez une voix familière :
- "Encore vous ?! Je vous ai dit que je n''étais pas intéressé à vendre le Royaume !"
Vous ouvrez la porte et entrez.
- "Sir Godfroyd ? ... Mais que vous est-il arrivé ? Je croyais que c''était encore ces foutus marchands de Capital +"
Vous surprenez le Roi en train de polir son casque en or. Sa chambre est extrêmement bien décorée comparé au reste du château. Une immense vitrine ouverte contenant un équipement complet en or trône en face de son lit à baldaquin.
Il vous regarde d''un air ahuri et vous rétorquez:
- "Je me suis fait directement attaqué par le drake à la sortie du château. Il m''a renversé et a utilisé sa magie noire pour faire disparaître tout mon équipement."
Il se remet à astiquer son casque et prend un air désintéressé.
- "Ah ce maudit drake, il attaque de plus en plus près... En quoi puis-je vous être utile ?"
- "J''aurais besoin d''équipement pour tuer le drake et sauver votre fille Anabella. Toutes mes économies étaient passé dans mon armure, mon arme et mon cheval."
- "Oui, je vois mais... Tu sais que le royaume n''est pas au top niveau finances, je vais voir ce que je peux te prêter."
Il saisit un vieux coffre sous son lit et en sort un plastron et une arme.
- "C''est tout ce que je peux me permettre de te prêter, tiens et n''oublie pas de me les rendres, hein."
Vous recevez <4,un plastron en fer rouillé (armure + 2),2> et <3,une épée d''entrainement (passe votre force à 4),4>. Après de brèves salutations, vous reprenez votre route <0,vers le village,11> à la sortie du château.', 'chambreRoi.jpg'),

-- Page 10 --
('Les gardes ne vous reconnaissent pas', 'Après un long moment gênant, le plus gros des gardes reprend la conversation :
- "Ordre. Halte. Clodo."
L''autre garde continue :
- "Vous pouvez pas rester ici m''sieur, partez maintenant"
Il vous jette <1,une pièce d''or,14;1> au visage et les deux gardes lèvent leurs armes.
Dans une dernière tentative vous dites :
- "Vous ne me reconnaissez pas ?, Godfroyd le meilleur chevalier du royaume, j''ai sauvé un tas de princesse !"
Vous semblez être la seul distraction de ces deux gardes depuis longtemps, ils vous poussent et vous menace de leurs armes :
- "Dehors l''ivrogne ! La seul chose que vous pourriez sauver c''est une bouteille de vin"
Vous commencer à courir quand vous remarquez que les deux gardes se mettent à vous suivre. Non, il vous poursuive !
Vous courrez pendant au moins 3 quart d''heure en direction du village, Finalement vous parvenez à semer les gardes, ils rebroussent chemin en vous injuriant.
Vous reprenez votre souffle. Pas question de retourner au château avec ces deux gardes aux aguets.
Vous devez donc <0,explorer le village,11> à la recherche d''indice pour savoir où s''est envolé le drake qui vous a attaqué récemment, peut-être que les villageois l''ont vu passer.', 'fuite.jpg'),

-- Page 11 --

('Casse-Roc', 'Vous vous dirigez donc vers le village situé à la sortie du château.
C''est un petit hameau tranquille nommé Casse-Roc où les habitants sont principalement des mineurs. Il y a de grandes carrières de pierre tout autour du village. Non en faite... le village est une carrière de pierre !
Vous n''avez jamais mis les pieds ici car vous êtes toujours au château ou en croisade dans les pays voisins. Cependant vous avez entendu des rumeurs sur cette endroit. Un jour petit un feu s''est déclaré et la quasi-totalité du village s''est embrasé car toutes les maisons étaient en bois à l''époque. La plupart des habitants étaient à la rue. Depuis ce jour les habitants se sont mis à construire leur maison directement dans la roche et maintenant le village vit de l''extraction de la pierre.
Vous remarquez aussi que l''intégralité du village est abaissé d''une dizaine de mètres dans le sol. L''extraction massive de pierre doit en être la cause, en effet pendant que vous marchez, vous croisez des mineurs qui creusent directement sur le sol du village.
Le village est principalement un terrain vague peuplé de mineurs acharnés. Il y a beaucoup de personnes et beaucoup d''agitation avec les éclats de pierre et les pioches qui volent dans tous les sens. Des rails, en pierre, ont été installés pour faciliter les allées et venues incessantes de wagons remplis de roche.
Ce qui vous perturbe le plus est l''omniprésence de la roche dans ce village. Les pioches, les wagons, les poteaux, les banderoles, les bâtiments et même les casquettes des habitants sont en pierre ! Vous vous sentez rassuré en voyant un habitant manger des pommes de terre.
Comme vous aviez prévu initialement, vous devez trouver des informations concernant le drake, vous devez maintenant choisir ce que vous allez faire :
(Toutes les actions ne sont possibles qu''une seul fois à part le quartier marchand)
<0,Aller dans le quartier marchand,12>
<0,Interroger les villageois,13>
<0,Mendier pour essayer d''obtenir de l''or,14>
<0,Piller l''église,15>
<0,Essayer de trouver du travail,20>'
, 'casseRoc.jpg'),

-- Page 12 --
('Le quartier marchand', 'Vous vous promener un peu et vous trouvez un quartier marchand. A pars quelques mineurs à la tâche, le marché est quasiment désert. Il fait encore tôt donc cela ne vous étonne pas trop.
Vous remarquez que toute l''économie locale est basée sur la pierre. Des bijoux aux ustensiles de cuisine, la plupart des articles sont en pierre. 
Vous passez devant un marchand itinérant qui semble proposer du matériel intéressant :
<1,Une étrange perle luisant en bleu,15;1> pour <1,1 pièce d''or,14;-1>
<1,De l''eau bénite,16;1> pour <1,1 pièce d''or,14;-1>
Alors que vous pensez reconnaître les briques du château dans une échoppe de maçonnerie, vous trouvez enfin une boutique intéressante, l''armurerie.
C''est le plus petit magasin du marché avec ce qui semble être le forgeron du village au vue de son tablier et de l''enclume en pierre derrière lui. Vous n''êtes plus surpris que les articles proposés sont exclusivement fait en pierre.
Les objets suivants sont présentés sur l''étale du marchand :
<3,Une massue en pierre(Votre force passe à 6),6> pour <1,4 pièces d''or,14;-4>
<4,Une casquette de mineur en pierre(Vous gagnez 1 armure),4> pour <1,2 pièces d''or,14;-2>
<3,Une dague en pierre(Votre force passe à 4),4> pour <1,2 pièces d''or,14;-2>
Une fois vos achats effectués, vous pouvez :
<0,Interroger les villageois,13>
<0,Mendier pour essayer d''obtenir de l''or,14>
<0,Piller l''église,15>
<0,Essayer de trouver du travail,20>'
, 'forgeron.jpg'),

-- Page 13 --
('La Taverne du mineur assoifé', 'Vous savez que le meilleur moyen d''obtenir des informations se trouve dans les tavernes.
Sans attendre un instant de plus vous vous dirigez vers un bâtiment nommé selon la banderole placée devant "La taverne du mineur assoiffé".
Vous êtes accueilli par la douce chaleur d''un feu de cheminée ainsi que par le brouhaha si commun à un lieu de ce genre. Vous vous frayez difficilement un chemin à travers les client pour finalement vous asseoir devant le comptoire et interpeller le tavernier.
Un chauve de grande taille s''approche de vous, une chope en pierre à la main et vous dit :
- "Que puis je faire pour vous mon brave ?"
Vous lui répondez :
- "Un drake est passé par ici ce matin, sauriez-vous dans quelle direction est-il parti ?"
- "Ma femme a remarqué une bête ailée s''éloigner vers le nord-ouest."
- "Auriez vous une idée d''ou elle aurait put aller ?"
- "Il n''y qu''un seul endroit en ce monde qui puisse accueillir un tel monstre : L''Antre des Ténèbres."
Vous réprimez un frissonnement, vous avez entendu tant de choses sur cet endroit, on dit que le soleil ne perce jamais ses nuages, que de la lave en fusion coule en permanence des collines et que seul les damnés osent entrer dans les tours sombres qui hantent ce lieu.
Mais après tout n''êtes-vous pas Sir Godfroy de Monaco, le champion du roi, le pourfendeur de démons, ce n''est pas un volcan ou un gros lézard qui vous fera douter de votre mission.
Vous remerciez le barman et quittez la taverne. ,Vous pouvez désormais reprendre votre chasse au drake en <0,quittant le village,23> ou continuer de vagabonder dans Casse-Roc :
<0,Aller dans le quartier marchand,12>
<0,Mendier pour essayer d''obtenir de l''or,14>
<0,Piller l''église,15>
<0,Essayer de trouver du travail,20>'
, 'taverne.jpg'),

-- Page 14 --
('Mendiant', 'Vous devez trouver de l''or mais vous savez que vous n''arriverez pas à trouver un travail, il ne vous reste plus qu''une solution : mendier.
C''est avec honte que vous vous vêtissez d''un haillon en pierre gisant sur le sol et que vous rejoignez un groupe de sans-abris.
Durant plusieurs jours vous vous traînez dans les rues suppliant la générosité des passants.
Votre errance vous rapporte <1,3 pièces d''or,14;3>, une grande quantitée de cailloux au visage et vous fait perdre <2,2 PV,-2> à cause de la fatigue.
Vous devez désormais continuer :
<0,Aller dans le quartier marchand,12>
<0,Interroger les villageois,13>
<0,Piller l''église,15>
<0,Essayer de trouver du travail,20>'
, 'mendiant.jpg'),

-- Page 15 --
('L''église', 'Vous savez que l''église de casse roc est connue pour entreposer des richesses extraites des mines. En voler une partie vous permettrai de vous racheter un équipement.
Vous inspectez le bâtiment et repérez le grand vitrail à l''arrière. Il a l''air très ancien au vu de l''agglomération de verre en bas du cadre. Vous examinez les alentours pour vérifier qu''il n''y ait pas de témoins éventuels, l''endroit est isolé et vous pourrez agir en toute discrétion. Après un rapide coup d''oeil vous remarquez sous l''autel un panier en osier qui doit certainement servir pour les donations. Il est vide mais une porte surveillé par un garde à moitié endormi se trouve au fond de l''église, les biens précieux doivent sûrement se trouver à l''abri des regards.
Une fois la nuit tombée, vous prenez une pierre et brisez la fenêtre pour vous infiltrez. L''impact fait moins de bruit que prévu, vous entrez lentement à l''intérieur de l''église quand vous entendez soudainement des bruits de pas.
Malgré l''heure tardive, vous apercevez des prêtres et des chevalier déambuler à travers les couloirs.
Si vous avez *plus de 4 d''agilité* et *plus de 3 de chance* rendez-vous <0,ici,16>, si malheureusement vous êtes un piètre voleur, rendez vous <0,ici,17>.', 'eglise.jpg'),

-- Page 16 --
('Voleur d''églises', 'C''est avec l''agilité du serpent que vous vous glissez derrière une statue et évitez les occupants.
Plaqué contre le mur, vous traversez les différents couloirs de l''église jusqu''à atteindre la porte du coffre. Malheureusement un garde est posté devant et il serait impossible de l''affronter sans alerter les chevaliers et les prêtres. 
Cela ne vous décourage pas, vous prenez une coupe en pierre qui traînait par là et la lancez dans un couloir à côté.
La garde sursaute et se précipite dans le couloir en se lançant à lui-même :
- "Eh...Y''a quelqu''un ?"
Vous profitez de l''opportunité pour sprinter dans la caverne d''ali baba.
Vous n''êtes pas déçu, la salle est remplie de diverses richesses : des croix serties de pierres précieuses, des épées faites de diamant, des coffres débordant d''or, etc.
Vous êtes tellement obnubilé par ce trésor que vous ne remarquez pas votre pied butter contre un fil tendu.
Soudainement vous entendez le bruit d''un mécanisme se mettre en marche suivi du lourd son d''une cloche, toute l''église doit être désormais au courant qu''il y à un voleur.
Vous vous précipitez vers la fenêtre précédemment détruite, emportant avec vous la seul bourse que vous avez eu le réflexe de prendre dans votre fuite.
Par chance vous ne rencontrez personne durant votre escapade et vous parvenez à quitter l''église en un seul morceau, emportant avec vous <1,20 pièces d''or,14;20>, une somme rondelette.
Vous devez faire profile-bas maintenant, que choisissez vous de faire ?
(Toutes les actions ne sont possibles qu''une seul fois à part le quartier marchand)
<0,Aller dans le quartier marchand,12>
<0,Interroger les villageois,13>
<0,Mendier pour essayer d''obtenir de l''or,14>
<0,Essayer de trouver du travail,20>'
, 'tasDOr.png'),

-- Page 17 --
('Piètre voleur', 'Vous tentez de vous glisser vers une statue mais c''est un échec. Sans attendre un moment, les paladins se jettent sur vous et vous immobilisent.
Ils vous emmènent sans plus tarder et vous balancent dans une cellule de la prison de Casse-Roc.
Tenter de piller une église est un crime grave mais heureusement un prêtre arrive près de votre cellule. Il est prêt à vous pardonner mais ce ne sera pas gratuit. Il demande *8 pièces d''or*. Souhaitez-vous <1,payer les 8 pièces d''or,14;-8> pour <0,être libéré,19> ou <0,refuser,18> ?'
, 'prison.jpg'),

-- Page 18 --
('Prison à vie', 'Le prêtre vous lance un regard de mépris et quitte votre cellule. Vous êtes un chevalier du roi, vous ne tarderez pas à être libéré.
Vous attendez des heures puis des jours, puis des mois. C''est à ce moment que vous vous rendez compte que le prêtre était votre seule chance de sortie, personne d''autre ne viendra.
C''est ainsi que fini votre espoir d''être libéré ainsi que votre vie <2,(vous perdez 50 pv),-50>.'
, 'mortEnPrison.jpg'),

-- Page 19 --
('Libéré, délivré', '- "Vous avez fait le bon choix Sir Godfroy."
Dit le prêtre non sans un sourire de satisfaction sur le visage.
Les gardes vous emmène dans une salle avec toutes vos affaires hormis les 8 pièces d''or prisent par le prêtre. Vous exprimez un soupire de soulagement en voyant la lumière du jour et les toits de pierre du village.
Maintenant que vous êtes libre, que faites-vous ?
<0,Aller dans le quartier marchand,12>
<0,Interroger les villageois,13>
<0,Mendier pour essayer d''obtenir de l''or,14>
<0,Essayer de trouver du travail,20>'
, 'libre.jpg'),

-- Page 20 --
('A la recherche d''un emploi', 'Si vous voulez avoir de l''or, pas le choix, il faut travailler.
Vous rejoignez la grande place et consultez le panneau des annonces à la recherche d''une offre intéressante.
Le gros du panneau est occupé par les offres des deux grande factions marchandes : Capital + et La Faucille Rouge.
Si vous avez *plus de 4 de chance*, allez <0,ici,22>, sinon allez <0,ici,21>.', 'annonces.png'),

-- Page 21 --
('Chômage', 'Vous parcourez le village pendant des heures en espérant trouver du labeur. Malgré toutes vos recherches vous ne trouvez aucun habitant qui aurait besoin d''aide. Il semblerait que tous les travaux manuels soient occupés, le business de la pierre est décidément florissant.
Malheureusement vous n''avez pas réussi à trouver une quelqu''on offre qui pourrait vous aider.
Que faites-vous maintenant ?
<0,Aller dans le quartier marchand,12>
<0,Interroger les villageois,13>
<0,Mendier pour essayer d''obtenir de l''or,14>
<0,Piller l''église,15>'
, 'sansTravail.png'),

-- Page 22 --
('Un dur labeur', 'Au milieu de tous ces papiers vous apercevez dans le coin une affiche proposant un travail dans un atelier de tailleur de pierre.
Vous travaillez durant quelques jours au milieu des pierres et des statues , votre rôle est surtout de créer et transporter des briques nécessaires à la construction c''est un travail particulièrement éprouvant car les briques sont très lourdes et les horaires sont épouvantables.
Finalement vos efforts s''avèrent être payant : vous obtenez <1,10 pièces d''or,14;10>.
Maintenant que vous avez de l''argent que faites vous ?
<0,Aller dans le quartier marchand,12>
<0,Interroger les villageois,13>
<0,Mendier pour essayer d''obtenir de l''or,14>
<0,Piller l''église,15>'
, 'gagnerArgent.png'),

-- Page 23 --
('Quelle direction ?', 'Vous vous dirigez vers la sortie est du village.
La porte du village est gardée par deux soldats de la milice local, c''est du moins ce que vous pensez au vu de leurs armures. Ils vous laissent sortir sans problème du hameau et vous empruntez le chemin qui mène vers l''est.
Alors que vous continuez votre route sur ce sentier, le chemin se sépare en deux routes biens distincts. Un panneau planté au milieu de l''intersection indique les deux itinéraires possibles :
- Forêt jolie
- Marais de la mort
Il n''y a pas d''autre passages vers l''est du pays à part en faisant un très long détour qui prendrait un temps fou, ce que vous ne pouvez pas vous permettre car la vie d''une princesse est en jeu !
Il faut vous hâter, dans quelle direction vous dirigez-vous ?
<0,La Forêt jolie,24>
<0,Les Marais de la mort,36>'
, 'panneauDirection.jpg'),

-- Page 24 --
('La Forêt jolie',
 'Après avoir parcouru un chemin de campagne, vous apercevez enfin la lisière de la Forêt jolie.
Vous prenez de la hauteur pour scruter les environs et voyez enfin ce que vous cherchiez : le légendaire Arbre de la vie.
En effet, au milieu de la forêt, surplombant les autres, se tient l''arbre le plus grand que vous n''avez jamais vu, il doit mesurer facilement dans les 200 mètres et semble bien plus âgé que le pays lui-même.
Vous vous souvenez des histoires de votre oncle Barnabé : un arme légendaire repose dans l''arbre mais seul les plus valeureux sont autorisés à mettre la main dessus. Cela ne devrait pas être un problème, vous avez déjà prouvé votre valeur à de multiples reprises comme lors du concours annuel du meilleur mangeur de tartes de votre village.
Sans perdre un instant de plus, vous <0,pénétrez dans les bois,25> plein de confiance.'
, 'foretJolie.jpg'),

-- Page 25 --
('L''attaque des gobelins'
, 'Alors que vous vous dirigez tant bien que mal en direction de l''arbre de la vie vous entendez des bruits étranges, pas ceux que l''on retrouve dans toutes les forêts mais plutôt ce qui semble être des pas rapides et discrets.
Soudainement, comme si votre hésitation était un signal, des créatures surgissent des buissons et du feuillage.
Devant et derrière vous, se tiennent des petites créatures vertes au nez et oreilles pointues, des gobelins !
Malgré le fait que leur équipement soit en bien piètre état, vous savez que leur nombre peut être problématique.
Celui qui semble être le chef s''avance d''un pas vers vous et lance à ses compagnons d''une voix stridente :
- "Allez les gars, faut pas qu''il nous échappe !"
Sans attendre une seconde de plus les gobelins se ruent sur vous, il faut vous défendre !
<8,Combat contre gobelins N°1,1>
<8,Combat contre gobelin N°2,1>
<8,Combat contre chef gobelin,2>
<7,Combat contre gobelin N°3,Suite à la mort de ses compagnions le dernier gobelin prend la fuite.;Gobelin N°3.>
Une fois les gobelins défaits, vous fouiller leur corps et ne découvrez rien de spécial hormis un bon petit butin de <1,11 pièces d''or,14;11>.
Vous pouvez désormais <0,continuer votre route,26>.'
, 'foretJolieInside.jpg'),

-- Page 26 --
('L''Arbre de la vie'
, 'Après quelques heures passées au milieu de la végétation, vous atteignez enfin votre destination : l''Arbre de la vie.
Vu dans face, l''arbre est encore plus impressionnant, même le château fait pâle figure comparé à ce colosse de bois et de feuille.
Un calme presque surnaturel régnait, comme si la forêt elle-même respectait se lieu ancestral.
Mais le plus étrange est la porte incrustée dans l''écorce de l''arbre. Vous vous approchez et tentez de l''ouvrir mais impossible, la porte est verrouillée.
Vous regardez autour de vous et semblez distinguer un homme allongé contre un arbre comme s''il dormait.
Peut-être sait-il comment rentrer?
Vous décidez donc de <0,vous diriger vers lui,27>.'
, 'arbreDeLaVie.jpg'),

-- Page 27 --
('Les Énigmes de l''Ancien'
, 'En vous approchant vous parvenez à mieux appréhender l''homme ou plutôt le vieil homme. En effet, la figure allongée devant vous possède la plus grande barbe que vous n''avez jamais vue, elle atteint presque le sol et cache une bonne partie de son corps tatoué d''étranges runes bleues.
Vous vous approchez encore un peu plus et voyez qu''il dort.
Alors que vous vous dirigez lentement vers lui, votre pied marche sur des branches.
Le bruit, bien que léger, semble réveiller le vieillard.
- "Ah vous êtes là, Sir Godfroy" dit-il calmement.
Le fait qu''il vous connaisse est surprenant car il n''y a même pas vu votre visage.
- "Comment connaissez vous mon nom ?"
- "Je suis bien informé."
Le vieil homme se releva et agrippa un bâton terminé d''une étrange pierre bleue et lança d''un air théâtral :
- "Je suis Allamar l''ancien, gardien des secrets et des trésors de l''Arbre de la vie."
- "Hé bien, l''ancien, je cherche à pénétrer dans cette arbre pour y récupérer une épée magique."
- "La légendaire Épée du Soleil Levant, elle vous sera utile dans votre humble quête si vous voulez défaire le drake."
Le vieil homme est décidément au courant de tout.
- "En tout cas, le seul moyen pour vous d''entrer est de prouver votre intelligence en résolvant mes énigmes : 
 Quel être, pourvu d''une seule voix, a d''abord quatre jambes le matin, puis deux jambes le midi, et trois jambes le soir ?"
Si vous pensez que la réponse est : la Mer noire, allez <0,ici,28>.
Si vous pensez que la réponse est : un homme, allez <0,ici,29>.
Si vous pensez que la réponse est : le Sphinx, allez <0,ici,28>.'
,'vieuxMage.jpg'),

-- Page 28 --
('Mauvaise réponse',
'- "Malheureusement c''est une mauvaise réponse, désolé mais vous ne pourrez pas entrer." répondit Allamar.
Avant même que vous ne puissiez dire quoique ce soit, le magicien brandit son bâton et une intense lumière bleutée vous aveugle.
Une fois votre vue retrouvée, vous constatez avec surprise que vous n''êtes plus en face de l''Arbre de la vie mais au milieu des arbres de la Forêt jolie.
Le message est clair, il ne servirait à rien de retourner vers l''arbre de la vie, ce maudit vieillard ne vous laissera pas une deuxième chance.
Alors que vous tentez de retrouver votre chemin, vous voyez au loin ce qui semble être un homme <0,s''approcher de vous,32>.',
'echecEnigme.jpg'),

-- Page 29 --
('2ème énigme',
'- "En effet chevalier, mais voici ma deuxième énigme :
j''ai 2 pieds, 4 jambes, 1 bras, 2 têtes et 4 yeux, qui suis-je ?"
Si vous pensez que la réponse est : la Mer noire, allez <0,ici,28>
Si vous pensez que la réponse est : une chimère, allez <0,ici,28>
Si vous pensez que la réponse est : un menteur, allez <0,ici,30>',
'hommeVinci.jpg'),

-- Page 30 --
('3ème énigme',
'- "Juste, voici ma dernière énigme :
Qu''est ce qui s''allonge et rétrécit en même temps ?"
Si vous pensez que la réponse est : une chenille, allez <0,ici,28>
Si vous pensez que la réponse est : la vie, allez <0,ici,31>
Si vous pensez que la réponse est : la Mer noire, allez <0,ici,28>',
'mensonge.png'),

-- Page 31 --
('L''Épée du Soleil Levant',
'Allamar hocha la tête de satisfaction et se dirigea vers la porte de bois.
Il sort une clé de sa barbe et l''insère dans la serrure avant de vous inviter à rentrer dans l''Arbre de la vie.
L''intérieur de l''arbre est aussi impressionnant que l''extérieur, les étagères de potions et les bibliothèques sont incrustées à même l''écorce, comme si elles avaient toujours été là.
Au milieu de la salle se tient l''objet de votre quête : la légendaire Épée du Soleil Levant.
L''épée est posée sur piédestal de bois, imposante et royale, elle semble presque trop lourde et encombrante mais une fois en main, vous constatez avec surprise que son poids correspond parfaitement à vos habitudes.
C''est avec un sentiment de puissance et d''accomplissement que vous décidez de quitter l''Arbre de la vie en emportant avec vous cette <3,arme légendaire (passe votre force à 10),10>.
Vous remerciez le vieillard et vous vous enfoncez dans la forêt jolie.
Alors que vous tentez de retrouver votre chemin, vous voyez au loin ce qui semble être un homme <0,s''approcher de vous.,32>',
'epeeLegendaire.jpg'),

-- Page 32 --
('Le bandit de grands chemins',
'Devant vous se tient un colosse fait de muscles au visage masqué. Cet homme ne vous inspire pas confiance.
- "La bourse ou la vie." dit-il tout simplement.
Vous avez affrontez de nombreux bandit durant votre vie, mais celui-là est à un tout autre niveau, vous hésitez presque à accepter son exigence.
Si vous décidez de garder votre bourse et de l''affronter, rendez-vous <0,ici,34>.
Si au contraire vous ne souhaitez pas prendre le risque de l''affronter et préférez céder votre or, rendez-vous <0,ici,33>.',
'banditRencontre.jpg'),

-- Page 33 --
('Le crime ne paie pas',
'L''affrontement avec ce brigand est une mauvaise idée, <1,vous donnez votre bourse,14;-50> au bandit non sans lui avoir jeté un regard mauvais.
Même si vous ne voyez pas son visage, vous imaginez bien son sourire sous ce masque.
- "Merci bien, Monseigneur." dit-il d''un air moqueur avant de déguerpir.
Vous tentez de vous consoler en vous disant qu''au moins il n''a pas voulu prendre le reste de votre équipement.
C''est en tentant d''oublier cette perte que vous décidez de <0,continuer votre route,41>.',
'vol.png'),

-- Page 34 --
('Stop au vol',
'- "Mauvaise réponse ..." dit le malandrin en sortant une hache.
Vous observez plus attentivement votre nouvel ennemi. Il possède une musculature très impressionnante ainsi que de multiples cicatrices de tous les âges. Vous remarquez sur son biceps droit un tatouage en forme de coeur avec “Mère” inscrit dessus ce qui contraste avec l''apparence barbare du voleur.
Vous vous préparez à votre tour pour affronter votre agresseur et protéger votre vie ainsi que votre bourse.
<8,Combat contre le bandit,3>
Une fois le combat terminé, vous décidez de <0,le fouiller,35>.',
'banditHache.jpg'),

-- Page 35 --
('Fouiller le bandit',
'Il est presque étonnant qu''une telle masse s''effondre devant vous. Le bruit de son poids au contact du sol semble être le seul son que vous percevez après lui avoir porté le coup de grâce.
Vous ne trouvez rien d''important sur le bandit hormis <1,un anneau en argent,17;1> ainsi qu''<4,un manteau de fourrure (augmente votre armure de 1),1> qui, à défaut d''être en bon état vous permettra de résister au froid.
Après votre fouille, vous décidez de <0,continuer votre route,41>.',
'manteauFourrure.png'),

-- Page 36 --
('Les Marais de la mort',
'Vous savez que le chemin le plus court pour rejoindre l''Antre des ténèbres consiste à passer par les Marais de mort. Sans attendre un instant de plus, vous reprenez votre route vers ce lieu maudit.
Après 1 heure de marche, vous entrez dans le marécage. C''est avec désarroi que vous constatez que la route s''arrête ici, il faudra continuer dans la boue.
C''est un lieu étrange et hostile, seuls de faibles rayons de lumière perce le feuillage des arbres tordus qui hantent le paysage. L''eau a un teint verdâtre et, à certains endroits, une sorte de fumée s''en dégage. Vous avez entendu dire que ces dernières sont toxiques, c''est donc avec une certaine prudence que vous continuez votre route.
Après ce qui vous semble être une éternité à patauger et esquiver les zones toxiques, vous apercevez au loin une lueur qui vous semble être d''origine humaine.
Tel un papillon attiré par la flamme d''une bougie, vous vous dirigez vers cette lumière.
Comme vous vous en doutiez, la lueur provient bel et bien d''une habitation. En effet, une vieille cabane est posée au milieu de l''eau.
Alors que vous vous approchez du minuscule cabanon, l''eau se met soudainement à bouillir et vous voyez une forme s''élever.
Vous êtes frappé d''horreur car devant vous se tient une abomination faite d''ossements et à la forme vous faisant penser à une araignée. Une étrange lumière violette brille entre les différents ossements, les maintenants reliés entre eux.
Vous calmez votre peur et cherchez une solution, si vous avez de *l''eau bénite*, allez <0,ici,37>, sinon rendez-vous <0,ici,38>.',
'maraisDeLaMort.jpg'),

-- Page 37 --
('Mort aux impies !',
'Vous vous souvenez que vous avez de l''eau bénite sur vous. Vous savez que ce genre de liquide est réputé pour son efficacité contre les créatures impies mais vous ne savez pas si ce sera suffisant.
Vous fouillez dans votre sac, prenez la fiole et attendez d''être à portée.
La créature s''approche de vous dans un effrayant craquement d''os.
Sans perdre un instant de plus, <1,vous lancez l''eau bénite,16;-1> sur le monstre et espérez que cela fonctionne.
Au contact de la substance divine, la chose se met soudainement à trembler de tout son corps squelettique en poussant un cri terrifiant avant de s''effondrer lourdement dans la vase.
Vous poussez un soupire de soulagement et décidez de <0,vous diriger vers la cabane,39>.',
'eauBenite.jpg'),

-- Page 38 --
('Mort aux impies !',
'Elle se déplace plus aisément que vous sur la vase et vous ne pourrez pas la distancer. Vous ne voyez aucun moyen d''échapper à cette chose, il n''y a donc pas d''autre option que de l''affronter directement.
Vous tentez de vous rassurer en vous disant que ce n''est pas la première fois que vous affrontez une créature vraisemblablement magique.
Vous attendez donc calmement que la créature soit à portée pour finalement attaquer.
<8,Combat contre l''araignée squelette,4>
Une fois cette créature vaincue, <0,vous vous dirigez vers la cabane,39>.',
'araigneeSqueletteRencontre.png'),

-- Page 39 --
('La cabane perdue au fond des bois',
'Située au milieu de racines tortueuses, la cabane est dans un piteux état. De la mousse verte s''est emparé des lieux, cependant la fumée d''une cheminée trahit la présence d''un occupant.
En tendant bien l''oreille, vous remarquez des bruits de métals qui s''entrechoquent et des liquides qui sont versés.
Vous décidez de frapper à la porte de la mystérieuse habitation, curieux de savoir qui peut bien vivre dans un endroit pareil. Vous toquez 2 fois fermement.
Le petit vacarme s''arrête brusquement et vous entendez des bruits de pas se rapprocher de la porte. L''individu entrouvre la porte de façon à ce que vous ne l''identifier pas et vous répond :
- "Que faîtes vous-ici ?" dit-il sèchement
- "J''ai besoin d''information, cela fait des heures que je cherche à rejoindre la toundra au nord-ouest, j''aimerais savoir si il y a une route près d''ici."
Le demeurant ferme la porte. Pendant un instant vous pensez qu''il vous signifie un refus, mais la porte se rouvre enfin. A votre grande surprise l''occupant de l''habitation n''est pas un homme.
C''est une vieille dame, trapue et plutôt grosse. Sa peau est couverte de ride et son visage est parsemé de grosses verrues noires. Si vous deviez décrire une sorcière, elle ferait le modèle parfait.
- "Entrez donc, je vais vous préparer un thé." dit-elle avec un sourire perturbant.
<0,Rester un moment,40> hors de la boue à éviter les gaz toxiques vous serait très agréable. Cependant si vous ne voulez pas prendre le risque d''entrer chez une sorcière vous pouvez tout aussi bien poliment décliner et <0,reprendre votre route,41>.',
'maisonDeSorciere.jpg'),

-- Page 40 --
('La sorcière',
'Vous décidez d''entrer dans la cabane. Si cette femme habite réellement ici, elle doit surement savoir si il y a un sentier qui passe par ici, cela vous éviterait de marcher dans la boue.
L''intérieur est bien plus propre que l''aspect extérieur et bizarrement il y a beaucoup plus de place que vous ne le pensiez. Des potions soigneusement étiquetées aux couleurs variées sont rangées dans des étagères qui couvrent la quasi-intégralité des murs. On y trouve aussi des livres, des ustensiles de cuisine et beaucoup de bibelots que vous pensez magiques. Un four artisanal est contre le mur, vous remarquez qu''il brûle d''un intense et mystérieux feu violet. Il y a aussi des marmites et des casseroles posées aux pied des murs.
Vous discutez brièvement avec la vieille dame. Elle raconte être une magicienne avant-gardiste qui a été rejeté par tout le monde. Vous vous doutez bien que cette vieille dame à "l''apparence innocente" pratique une magie défendue.
Votre hôte propose de vous vendre ces différents objets à "moitié prix" vous dit-elle :
- <2,Une potion de vitalité(+6 points de vie),6> pour <1,3 pièces d''or,14;-3>
- <5,Une potion du serpent(+1 d''agilité),1> pour <1,2 pièces d''or,14;-2>
- <6,Une potion de trèfle à quatre feuille(+1 chance),1> pour <1,2 pièces d''or,14;-2>
Elle vous propose également <10,d''enchanter votre arme (+2 de force),2> pour la modique somme de <1,5 pièces d''or,14;-5>. "Une de ces stupides bricoles d''enchanteur de magie bleue" vous a t-elle expliqué.
La vieille femme vous informe qu''il n''y a pas de sentier dans ces marais, il faudra donc continuer dans la boue. La boisson qu''elle vous a offerte est revigorante et vous sentez <2,vos forces revenir(+1 PV),1>
Une fois votre marchandage terminée et votre thé bu, <0,vous reprenez votre route,41>, bien décidé à terrasser le drake.',
'sorciere.jpg'),

-- Page 41 --
('L''Étoile du Nord',
'Vous avancez pendant quelques heures toujours dans la direction qui vous semble être l''ouest.
Vous exprimez un cris de joie en voyant peu à peu les arbres disparaitres.
Mais votre satisfaction est de courte durée, la végétation laissent place à une toundra.
Vous regardez avec inquiétude le soleil se coucher et le vent commencer à se lever. Il vous faut un abris.
Après avoir traversé un étendue gelée, vous apercevez un loin un bâtiment et vous précipitez vers ce dernier.
C''est avec soulagement que vous remarquez qu''il s''agit d''une auberge : "L''Etoile du Nord", sans perdre un instant de plus, vous entrez.
Vous êtes frappé par l''agréable chaleur d''un large feu au centre de la pièce. Comme vous vous en doutiez, il n''y avait pas énormément de client, essentiellement des marchands venus de lieux tous différents. Ce bâtiment n''est pas un marché, il sert plutôt de point de transition pour rejoindre les ports alentours et le coeur du royaume.
L''endroit est calme mais chaleureux, des hommes étaient réunis devant des cartes, un marchand étendait devant lui ses produits tandis que dans un coin, un homme à la mine grave dégustait une bière.
Que souhaitez-vous faire :
<0,Chercher un endroit pour se reposer,42>
<0,Aller vers l''homme dans le coin,44>
<0,Se diriger vers le groupe de voyageurs jouant aux cartes,49>
<0,Voir le marchand,48>
<0,Quitter l''auberge,53>',
'etoileDuNord.jpg'),

-- Page 42 --
('Trouver une chambre',
'Vous vous dirigez vers le comptoir où se tient l''aubergiste, un homme âgé couvert de rides. Il est prêt à vous donner une chambre pour 2 pièces d''or.
<0,Acceptez-vous cette offre,43> ou au contraire vous éloignez du comptoir et faire quelque chose d''autre :
<0,Aller vers l''homme dans le coins de la salle,44>
<0,Se diriger vers le groupe de voyageurs jouant aux cartes,49>
<0,Voir le marchand,48>
<0,Quitter l''auberge,53>',
'tavernier.jpg'),

-- Page 43 --
('Un repos bien mérité',
'Après avoir <1,payé le prix (2 pièces d''or),14;-2>, vous vous dirigez sans plus attendre vers votre chambre.
Elle est petite mais confortable et chaleureuse. Vous vous glissez confortablement dans le lit couvert de fourrures et sombrez dans un profond sommeil.
Vous ne savez pas combien de temps vous avez dormi, mais <2,vous êtes en pleine forme (vous récupérez 10 pv),10>. Vous examinez une carte sur le mur et constatez avec joie que vous approchez de l''Antre des ténèbres, il ne vous reste plus qu''à traverser cette région gelée pour arriver à votre destination et défier le Drake pour sauver Annabella des griffes de la bête.
Que souhaitez-vous faire maintenant ? :
<0,Aller vers l''homme dans le coin de l''auberge,44>
<0,Se diriger vers le groupe de voyageurs jouant aux cartes,49>
<0,Voir le marchand,48>
<0,Quitter l''auberge,53>',
'chambre.png'),

-- Page 44 --
('L''homme mystérieux',
'Vous observez attentivement l''homme situé à l''écart de tous.
A en juger par son turban et ses longues robes, cette homme vient des déserts du Sud, au-delà de la mer du sable.
Vous savez que ces homme sont généralement des marchands et des mystiques, mais à la vue de ses divers talismans et amulettes, vous optez pour la deuxième hypothèse.
Il possède peut-être de quoi vous aider dans votre quête, vous décidez donc de vous dirigez vers lui.
- "Qu''est ce que vous voulez ?" dit-il avec un fort accent, visiblement dérangé par votre présence.
Vous rétorquez :
- "J''ai vu que vous aviez l''air d''être un mystique, vous pourriez peut-être m''aider."
- "Ça dépend, vous avez quelque chose d''intéressant ?"
Si vous possédez une *perle luisante*, rendez-vous <0,ici,45>, sinon rendez-vous <0,ici,46>.',
'mystique.jpg'),

-- Page 45 --
('la mystérieuse pierre de Banzi',
'Vous sortez de votre sac l''étrange perle bleuté et la donnez à l''homme.
Ses yeux s''écarquillent à la vue de cet objet, prend la perle et sort un étrange instrument à pinces de sa robe.
L''homme place la perle entre les pinces et enclenche le mécanisme.
Un subtil bruit de rouages se fait entendre tandis que la perle se met à briller intensément d''une forte lumière bleue.
Ses étranges observations terminées, l''homme reprend sa mine sérieuse et vous dit :
- "Mon cher, vous avez en votre possession une pierre de Banzi, c''est un minerai très rare capable de canaliser la magie bleue, peu de personnes soupçonnent l''existence d''une telle pierre."
Vous êtes surpris de cette nouvelle, qui aurait pu croire qu''une babiole achetée à Casse-Roc ait autant de valeur.
Le mystique reprend :
- "Écoutez, j''ai une offre : je divise cette pierre en deux et je prend le fragments. En échange, je vous fabrique une amulette avec l''autre moitié. La puissance de la pierre reste importante, vous ne verrez quasiment pas la différence."
Si vous acceptez son offre, rendez-vous <0,ici,47>, sinon vous refusez poliment et regardez ce que vous pourriez faire.
<0,Chercher un endroit pour se reposer,42>
<0,Se diriger vers le groupe de voyageurs jouant aux cartes,49>
<0,Voir le marchand,48>
<0,Quitter l''auberge,53>',
'pierreBanzi.png'),

-- Page 46 --
('Sans intérêt',
'Vous sortez les divers objets de votre sac à la recherche d''un objet digne d''intérêt.
Malheureusement rien ne semble attirer l''attention de l''homme, il pousse un soupire et vous lance :
- "Écoutez, de toute évidence vous n''avez rien d''intéressant, alors je vais vous demander partir et d''arrêter de me faire perdre mon temps."
Vous remettez vos objets dans votre sac et quittez le mystique.
Que faites-vous maintenant ? :
<0,Chercher un endroit pour se reposer,42>
<0,Se diriger vers le groupe de voyageurs jouant aux cartes,49>
<0,Voir le marchand,48>
<0,Quitter l''auberge,53>',
'sacVide.jpg'),

-- Page 47 --
('Amulette magique',
'Vous acceptez son offre en <1,lui donnant la perle,15;-1> et vous le regardez se mettre à l''ouvrage avec une habileté déconcertante.
Après une dizaine de minutes, il vous tends <1,une amulette dorée sertie de la perles luisantes,6;1>.
Vous remerciez l''homme et retournez au centre de la pièce.
Que faites-vous ? :
<0,Chercher un endroit pour se reposer,42>
<0,Se diriger vers le groupe de voyageurs jouant aux cartes,49>
<0,Voir le marchand,48>
<0,Quitter l''auberge,53>',
'amuletteMagique.jpg'),

-- Page 48 --
('Le marchand de l''Orient',
'Vous vous approchez de l''homme étalant ses marchandises à la vue de tous.
Grâce aux yeux bridés du marchand, vous devinez qu''il est originaire des pays de l''Orient. Vous ne connaissez que très peu de choses sur ces peuples, en vérité, il n''y a quasiment que des marchands qui quittent leur pays, le reste préfère rester chez soi.
Vous admirez ses articles, on y trouve des épices, des pierres précieuses ainsi que certains équipements dignes d''intérêts.
Parmis ces objets certains ont attirés votre attention :
- Jambières encombrantes (<4,+2 armure,2> , <5,-1 agilité,-1>) pour <1,4 pièces d''or,14;-4>
- <5,Bottes de Pégase (+2 agilité),2> pour <1,2 pièces d''or,14;-2>
- <4,Vieux foulard (+1 chance et permet de résister au froid),1> pour <1,1 pièces d''or,14;-1>
- <3,Lance du Champion en argent (force = 9),9> pour <1,6 pièces d''or,14;-6>
- <3,Épée en acier (force = 7),7> pour <1,5 pièces d''or,14;-5>
Une fois vos achats terminés, vous remerciez le marchand et retournez au centre de l''auberge. Que faites-vous ?
<0,Chercher un endroit pour se reposer,42>
<0,Aller vers l''homme dans le coin,44>
<0,Se diriger vers le groupe de voyageurs jouant aux cartes,49>
<0,Quitter l''auberge,53>',
'balance.png'),

-- Page 49 --
('Le zrick',
'Vous vous dirigez vers le groupe de voyageurs, ils jouent à un jeu de carte hasardeux appelé le Zrick et bien sûr, de l''argent est en jeu.
- "Souhaitez-vous vous joindre à nous voyageur ?" vous lance un des protagonistes.
Si vous acceptez, rendez-vous ici, sinon vous refusez poliment et quittez le groupe pour voir ce que vous pourriez faire d''autre.
<0,Chercher un endroit pour se reposer,42>
<0,Aller vers l''homme dans le coin,44>
<0,Voir le marchand,48>
<0,Quitter l''auberge,53>',
'zrick.jpg'),

-- Page 50 --
('Une partie de zrick',
'Vous vous asseyez sur la chaise libre et rejoignez le groupe d''hommes, vous apprenez avec surprise qu''ils ne sont pas tous des marchands, l''un d''eux est un chasseur tandis qu''un autre est un soldat du roi.
Une fois les présentations terminées, vous distribuez les cartes et commencez à jouer.
Si vous avez *au moins 3 de chance*, <0,la fortune vous sourit,51> sinon vous êtes au contraire <0,frappé par le malheur,52>.',
'partieZrick.jpg'),

-- Page 51 --
('La chance vous souris',
'Vous êtes chanceux car tours après tours, vous obtenez de bonnes mains vous faisant remporter la mise.
Vous saluez vos nouveaux amis tout en emportant avec vous <1,5 pièces d''or,14;5>.
Que faites-vous maintenant ?
<0,Chercher un endroit pour se reposer,42>
<0,Aller vers l''homme dans le coin,44>
<0,Voir le marchand,48>
<0,Quitter l''auberge,53>',
'chance.png'),

-- Page 52 --
('Maudit',
'Malgré toute votre bonne volonté, vous ne parvenez pas à obtenir une seule bonne main. Vous tentez tant bien que mal de remonter mais pas moyen, vous pensez presque que vos adversaires trichent. Vous perdez <1,5 pièces d''or,14;-5> et décidez de quitter cette partie maudite avant de perdre beaucoup plus.
Que souhaitez-vous faire maintenant ?
<0,Chercher un endroit pour se reposer,42>
<0,Aller vers l''homme dans le coin,44>
<0,Voir le marchand,48>
<0,Quitter l''auberge,53>',
'malchance.png'),

-- Page 53 --
('La toundra',
'Vous quittez l''auberge et continuez votre route, heureusement le vent est tombé et vous avez évité la tempête, du moins c''est ce que vous pensiez.
A peine 1 heure après avoir repris votre route, le vent se lève d''abord calmement avant de se transformer en une tempête de neige.
A moins d''avoir *un manteau de fourrure* ou un *vieux foulard*, le froid vous <5,ronge les os et paralyse vos muscles (-1 agilité),-1>.
Vous apercevez au loin une forêt, elle pourrait peut-être vous offrir une protection contre le blizzard. Mais d''un autre côté, continuer de passer par la plaine est plus rapide.
Souhaitez-vous <0,passer par la forêt,57> ou <0,continuer dans la plaine,54> ?',
'toundra.jpg'),

-- Page 54 --
('Les plaines de glace',
'Vous avancer dans la neige au prix de grands efforts mais rien n''arrête votre volonté sauf peut-être la crevasse qui se tient devant vous.
Vous observez attentivement la faille à la recherche d''un moyen de l''éviter mais qu''importe la direction où vous regardez, il n''y a aucun autre accès.
Vous savez maintenant que le seul moyen de passer est tout simplement de sauter par dessus ce gouffre sans fond mais c''est plus facile à dire qu''à faire.
Soudainement le sol sous vos pieds s''affaisse, il est trop tard pour reculer, vous êtes obligé de sauter.
Si vous avez au moins *3 d''agilité* rendez-vous <0,ici,55>, sinon rendez-vous <0,ici,56>.',
'plaineDeGlace.jpg'),

-- Page 55 --
('Saut de l''ange',
'Vous sautez et retombez in extremis de l''autre côté de la crevasse. Mais vous décidez de ne pas profiter de cette victoire, la tempête est toujours là et vous continuez à être gelé.
Sans perdre une seconde supplémentaire, <0,vous continuez votre route en direction de l''Antre des ténèbres,61>.',
'sautCrevasse.png'),

-- Page 56 --
('Chûte de l''ange',
'Vous prenez votre élan et faites un saut digne des elfes les plus agiles, du moins c''est que vous croyez. En effet, même si votre saut est magnifique, votre atterrissage l''est beaucoup moins. Vous ne parvenez pas à atterrir au bon endroit, c''est même pire, vous chûtez dans le gouffre. Heureusement, vous parvenez à attraper au dernier moment une prise sur le rebord du ravin.
Vous vous hissez avec difficulté de l''autre côté de la faille et vous vous allongez sur le sol gelé pour reprendre votre souffle et inspecter votre état.
Heureusement, vous n''avez perdu aucun équipement mais vos côtes ont en pris un coup, vous pensez même que l''une d''elle est brisée, <2,vous perdez 2 PV,-2>.
Vous vous relevez en poussant un soupir de douleur et <0,continuez votre route en direction de l''Antre des ténèbres,61>.',
'chuteDuMur.jpg'),

-- Page 57 --
('Le wendigo',
'Vous vous enfoncez dans la forêt de sapin.
Comme vous l''espériez, les arbres vous protège d''un partie du vent, mais pile au moment où la température et le vent commençaient à être supportables, vous sentez un froid intense se lever, un froid tout sauf naturel, presque maléfique.
Vous voyez une forme se découper lentement à travers les arbres.
Votre coeur se gèle à la vue de cette créature de cauchemar. Vous remarquez qu''une étrange aura semble se dégager du corp décharné de la chose.
Vous vous souvenez avoir lu des ouvrages parlant de créatures maudites appelées "wendigo". Il est décrit que ces créatures errent dans les contrées gelées, piégeant les malchanceux dans une tempête de neige pour finalement les dévorer. Vous avez également lu que ces bêtes redoutes les armes en argent.
Possédez-vous de telles *armes en argent* ? Si c''est le cas rendez-vous <0,ici,58> sinon rendez-vous <0,ici,60>.
Ou encore si vous possédez un *anneau en argent*, rendez-vous <0,ici,59>.',
'wendigoRencontre.jpg'),

-- Page 58 --
('Une opportunité',
'Vous vous félicitez d''avoir pensé à acheter une arme de ce genre, car à peine avez-vous sorti votre équipement que le wendigo vous saute dessus avec agilité déconcertante. Heureusement, vous avez le réflexe d''enfoncer une partie de votre lance dans la chair gelée de votre ennemi, le faisant pousser un cri déchirant.
Un sourire de satisfaction se dessine sur votre visage à la vue de l''hésitation de la créature, le froid semble même avoir perdu en intensité.
C''est plein de confiance que vous vous ruez vers le wendigo pour en finir.
<8,Combat contre le wendigo affaibli,6>
Une fois le wendigo bannit, le froid surnaturel se dissipe et <0,vous continuez votre route avec aplomb,61>.',
'wendigoAffaibli.jpg'),

-- Page 59 --
('Une opportunité',
'Vous mettez l''anneau autour de votre doigt et sortez votre arme en espérant que cela puisse faire la différence.
Soudainement, le wendigo vous bondit dessus avec une agilité déconcertante.
Mais il n''arrive pas à vous atteindre car au même moment, votre anneau se met à briller d''une puissante lumière blanche.
Une puissante explosion se produit, propulsant le monstre contre les arbres.
Un sourire de satisfaction se dessine sur votre visage à la vue de l''hésitation de la créature, le froid semble même avoir perdu en intensité.
C''est plein de confiance que vous vous ruez vers le wendigo pour en finir.
<8,Combat contre le wendigo affaibli,6>
Une fois le wendigo bannit, le froid surnaturel se dissipe et <0,vous continuez votre route avec aplomb,61>.',
'lumiereBenie.jpg'),

-- Page 60 --
('Une bête de cauchemars',
'Vous sortez votre arme et vous vous préparez à affronter le wendigo. C''est avec une agilité déconcertante pour sa masse, que ce dernier vous bondit dessus. Au dernier moment, vous esquivez avec souplesse mais déjà la créature se retourne vers vous.
Son apparence est peut-être frêle, mais son agilité et sa puissance compensent son physique.
Vous vous replacez en face de votre ennemi et vous vous préparez à contre-attaquer.
<8,Combat contre le wendigo,5>
Une fois le wendigo bannit, le froid surnaturel se dissipe et <0,vous continuez votre route avec aplomb,61>.',
'wendigo.jpg'),

-- Page 61 --
('Dernier repos',
'Vous ne savez pas combien de temps vous avez marché dans cet enfer gelé mais vous remarquez avec plaisir que le paysage change.
Les plaines glacées laissent place à des montagnes de plus en plus abruptes mais en cela vous importe peu car <5,une douce chaleur remplace le froid (+1 agilité),1>.
Au fur et à mesure que vous progressez, vous notez que la nuit commence à tomber, il vous faut abri. Heureusement à la différence de la toundra, vous trouvez facilement de quoi manger et faire un feu.
Vous vous endormez à la chaleur des braises <2,(vous regagnez +6 PV),6>.
La douce lumière du soleil vous réveille et c''est avec assurance que <0,vous continuez votre voyage,62>.',
'feuDeCamp.png'),

-- Page 62 --
('L''Antre des ténèbres',
'C''est après quelques heures de marches intensives, vous regardez avec inquiétude les nuages devenir de plus en plus sombres et oppressants tandis que les montagnes semblent se recouvrir de cendres.
C''est la mine grave que vous constatez que vous êtes arrivé à destination, vous avez enfin atteint l''Antre des ténèbres.
Vous préférez presque la toundra. À la place des étendues. glacées se tiennent des cascades de laves en fusion, ces dernière coulent des montagnes déchirées et des tours de basalte pour former des lacs de magma. Au loin, un château se distingue des autres bâtiments en ruine, cela doit être le repaire du Drake.
Vous vous dirigez vers la citadelle sous le regard d''étranges créatures cachées dans les diverses crevasses et décombres. Vous ne parvenez pas à distinguer leur forme mais vous vous dites que c''est presque préférable, qui sait quelles horreures hantent ces lieux.
Après une longue marche au milieu d''une chaleur étouffante, vous atteignez enfin l''entrée du château du Drake. Soudainement, vous ressentez une certaine hésitation, derrière cette porte se tient l''ennemi le plus dangereux que vous n''ayez jamais affronté. Mais après tout, vous n''avez pas fait tout ce voyage pour rien, vous n''avez pas bravé tous ces dangers pour vous dégonfler comme un lâche.
La tête pleine de pensées réconfortantes, vous poussez la lourde porte de fer et entrez.
L''intérieur est aussi grand qu''une cathédrale, vous ne voyez même pas le plafond. Vous suivez le long couloir jusqu''à arriver dans une large zone circulaire, un énorme tas d''or et de richesses diverses se tient au centre.
Soudainement, vous voyez les flammes des torches et des braseros prendre une teinte violette.
Une forme sort de l''ombre. Etes-vous passé par les *Marais de la mort* ? Si c''est le cas, rendez-vous <0,ici,63>, dans le cas contraire, allez <0,ici,64>.',
'chateauDragon.jpg'),

-- Page 63 --
('La révélation',
'Vous reconnaissez la figure sortie de l''ombre : c''est la sorcière que vous avez rencontrée dans les Marais de la mort !
- "Ho, c''est vous." dit-elle dans un ricanement.
Vous répliquez d''un ton presque confu :
- "Où est le Drake ?!"
La vieille dame vous répond avec un sourire amusé :
- "Vous n''avez pas encore compris, preux chevalier ? Je suis le Drake, je suis Nazasiar le Drake des cendres !"
Au moment même où elle finit sa phrase, une violente lumière violette se dégage de son corps.
Une fois votre vue retrouvée, vous constatez avec horreur qu''à la place de la sorcière se tient le Drake qui vous a attaqué à la sortie du château.
Vous sortez votre arme prêt à combattre la bête mais vous remarquez avec inquiétude votre adversaire prendre sa respiration. Il va tenter de vous occire avec ses flammes infernales !
Possédez-vous l''*Épée du Soleil levant*, une *arme enchantée*, ou le *Talisman gravé* ? Si vous avez au moins 1 des ces objets, rendez-vous <0,ici,66> sinon rendez-vous <0,ici,65>.',
'drakeRencontre.jpg'),

-- Page 64 --
('Le drake',
'A votre plus grand étonnement, la figure sortant de l''ombre est une vieille femme particulièrement hideuse, elle vous fait presque penser à une sorcière.
Vous questionnez la femme sur sa présence en de tels lieux. Elle vous répond avec un sourire mauvais :
- "Je ne fait que passer."
Vous n''êtes pas dupe, une vieillarde n''est pas là pas par hasard, c''est peut-être une servante du Drake ? Décidé à en savoir plus, vous lui lancez d''un ton autoritaire :
- "Je ne vous crois pas, dites moi immédiatement où est le Drake et sa prisonnière Annabella !"
- "Alors comme ça vous êtes là pour la fille, désolée, mais elle reste là. Partez !"
- "Hors de question ! Je ne quitterai pas cette endroit sans la fille du Roi !"
- "Dans ce cas, finissons-en."
Au moment même où elle finit sa phrase, une violente lumière violette se dégage de son corps.
Une fois votre vue retrouvée, vous constatez avec horreur qu''à la place de la vieille femme se tient le Drake qui vous a attaqué à la sortie du château.
Vous sortez votre arme prêt à combattre la bête mais vous remarquez avec inquiétude votre adversaire prendre sa respiration. Il va tenter de vous occire avec ses flammes infernales !
Possédez-vous l''*Épée du Soleil levant*, une *arme enchantée*, ou le *Talisman gravé* ? Si vous avez au moins 1 des ces objets, rendez-vous <0,ici,66> sinon rendez-vous <0,ici,65>.',
'drakeRencontre.jpg'),

-- Page 65 --
('Si prêt du but',
'Une vague de flammes violette surgissent de la gueule de Nazasiar , engloutissant toute la salle. Vous vous rendez compte qu''il n''y aucun moyen d''éviter cette attaque. Vous vous précipitez vers une colonne pour tenter de vous mettre à l''abri. Malheureusement cela ne suffit pas, les flammes vous dévore et vous rôtisse comme un poulet.
C''est dans le ventre du Drake que se <2,termine tragiquement votre aventure (vous perdez 50 PV),-50>.',
'flammeViolette.jpg'),

-- Page 66 --
('Le combat final',
'Une vague de flammes violette surgissent de la gueule de Nazasiar, engloutissant toute la salle. Mais au moment où vous pensez que tout est fini, vous voyez une lumière bleue se dégager de votre équipement. Un dôme translucide vous entoure et vous constatez avec soulagement que les flammes ne vous atteignent pas.
Vous pouvez voir à la mine étonnée du Drake que vous avez contré son arme principale. Néanmoins, il reste un adversaire dangereux : ces griffes sont puissantes, ses écailles résistantes et vous ne voulez pas vraiment tester l''effet de sa gueule garnie de croc sur votre corps.
C''est en faisant le vide dans votre tête que vous vous ruez le monstre pour profiter de votre avantage.
<8,Combat contre le Drake,7>
Une fois votre ennemi juré vaincu, vous vous ruez vers une <0,porte située tout au bout de la salle,67>.',
'drake.jpg'),

-- Page 67 --
('VICTOIRE !',
'Vous entrez dans un cachot crasseux, vous regardez attentivement dans chaque cellule dans l''espoir de retrouver la fille du roi.
Soudainement, vous repérez avec joie celle que vous devez sauver. Annabella est surprise de vous voir mais vous dit avec soulagement :
- "Sir Godfroy, j''étais sûr que vous viendrez, je vous en prie faites moi sortir de ce lieu horrible."
Sans perdre un instant de plus, vous trouvez les clés de la cellule et libérez la princesse.
Heureusement, la route jusqu''au château du Roi se fait sans encombre, comme si désormais, les créatures des ténèbres vous craignaient.
Vous êtes accueilli par tout Casse-Roc ainsi que par le Roi. Pour l''occasion, ce dernier porte son armure dorée.
Une fête est organisée pour célébrer votre victoire !
C''est ainsi que se termine l''épopée de Sir Godfroy, Votre épopée !
<7,FIN,Merci beaucoup d''avoir joué à ce jeux! Nous espérons que vous avez apprécié. Johan et Leandro;fin>',
'victoire.png');

INSERT INTO Player (hp, force, armor, agility, luck, name, idActualPage, inactiveLinks) VALUES (10, 3, 1, 5, 2, 'Godfroyd', 3, 0);

INSERT INTO Item (name, hp, force, armor, agility, luck) VALUES
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

INSERT INTO Enemy (hp, force, armor, agility, luck, name, image) VALUES 
(10, 3, 1, 4, 3, 'Gobelin', 'gobelin.jpg'),
(16, 5, 2, 5, 4, 'Chef gobelin', 'chefGobelin.jpg'),
(35, 5, 1, 2, 3, 'Bandit', 'bandit.jpg'),
(25, 4, 3, 3, 0, 'Araignée squelette', 'araigneeSquelette.png'),
(30, 4, 1, 6, 2, 'Wendigo', 'wendigo.jpg'),
(20, 3, 0, 3, 1, 'Wendigo affaibli', 'wendigoAffaibli.jpg'),
(50, 7, 3, 4, 0, 'Drake', 'drake.jpg');