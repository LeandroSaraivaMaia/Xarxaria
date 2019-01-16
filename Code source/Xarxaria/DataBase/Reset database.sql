USE XarxariaDB;

-- Suppression des tables
DROP TABLE IF EXISTS Enemy;
DROP TABLE IF EXISTS Player_Item;
DROP TABLE IF EXISTS Player;
DROP TABLE IF EXISTS Item;
DROP TABLE IF EXISTS Page;
DROP TABLE IF EXISTS Inventory;

-- Cr�ation des tables
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

GO

-- Insertion des donn�es --
INSERT INTO Page (title, text, image) VALUES
-- Page 1 --
('Introduction', 'C''est l''histoire d''un pays tranquille. Un jour, un vilain drake kidnappe une des princesses du royaume.
Le Roi, furieux, convoque tous ses chevaliers � la table carr�e.
Malheureusement, tous les chevaliers sont en croisade dans le pays voisin.
Mais il reste un seul chevalier � la cour, le fameux Sir Godfroyd de Monaco. C''est le chevalier le plus valeureux de tout le royaume.
Il a d�j� prouv� sa valeur a de nombreuse reprises en sauvant moultes princesses.
Le courageux chevalier est tr�s d�cid� � sauver la princesse du Roi. Il d�pense toutes ses �conomies et ach�te le meilleur �quipement du royaume pour sa qu�te.
Quelques lieues apr�s �tre sorti du ch�teau, il est frapp� par ce qui lui semble �tre un �clair. Une grande ombre noire d�chirant les cieux � une vitesse vertigineuse le renverse. Il est violemment �ject� de la route et finit dans un caniveau boueux.
Apr�s avoir repris ses esprits, il aper�oit une b�te ail� s''�loigner, le drake. Il se rend compte que son �quipement a enti�rement disparu. C''est sans doute l''oeuvre de la magie noire du drake.
Il a eu beaucoup de chance de s''en r�chapper vivant.
C''est l� que votre aventure commence, vous �tes ce chevalier.
<0,Continuer,3>'
, 'paysage.jpg'),

