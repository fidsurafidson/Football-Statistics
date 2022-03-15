create database Foot;

create table equipe(
	id int identity primary key,
	nom varchar(50)
);
insert into equipe values('FC Barcelone');
insert into equipe values('Real Madrid');
insert into equipe values('Paris Saint Germain');
insert into equipe values('Arsenal');
insert into equipe values('Manchester City');

create table joueur(
	id int identity primary key,
	nom varchar(50),
	numero int,
	idEquipe int
);
insert into joueur values ('Ter Stegen',1,1);
insert into joueur values ('Pique',2,1);
insert into joueur values ('Semedo',3,1);
insert into joueur values ('Umtiti',4,1);
insert into joueur values ('Jordi Alba',5,1);
insert into joueur values ('Rakitic',6,1);
insert into joueur values ('Busquets',7,1);
insert into joueur values ('Iniesta',8,1);
insert into joueur values ('Dembele',9,1);
insert into joueur values ('Suarez',10,1);
insert into joueur values ('Messi',11,1);
insert into joueur values ('Sergi Roberto',12,1);
insert into joueur values ('Paulinho',13,1);
insert into joueur values ('Denis Suarez',14,1);
insert into joueur values ('Mascherano',15,1);
insert into joueur values ('Deulofeu',16,1);
insert into joueur values ('Gomez',17,1);
insert into joueur values ('Vermaelen',18,1);

insert into joueur values ('Navas',1,2);
insert into joueur values ('Carvajal',2,2);
insert into joueur values ('Varane',3,2);
insert into joueur values ('Ramos',4,2);
insert into joueur values ('Marcelo',5,2);
insert into joueur values ('Ascenscio',6,2);
insert into joueur values ('Kroos',7,2);
insert into joueur values ('Modric',8,2);
insert into joueur values ('Casemiro',9,2);
insert into joueur values ('Benzema',10,2);
insert into joueur values ('Isco',11,2);
insert into joueur values ('Gareth Bale',12,2);
insert into joueur values ('Nacho',13,2);
insert into joueur values ('Vasquez',14,2);
insert into joueur values ('Ceballos',15,2);
insert into joueur values ('Casilla',16,2);
insert into joueur values ('Ronaldo',17,2);
insert into joueur values ('Bale',18,2);

insert into joueur values ('Areola',1,3);
insert into joueur values ('D. Alves',2,3);
insert into joueur values ('Marquinos',3,3);
insert into joueur values ('Thiago Silva',4,3);
insert into joueur values ('Kurzawa',5,3);
insert into joueur values ('Rabiot',6,3);
insert into joueur values ('Verrati',7,3);
insert into joueur values ('Motta',8,3);
insert into joueur values ('Mbappe',9,3);
insert into joueur values ('Cavani',10,3);
insert into joueur values ('Neymar',11,3);
insert into joueur values ('Di Maria',12,3);
insert into joueur values ('Ben Arfa',13,3);
insert into joueur values ('Draxler',14,3);
insert into joueur values ('Moura',15,3);
insert into joueur values ('Pastore',16,3);
insert into joueur values ('Meunier',17,3);
insert into joueur values ('Kevin Trapp',18,3);

create table match(
	id int identity,
	idMatch int primary key,
	idEquipe1 int,
	idEquipe2 int,
	dateDebut dateTime,
	foreign key (idMatch) references listeMatch(id),
	foreign key (idEquipe1) references equipe(id),
	foreign key (idEquipe2) references equipe(id)
);

create table feuilleMatchJoueur(
	id int identity primary key,
	idMatch int,
	idEquipe int,
	idJoueur int,
	minuteJoue int,
	ballonTouche int,
	tir int,
	tirCadre int,
	but int,
	passeDecisive int,
	foreign key (idMatch) references listeMatch(id),
	foreign key (idEquipe) references Equipe(id),
	foreign key (idJoueur) references Joueur(id)
);

