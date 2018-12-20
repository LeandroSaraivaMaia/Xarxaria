USE XarxariaDB;

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
Après avoir repris ses esprits, il aperçoit une bête ailé s’éloigner, le drake. Il se rend compte que son équipement a entièrement disparu. C’est sans doute l’oeuvre de la magie noire du drake.
Il a eu beaucoup de chance de s’en réchapper vivant.
C’est là que votre aventure commence, vous êtes ce chevalier.
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
<0,Essayer de trouver du travail,16>'
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
<1,Une étrange pierre luisante,1;1> pour <1,1 pièce d''or,0;-1>
<1,Une lanterne en pierre,2;1> pour <1,2 pièce d''or,0;-2>
Une fois vos achats effectués, vous pouvez :
<0,Interroger les villageois,13>
<0,Mendier pour essayer d''obtenir de l''or,14>
<0,Piller l''église,15>
<0,Essayer de trouver du travail,16>'
, 'forgeron.jpg');

-- Inventaire et joueur

INSERT INTO Inventory(goldenCoin, glowingStone, stoneLantern) VALUES (18, 0, 0);

INSERT INTO Player (pv, force, armor, agility, luck, name, idActualPage, idInventory) VALUES (10, 3, 1, 5, 2, 'Godfroyd', 3, 1);