-- Page 2 --
('Liste des actions', 'Liste des actions :
0 Changement de page
1 Modifier un objet
2 Modifier les pv
3 Mettre la force
4 Modifier l armure
5 Modifier l agilit�
6 Modifier la chance

<1,Ajouter 3 pi�ces d or,0;3>
<1,Supprimer 2 pi�ces d or,0;-2>
<2,Gagner deux pv,2>
<2,Perdre un pv,-1>
<3,Mettre la force � deux,2>
<4,Ajouter 2 d''armure,2>
<4,Enlever 1 d''armure,-1>
<5,Gagner deux d agilit�,2>
<5,Perdre un d agilit�,-1>
<6,Gagner deux de chance,2>
<6,Perdre un de chance,-1>
<0,Allez � la page 3 (Le commencement,3>', 'paysageAvecPortail.jpg'),

-- Page 3 --
('Le commencement', 'Vous vous relevez avec le peu de dignit� qui vous reste. Pendant une seconde vous pensez retournez au ch�teau pour retrouver de l''�quipement. Mais vous vous ravisez, avec une telle d�gaine, vous ne passerez jamais les grilles du ch�teau.
Et revenir voir le Roi � peine 1 heure apr�s �tre sortit pour sauver sa fille, quel honte !
De toute fa�on vous arriverez � trouver du nouvel �quipement, apr�s-tout vous �tes le meilleur chevalier du pays !
A pr�sent il vous faut du mat�riel, que voulez-vous faire ?
<0,Continuer vers le village,11>, � la sortie du ch�teau ou <0,oublier son honneur et aller au ch�teau,4>', 'villageEtChateau.jpg'),

-- Page 4 --
('Oublier son honneur et aller au ch�teau', 'Finalement vous vous r�signez � retourner au ch�teau. Combattre un drake avec uniquement de l''�quipement trouv� sur la route est une mauvaise id�e.
Vous faites le chemin inverse et apercevez que deux gardes royaux ont �t� post�s � c�t�s de la grille du ch�teau. Une fois � l''int�rieur de la grande cour, vous pourrez facilement passer vers les quartiers du Roi gr�ce � un passage secret qui y m�ne directement.
Le ponts levis est abaiss� et vous pourriez vous approcher des gardes et esp�rer qu''ils vous laissent passer. Vous �valuez la situation et vous vous souvenez du vieux mur ouest qui s�pare la cour du monde ext�rieur.
Ce mur du ch�teau est mal entretenu et de solides lianes ont investi la paroi. Vous connaissez l''endroit et vous savez que le Roi n''entretient que les murs les plus visible pour ne pas montrer que le royaume est ruin�. Vous pouvez tenter d''escalader le mur en vous aidant des lianes mais c''est plut�t risqu� car la muraille doit bien faire 5 m de haut.
Apr�s quelques minutes suppl�mentaires, aucun autre moyen d''entrer dans le ch�teau ne vous vient � l''esprit.
Vous devez choisir entre <0,passer par l''entr�e principale,8> en esp�rant que les gardes vous reconnaissent ou <0,escalader le mur,5> en esp�rant que les lianes ne l�chent pas.
Vous pouvez aussi choisir de <0,rebrousser chemin(continuer au village),11>', 'chateau.jpg'),

-- Page 5 --
('Escalader le mur du ch�teau', 'Vous fa�tes un grand d�tour pour ne pas que les gardes vous voient et vous vous approchez discr�tement de la muraille.
Vous regardez le haut du mur que vous vous �tes d�cid� � grimper. De l� il a l''air bien plus imposant.
Vous vous �chauffez les articulations en appr�hendant la mont� qui vous attend, vous ne percevez aucun garde patrouillant le long du mur.
Apr�s avoir choisi le parcours avec les plus grosses lianes, vous entamez l''escalade avec �nergie. Vous aviez d�j� eu affaire � des parois escarp�es auparavant et cette grimpette ne vous semble pas si difficile.
Soudain, vous sentez que vous perdez prise.
Si vous �tes assez agile pour vous rattraper (4 points d''agilit� ou plus), rendez-vous <0,ici,7>. Si vous �tes un peu plus pataud, alors allez <0,ici,6>.
', 'murailleAvecLierre.jpg'),

-- Page 6 --
('Vous n''arrivez pas � escalader le mur', 'Vous vous accrochez de toute vos forces aux lianes.
Cependant vous semblez quand m�me tomber, ce ne sont pas les lianes qui vous l�chent mais la brique !
Vous chutez in�vitablement et essayez de trouver une position pour moins morfler � l''atterrissage. Vous vous ramassez par terre en tombant sur les fesses et <2,perdez 2 points de vie,-2>.
Par chance la brique qui a chut� avec vous retombe un m�tre sur votre gauche et non sur votre t�te. Par contre elle cause un bruit tr�s fort et soudain qui a � coup s�r alert� les gardes.
Vous vous relevez p�niblement et vous entendez des cris. Les gardes vous ont rep�r�s. Ils sortent leurs armes et vous ordonne de vous rendre.
Vous courez � toute allure en direction du village sans parvenir � semer les gardes.
D�cid� � leurs �chapper, vous sautez dans ce qui vous semble �tre la meilleur cachette � l''heure actuelle : le caniveau.
Vous bondissez dans la rigole et vous vous tapissez au fond en ayant presque de l''eau jusqu''� la bouche. Vous apercevez les gardes en haut depuis votre planque. Votre cachette fonctionne � merveille, vous �tes invisible pour eux.
Apr�s quelques minutes les deux gardes abandonnent la poursuite, �a tombe bien vous commenciez � avoir froid. Vous sortez du caniveau apr�s �tre s�r que les gardes soient partie et vous vous nettoyer du mieux que vous pouvez avec la v�g�tation alentoure.
Vous ne pouvez d�cemment pas retentez d''entrer dans le ch�teau en passant par la grille principale car les gardes vous reconna�tront et vous chasserons.
Vous devez donc <0,continuer votre route en direction du village,11> pour d�nicher des informations sur le drake.', 'chuteDuMur.jpg'),

-- Page 7 --
('Vous r�ussissez � grimper le mur', 'In extremis, vous l�chez la prise de votre main droite et bondissez en for�ant sur vos jambes pour atteindre le sommet de la muraille. Il s''en est fallu de peu, car ce n''est pas les lianes qui vous ont l�ch�es mais une brique de la muraille. Vous craignez que le bruit est attir� les gardes alors vous devez faire vite.
Vous vous hisser p�niblement pour atteindre le haut du mur et appr�ciez alors votre nouvelle vue de la splendide cour du ch�teau entour�e de sa muraille de roche de luxe. Vous savez que ce ch�teau ne sert qu''aux visites diplomatiques et qu''il est strat�giquement obsol�te.
A pr�sent il vous faut passer par le passage secret � l''int�rieur de la cour. Vous remarquez une �norme botte de foin juste en bas de la muraille c�t� int�rieur, ce sera parfait pour amortir votre chute.
Vous sautez gracieusement tel un assassin et atterrissez en douceur sur le lit de paille.
Vous vous dirigez rapidement vers l''arri�re de l''�curie et red�couvrez la trappe secr�te d�sormais couverte de v�g�tation.
Vous d�gagez les plantes et ouvrez la trappe avec difficult�. Vous glissez avec lenteur dans ce tunnel �troit et compl�tement sombre pendant 5 bonnes minutes avant de t�ter la sortie des doigts.
Vous ouvrez avec vitalit� la sortie pour r�cup�rer un peu d''air frais. Alors que vous vous �tirer, vous constatez que vous n''�tes pas dans la chambre du Roi mais dans celle de ses filles.
Vous reconnaissez instantan�ment toutes les princesses : Am�lia, Anastasia, Amanda, Anna, Aphrodita, Adelinda, Agatha, Adriana, Antonella, Ang�lica, Alessandra, Antoinetta et Angella. Il manque Anabella, la princesse que vous �tes charg� de sauver.
Vous semblez avoir interrompu les princesses pendant qu''elles se coiffaient mutuellement. Elles forment un cercles autour de vous.
- �Aaah, alors c''est � �a que servait cette trappe� lan�a Amanda.
- �Nous sommes toutes ravies de vous revoir Sir !� continua Anna.
- �Vous allez sauver notre soeur pas vrai ?� s''inqui�ta Alessandra.
- �Encore merci de m''avoir sauv� de cette ogre l''autre fois !� s''exclama Adelinda.
Apr�s d''autres acclamations, vous expliquez la situation et Am�lia vous r�ponds :
- �Notre p�re est occup� avec ses bibelots, c''est � croire qu''il se souci plus de son armure que de nous��
Toutes les princesses prennent une mine triste et, apr�s un court silence, Anastasia reprends la conversation :
- �Il ne vous donnera pas d''�quipement de qualit�, cependant nous pouvons vous donner ceci :�
Antonella s''empresse de regarder sous un lit pour y sortir avec l''aide d''Aphrodita <3,une hache d''armes en acier tremp� (Passe votre attaque a 5),5>
Apr�s de chaleureuses salutations Agatha vous montre un passage secret qui m�ne directement � l''ext�rieur du ch�teau.
Vous repartez en <0,direction du village,11> bien d�cid� � sauver Anabella.', 'courDuChateau.jpg'),

-- Page 8 --
('Passer par l''entr�e principale', 'Vous d�cidez d''aller directement vers la porte principale en esp�rant que les gardes vous laissent entrer, ils reconna�tront s�rement le meilleur chevalier du royaume.
Il y en a un tout gros et un tout maigre, le premier p�se sans doute le double du deuxi�me. 
Vous vous lancez sur le pont levis d''un pas d�cid�. Au fur et � mesure de votre avanc�e, les gardes vous d�visagent de plus en plus.
Vous vous rappelez que vous sentez encore les excr�ments et que vous �tes un peu tremp�. C''est alors que vous vous souvenez que les gardes ont pour ordre de chasser les mendiants de l''enceinte du ch�teau.
Vous appr�hender moins bien la situation et une fois � la hauteur des gardes le plus maigre vous adresse la parole d''un ton agressif :
- �Z''�tes qui et qu''est-ce que vous faite l� ?, c''est pas pour les mendiants ici�
Vous r�torquez en �tant faussement s�r de vous :
- �Je suis Sir Godfroy de Monaco, je vous ordonne de me laisser passer !�
Si vous avez plus de 4 points de chance, rendez-vous <0,ici,9> et si vous �tes malchanceux, rendez-vous � cette <0,page,10>.
', 'garde.jpg'),

-- Page 9 --
('Les gardes vous reconnaissent', 'Imm�diatement, les gardes se raidissent et le plus maigre vous dit :
- �Oh, navr� Sir je ne vous avais pas reconnu, je vous en pris entrez�
Soulag�, vous imitez un air de d�dain et entrez � grand pas dans la cour.
Les nobles vous d�visagent pendant que vous vous dirigez rapidement vers la salle du tr�ne. �tonnamment il n''y a aucun autres gardes � l''int�rieur et vous pouvez entrer sans probl�me dans la chambre du Roi.
Vous frappez contre la porte et vous entendez une voix famili�re :
- �Encore vous ?! Je vous ai dit que je n''�tais pas int�ress� � vendre le Royaume !�
Vous ouvrez la porte et entrez.
- �Sir Godfroyd ? � Mais que vous ait-il arriv� ? Je croyais que c''�tait encore ces foutus marchands de Capital +�
Vous surprenez le Roi en train de polir son casque en or. Sa chambre est extr�mement bien d�cor�e compar�e au reste du ch�teau. Une immense vitrine ouverte contenant un �quipement complet en or tr�ne en face de son lit � baldaquin.
Il vous regarde d''un air ahuri et vous r�torquez:
- �Je me suis fait directement attaqu� par le drake � la sortie du ch�teau. Il m''a renvers� et a utilis� sa magie noire pour faire dispara�tre tout mon �quipement.�
Il se remet � astiquer son casque et prend un air d�sint�ress�.
- �Ah ce maudit drake, il attaque de plus en plus pr�s� En quoi puis-je vous �tre utile ?�
- �J''aurais besoin d''�quipement pour tuer le drake et sauver votre fille Anabella. Toutes mes �conomies �taient pass� dans mon armure, mon arme et mon cheval�
- �Oui, je vois mais... Tu sais que le royaume n''a pas au top niveau finance, je vais voir ce que je peux te pr�ter�
Il saisit un vieux coffre sous son lit et en sort un plastron et une arme.
- �C''est tout ce que je peux me permettre de te pr�ter, tiens et n''oublie pas de me les rendres hein.�
Vous recevez <4,un plastron en fer rouill� (armure + 3),3> et <3,une �p�e d''entrainement (passe votre force � 2),2>. Apr�s de bref salutations vous reprenez votre route <0,vers le village,11> � la sortie du ch�teau.', 'chambreRoi.jpg'),

-- Page 10 --
('Les gardes ne vous reconnaissent pas', 'Apr�s un long moment g�nant, le plus gros des gardes reprend la conversation :
- �Ordre. Halte. Clodo. �
L''autre garde continue :
- �Vous pouvez pas rester ici m''sieur, partez maintenant�
Il vous jette <1,une pi�ce d''or,0;1> au visage et les deux gardes l�vent leurs armes.
Dans une derni�re tentative vous dites :
- �Vous ne me reconnaissez pas ?, Godfroyd le meilleur chevalier du royaume, j''ai sauv� un tas de princesse !�
Vous semblez �tre la seul distraction de ces deux gardes depuis longtemps, ils vous poussent et vous menace de leurs armes :
- �Dehors l''ivrogne ! La seul chose que vous pourriez sauver c''est une bouteille de vin�
Vous commencer � courir quand vous remarquez que les deux gardes se mettent � vous suivre. Non, il vous poursuive !
Vous courrez pendant au moins 3 quart d''heure en direction du village, Finalement vous parvenez � semer les gardes, ils rebroussent chemin en vous injuriant.
Vous reprenez votre souffle. Pas question de retourner au ch�teau avec ces deux gardes aux aguets.
Vous devez donc <0,explorer le village,11> � la recherche d''indice pour savoir o� s''est envol� le drake qui vous a attaqu� r�cemment, peut-�tre que les villageois l''ont vu passer.', 'fuite.jpg'),

-- Page 11 --
-- Page temporaire de fin de version
('Fin de la d�mo !', 'F�licitations !
Vous �tes arriv� � la fin de la version 1.0 !
Merci d''avoir jou� !'
, 'casseRoc.jpg'),
/*
('Casse-Roc', 'Vous vous dirigez donc vers le village situ� � la sortie du ch�teau.
C''est un petit hameau tranquille nomm� Casse-Roc o� les habitants sont principalement des mineurs. Il y a de grandes carri�res de pierre tout autour du village. Non en faite� le village est une carri�re de pierre !
Vous n''avez jamais mis les pieds ici car vous �tes toujours au ch�teau ou en croisade dans les pays voisins. Cependant vous avez entendu des rumeurs sur cette endroit. Un jour petit un feu s''est d�clar� et la quasi-totalit� du village s''est embras� car toutes les maisons �taient en bois � l''�poque. La plupart des habitants �taient � la rue. Depuis ce jour les habitants se sont mis � construire leur maison directement dans la roche et maintenant le village vit de l''extraction de la pierre.
Vous remarquez aussi que l''int�gralit� du village est abaiss� d''une dizaine de m�tres dans le sol. L''extraction massive de pierre doit en �tre la cause, en effet pendant que vous marchez, vous croisez des mineurs qui creusent directement sur le sol du village.
Le village est principalement un terrain vague peupl� de mineurs acharn�s. Il y a beaucoup de personnes et beaucoup d''agitation avec les �clats de pierre et les pioches qui volent dans tous les sens. Des rails, en pierre, ont �t� install�s pour faciliter les all�es et venues incessantes de wagons remplis de roche.
Ce qui vous perturbe le plus est l''omnipr�sence de la roche dans ce village. Les pioches, les wagons, les poteaux, les banderoles, les b�timents et m�me les casquettes des habitants sont en pierre ! Vous vous sentez rassur� en voyant un habitant manger des pommes de terre.
Comme vous aviez pr�vu initialement, vous devez trouver des informations concernant le drake, vous devez maintenant choisir ce que vous allez faire :
<0,Aller dans le quartier marchand,12>
<0,Interroger les villageois,13>
<0,Mendier pour essayer d''obtenir de l''or,14>
<0,Piller l''�glise,15>
<0,Essayer de trouver du travail,20>'
, 'casseRoc.jpg'),
*/

-- Page 12 --
('Le forgeron', 'Vous vous promener un peu et vous trouvez un quartier marchand. A pars quelques mineurs � la t�che, le march� est quasiment d�sert. Il fait encore t�t donc cela ne vous �tonne pas trop.
Vous remarquez que toute l''�conomie locale est bas�e sur la pierre. Des bijoux aux ustensiles de cuisine, la plupart des articles sont en pierre. Alors que vous pensez reconna�tre les briques du ch�teau dans une �choppe de ma�onnerie, vous trouvez enfin une boutique int�ressante, l''armurerie.
C''est le plus petit magasin du march� avec ce qui semble �tre le forgeron du village au vue de son tablier et de l''enclume en pierre derri�re lui. Vous n''�tes plus surpris que les articles propos�s sont exclusivement fait en pierre.
Les objets suivants sont pr�sent�s sur l''�tale de la marchande :
<3,Une massue en pierre,3>(Votre force passe � 3) pour <1,4 pi�ce d''or,0;-4>
<4,Une casquette de mineur en pierre,1>(armure + 1) pour <1,2 pi�ce d''or,0;-2>
<3,Une dague en pierre,2>(Votre force passe � 2) pour <1,2 pi�ce d''or,0;-2>
<1,Une �trange perle luisante,1;1> pour <1,1 pi�ce d''or,0;-1>
Une fois vos achats effectu�s, vous pouvez :
<0,Interroger les villageois,13>
<0,Mendier pour essayer d''obtenir de l''or,14>
<0,Piller l''�glise,15>
<0,Essayer de trouver du travail,20>'
, 'forgeron.jpg'),

-- Page 13 --
('La Taverne du mineur assoif�', 'Vous savez que le meilleur moyen d''obtenir des informations se trouve dans les tavernes.
Sans attendre un instant de plus vous vous dirigez vers un b�timent nomm� selon la banderole plac�e devant �La taverne du mineur assoiff�.
Vous �tes accueilli par la douce chaleur d''un feu de chemin�e ainsi que par le brouhaha si commun � un lieu de ce genre. Vous vous frayez difficilement un chemin � travers les client pour finalement vous asseoir devant le comptoire et interpeller le tavernier.
Un chauve de grande taille s''approche de vous, une chope en pierre � la main et vous dit :
- �Que puis je faire pour vous mon brave ?�
Vous lui r�pondez :
- �Un drake est pass� par ici ce matin, sauriez-vous dans quelle direction est-il parti ?�
- �Ma femme a remarqu� une b�te ail�e s''�loigner vers l''est.�
- �Auriez vous une id�e d''ou elle aurait put aller ?�
- �Il n''y qu''un seul endroit en ce monde qui puisse accueillir un tel monstre : L''Antre des T�n�bres.�
Vous r�primez un frissonnement, vous avez entendu tant de choses sur cet endroit, on dit que le soleil ne perce jamais ses nuages, que de la lave en fusion coule en permanence des collines et que seul les damn�s osent entrer dans les tours sombres qui hantent ce lieu.
Mais apr�s tout n''�tes-vous pas Sir Godfroy de Monaco, le champion du roi, le pourfendeur de d�mons, ce n''est pas un volcan ou un gros l�zard qui vous fera douter de votre mission.
Vous remerciez le barman et quittez la taverne. ,Vous pouvez d�sormais reprendre votre chasse au drake en <0,quittant le village,23> ou continuer de vagabonder dans Casse-Roc :
<0,Aller dans le quartier marchand,12>
<0,Mendier pour essayer d''obtenir de l''or,14>
<0,Piller l''�glise,15>
<0,Essayer de trouver du travail,20>
', 'taverne.jpg'),

-- Page 14 --
('Mendiant', 'Vous devez trouver de l''or mais vous savez que vous n''arriverez pas � trouver un travail, il ne vous reste plus qu''une solution : mendier.
C''est avec honte que vous vous v�tissez d''un haillon en pierre gisant sur le sol et que vous rejoignez un groupe de sans-abris.
Durant plusieurs jours vous vous tra�nez dans les rues suppliant la g�n�rosit� des passants.
Votre errance vous rapporte <1,3 pi�ces d''or,0;3>, une grande quantit�e de cailloux au visage et vous fait perdre <2,2 PV,-2> � cause de la fatigue.
Vous devez d�sormais continuer :
<0,Aller dans le quartier marchand,12>
<0,Interroger les villageois,13>
<0,Piller l''�glise,15>
<0,Essayer de trouver du travail,20>
', 'mendiant.jpg'),

-- Page 15 --
('L''�glise', 'Vous savez que l''�glise de casse roc est connue pour entreposer des richesses extraites des mines. En voler une partie vous permettrai de vous racheter un �quipement.
Vous inspectez le b�timent et rep�rez le grand vitrail � l''arri�re. Il a l''air tr�s ancien au vu de l''agglom�ration de verre en bas du cadre. Vous examinez les alentours pour v�rifier qu''il n''y ait pas de t�moins �ventuels, l''endroit est isol� et vous pourrez agir en toute discr�tion. Apr�s un rapide coup d''oeil vous remarquez sous l''autel un panier en osier qui doit certainement servir pour les donations. Il est vide mais une porte surveill� par un garde � moiti� endormi se trouve au fond de l''�glise, les biens pr�cieux doivent s�rement se trouver � l''abri des regards.
Une fois la nuit tomb�e, vous prenez une pierre et brisez la fen�tre pour vous infiltrez. L''impact fait moins de bruit que pr�vu, vous entrez lentement � l''int�rieur de l''�glise quand vous entendez soudainement des bruits de pas.
Malgr� l''heure tardive, vous apercevez des pr�tres et des chevalier d�ambuler � travers les couloirs.
Si vous avez plus de 4 d''agilit� et plus de 3 de chance rendez-vous <0,ici,16>, si malheureusement vous �tes un pi�tre voleur, rendez vous <0,ici,17>.', 'eglise.jpg'),

-- Page 16 --
('Voleur d''�glises', 'C''est avec l''agilit� du serpent que vous vous glissez derri�re une statue et �vitez les occupants.
Plaqu� contre le mur, vous traversez les diff�rents couloirs de l''�glise jusqu''� atteindre la porte du coffre. Malheureusement un garde est post� devant et il serait impossible de l''affronter sans alerter les chevaliers et les pr�tres. 
Cela ne vous d�courage pas, vous prenez une coupe en pierre qui tra�nait par l� et la lancez dans un couloir � c�t�.
La garde sursaute et se pr�cipite dans le couloir en se lan�ant � lui-m�me :
- �Eh...Y''a quelqu''un ?�
Vous profitez de l''opportunit� pour sprinter dans la caverne d''ali baba.
Vous n''�tes pas d��u, la salle est remplie de diverses richesses : des croix serties de pierres pr�cieuses, des �p�es faites de diamant, des coffres d�bordant d''or, etc.
Vous �tes tellement obnubil� par ce tr�sor que vous ne remarquez pas votre pied butter contre un fil tendu.
Soudainement vous entendez le bruit d''un m�canisme se mettre en marche suivi du lourd son d''une cloche, toute l''�glise doit �tre d�sormais au courant qu''il y � un voleur.
Vous vous pr�cipitez vers la fen�tre pr�c�demment d�truite, emportant avec vous la seul bourse que vous avez eu le r�flexe de prendre dans votre fuite.
Par chance vous ne rencontrez personne durant votre escapade et vous parvenez � quitter l''�glise en un seul morceau, emportant avec vous <1,20 pi�ces d''or,0;20>, une somme rondelette.
Vous devez faire profile-bas maintenant, que choisissez vous de faire ?
<0,Aller dans le quartier marchand,12>
<0,Interroger les villageois,13>
<0,Mendier pour essayer d''obtenir de l''or,14>
<0,Essayer de trouver du travail,20>
', 'tasDOr.png'),

-- Page 17 --
('Pi�tre voleur', 'Vous tentez de vous glisser vers une statue mais c''est un �chec. Sans attendre un moment, les paladins se jettent sur vous et vous immobilisent.
Ils vous emm�nent sans plus tarder et vous balancent dans une cellule de la prison de Casse-Roc.
Tenter de piller une �glise est un crime grave mais heureusement un pr�tre arrive pr�s de votre cellule. Il est pr�t � vous pardonner mais ce ne sera pas gratuit. Il demande 8 pi�ces d''or. Souhaitez-vous <0,accepter,19> et <1,payer les pi�ces d''or,0;-8> ou <0,refuser,18> ?'
, 'prison.jpg'),

-- Page 18 --
('Prison � vie', 'Le pr�tre vous lance un regard de m�pris et quitte votre cellule. Vous �tes un chevalier du roi, vous ne tarderez pas � �tre lib�r�.
Vous attendez des heures puis des jours, puis des mois. C''est � ce moment que vous vous rendez compte que le pr�tre �tait votre seule chance de sortie, personne d''autre ne viendra.
C''est ainsi que fini votre espoir d''�tre lib�r� ainsi que votre vie.
', 'mortEnPrison.jpg'),

-- Page 19 --
('Lib�r�, d�livr�', '- �Vous avez fait le bon choix Sir Godfroy.�
Dit le pr�tre non sans un sourire de satisfaction sur le visage.
Les gardes vous emm�ne dans une salle avec toutes vos affaires hormis les 8 pi�ces d''or prisent par le pr�tre. Vous exprimez un soupire de soulagement en voyant la lumi�re du jour et les toits de pierre du village.
Maintenant que vous �tes libre, que faites-vous ?
<0,Aller dans le quartier marchand,12>
<0,Interroger les villageois,13>
<0,Mendier pour essayer d''obtenir de l''or,14>
<0,Essayer de trouver du travail,20>
', 'libre.jpg'),

-- Page 20 --
('A la recherche d''un emploi', 'Si vous voulez avoir de l''or, pas le choix, il faut travailler.
Vous rejoignez la grande place et consultez le panneau des annonces � la recherche d''une offre int�ressante.
Le gros du panneau est occup� par les offres des deux grande factions marchandes : Capital + et La Faucille Rouge.
Si vous avez plus de 4 de chance, allez <0,ici,22>, sinon allez <0,ici,21>.', 'annonces.png'),

-- Page 21 --
('Ch�mage', 'Vous parcourez le village pendant des heures en esp�rant trouver du labeur. Malgr� toutes vos recherches vous ne trouvez aucun habitant qui aurait besoin d''aide. Il semblerait que tous les travaux manuels soient occup�s, le business de la pierre est d�cid�ment florissant.
Malheureusement vous n''avez pas r�ussi � trouver une quelqu''on offre qui pourrait vous aider.
Que faites-vous maintenant ?
<0,Aller dans le quartier marchand,12>
<0,Interroger les villageois,13>
<0,Mendier pour essayer d''obtenir de l''or,14>
<0,Piller l''�glise,15>
', 'sansTravail.png'),

-- Page 22 --
('Un dur labeur', 'Au milieu de tous ces papiers vous apercevez dans le coin une affiche proposant un travail dans un atelier de tailleur de pierre.
Vous travaillez durant quelques jours au milieu des pierres et des statues , votre r�le est surtout de cr�er et transporter des briques n�cessaires � la construction c''est un travail particuli�rement �prouvant car les briques sont tr�s lourdes et les horaires sont �pouvantables.
Finalement vos efforts s''av�rent �tre payant : vous obtenez <1,10 pi�ces d''or,0;10>.
Maintenant que vous avez de l''argent que faites vous ?
<0,Aller dans le quartier marchand,12>
<0,Interroger les villageois,13>
<0,Mendier pour essayer d''obtenir de l''or,14>
<0,Piller l''�glise,15>
', 'gagnerArgent.png');

INSERT INTO Player (pv, force, armor, agility, luck, name, idActualPage) VALUES (10, 3, 1, 5, 2, 'Godfroyd', 3);

INSERT INTO Item (name, pv, force, armor, agility, luck) VALUES
('Plastron rouill�', 0, 0, 2, 0, 0),
('Casque de mineur en pierre', 0, 0, 1, 0, 0),
('Jambi�res encombrantes', 0, 0, 2, -1, 0),
('Manteau de fourrure', 0, 0, 1, 0, 0),
('Bottes de P�gase', 0, 0, 0, 2, 0),
('Vieux foulard', 0, 0, 0, 0, 1),
('Talisman grav�', 0, 0, 0, 0, 1),
('Ep�e du Soleil Levant', 0, 10, 0, 0, 0),
('Lance du champion en argent', 0, 9, 0, 0, 0),
('Hache d''arme en acier tremp�', 0, 8, 0, 0, 0),
('Ep�e en acier', 0, 7, 0, 0, 0),
('Massue en pierre', 0, 6, 0, 0, 0),
('Dague en pierre', 0, 4, 0, 0, 0),
('Ep�e d''entra�nement', 0, 4, 0, 0, 0),
('Pi�ce d''or', 0, 0, 0, 0, 0),
('Perle luisante', 0, 0, 0, 0, 0),
('Eau b�nite', 0, 0, 0, 0 ,0),
('Anneau en argent', 0, 0, 0, 0, 0),
('Potion de vitalit�', 6, 0, 0, 0, 0),
('Potion du serpent', 0, 0, 0, 1, 0),
('Potion de tr�fle � quatre feuille', 0, 0, 0, 0, 1);

INSERT INTO Enemy (pv, force, armor, agility, luck, name, image) VALUES 
(10, 5, 1, 4, 3, 'Gobelin', 'gobelin.jpg'),
(16, 3, 2, 5, 4, 'Chef gobelin', 'chefGobelin.jpg'),
(35, 5, 1, 2, 3, 'Bandit', 'bandit.jpg'),
(25, 4, 3, 3, 0, 'Araign�e squelette', 'araigneeSquelette.png'),
(30, 4, 1, 6, 2, 'Wendigo', 'wendigo.jpg'),
(20, 3, 0, 3, 1, 'Wendigo affaibli', 'wendigoAffaibli.jpg'),
(50, 7, 3, 4, 0, 'Drake', 'drake.jpg');