create table statistique(
	id int identity primary key,
	idMatch int,
	dateMatch dateTime,
	idEquipe int,
	possession int,
	tir int,
	tirCadre int,
	but int,
	foreign key (idMatch) references listeMatch(id),
	foreign key (idEquipe) references Equipe(id)
);

create table utilisateur(
	id int identity primary key,
	nom varchar(50),
	motDePasse varchar(50),
	jeton int
);
insert into utilisateur values('hanitra', 'rakoto',1000000);
insert into utilisateur values('tsiory', 'coco',500000);
insert into utilisateur values('fids', 'fidy',500000);
insert into utilisateur values('mihanta', 'mimi',500000);

create table pari(
	id int identity primary key,
	idMatch int,
	idUtilisateur int,
	idEquipe int,
	typePari varchar(50),
	categoriePari varchar(50),
	compensation int,
	montant int,
	forfait int,
	matchNul int,
	etat int,
	foreign key (idMatch) references listeMatch(id),
	foreign key (idUtilisateur) references utilisateur(id),
	foreign key (idEquipe) references Equipe(id)
);

insert into pari values('1', '1', '1','vbt','ohuigyfthx','5','50.5','20.6','0','0');

create table listeMatch(
	id int identity primary key,
	nomEquipe1 varchar(50),
	nomEquipe2 varchar(50),
	dateDebut dateTime,
	etat int
);

insert into listeMatch values ('FC Barcelone','Real Madrid','2017-10-01 20:00:00',0);
insert into listeMatch values ('FC Barcelone','Paris Saint Germain','2017-10-07 20:00:00',0);
insert into listeMatch values ('Real Madrid','Paris Saint Germain','2017-10-14 20:00:00',0);


create table pariTotalEngage(
	id int identity primary key,
	idMatch int,
	idUtilisateur1 int,
	idUtilisateur2 int,
	idEquipe1 int,
	idEquipe2 int,
	categoriePari varchar(50),
	compensation1 int,
	compensation2 int,
	jeton int,
	matchNul int,
	foreign key (idMatch) references listeMatch(id),
	foreign key (idUtilisateur1) references utilisateur(id),
	foreign key (idUtilisateur2) references utilisateur(id),
	foreign key (idEquipe1) references Equipe(id),
	foreign key (idEquipe2) references Equipe(id)
);

create table pariQuantitatifEngage(
	id int identity primary key,
	idMatch int,
	idUtilisateur1 int,
	idUtilisateur2 int,
	idEquipe1 int,
	idEquipe2 int,
	categoriePari varchar(50),
	compensation1 int,
	compensation2 int,
	jeton1 int,
	jeton2 int,
	forfait1 int,
	forfait2 int,
	matchNul int,
	foreign key (idMatch) references listeMatch(id),
	foreign key (idUtilisateur1) references utilisateur(id),
	foreign key (idUtilisateur2) references utilisateur(id),
	foreign key (idEquipe1) references Equipe(id),
	foreign key (idEquipe2) references Equipe(id)
);


update utilisateur set jeton='1000000' where id='1';
update utilisateur set jeton='500000' where id='2';
update utilisateur set jeton='500000' where id='3';
update utilisateur set jeton='500000' where id='4';

update listeMatch set etat='0' where id='1'

delete from statistique
delete from match
delete from feuilleMatchJoueur

create table demandePret (
	id int identity primary key,
	idUtilisateur int,
	dateDeblocage dateTime,
	jeton int,
	etatValidation int,
	foreign key (idUtilisateur) references utilisateur(id)
);

create table planRemboursement (
	id int identity primary key,
	idUtilisateur int,
	dateRemboursement dateTime,
	jeton int,
	foreign key (idUtilisateur) references utilisateur(id)
);

create table planRemboursementAvecInteret (
	id int identity primary key,
	idDemandePret int,
	idUtilisateur int,
	dateRemboursement dateTime,
	jetonSansInteret int,
	jetonAvecInteret int,
	etatPaiement int,
	foreign key (idDemandePret) references demandePret(id),
	foreign key (idUtilisateur) references utilisateur(id)
);