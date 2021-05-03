--DML Data Manipulation Language

use SENAI_HROADS_MANHA;

insert into TipoHabilidade(Tipo)
values					  ('Ataque')
						 ,('Defesa')
						 ,('Cura')
						 ,('Magia');

insert into Habilidade(Nome, idTipoHabilidade)
values				  ('LancaMortal', 1)
					 ,('EscudoSupremo', 2)
					 ,('RecuperarVida', 3);

insert into Classe(Nome)
values			  ('Barbaro')
				 ,('Cruzado')
				 ,('CacadoraDeDem')
				 ,('Monge')
				 ,('Necromante')
				 ,('Feiticeiro')
				 ,('Arcanista');

insert into ClasseHabilidade(idClasse, idHabilidade)
values						(1, 1)
						   ,(1, 2)
						   ,(4, 2)
						   ,(4, 3)
						   ,(7, null);

insert into Personagem(Nome, Classe, idClasse,VidaMax, ManaMax, DataDeAtualizacao, DataDeCriacao)
values				  ('DeuBug', 'Barbaro', 1, 100, 80, '02/03/2021', '18/01/2019')
					 ,('BitBug', 'Monge', 4, 70, 100, '02/03/2021', '17/03/2016')
					 ,('Fer8', 'Arcanista', 7, 75, 60, '02/03/2021', '18/03/2018');

update Personagem
set Nome = 'Fer7'
where idPersonagem = 3;

update Classe
set Nome = 'Necromancer'
where idClasse = 5;

update Classe
set Nome = 'CacadoraDeDem.'
where idClasse = 3;
