--comandos DQL Data Query Language

use SENAI_HROADS_MANHA;

--pra ver se alterou corretamente o nome do personagem de Fer8 para Fer7
select Nome from Personagem;

--para ver se alterou corretamente o nome da classe de necromante para necromancer
select Nome from Classe;

--selecionar todos os personagens
select * from Personagem;

--selecionar todas as classes
select * from Classe;

--Selecionar somente o nome das classes
select Nome from Classe;

--Selecionar todas as habilidades
select * from Habilidade;

--Realizar a contagem de quantas habilidades estão cadastradas
select count(idHabilidade) from Habilidade;

--Selecionar somente os id’s das habilidades classificando-os por ordem crescente
select idHabilidade from Habilidade;

--Selecionar todos os tipos de habilidades
select Tipo from TipoHabilidade;

--Selecionar todas as habilidades e a quais tipos de habilidades elas fazem parte
select Nome as Habilidades, Tipo as Tipos  
from Habilidade as H
inner join TipoHabilidade as TH
on H.idTipoHabilidade = TH.idTipoHabilidade;

--Selecionar todos os personagens e suas respectivas classes
select P.Nome as Personagem, C.Nome as Classe
from Personagem as P
inner join Classe as C
on P.idClasse = C.idClasse;

--Selecionar todos os personagens e as classes (mesmo que elas não tenham correspondência em personagens)
select P.Nome as Personagens, C.Nome as Classe
from Personagem as P
right join Classe as C
on P.idClasse = C.idClasse;

--Selecionar todas as classes e suas respectivas habilidades
select C.Nome as Classe, H.Nome as Habilidade
from Classe as C
left join ClasseHabilidade as CH
on C.idClasse = CH.idClasse
left join Habilidade as H
on CH.idHabilidade = H.idHabilidade;

--Selecionar todas as habilidades e suas classes (somente as que possuem correspondência);
select H.Nome as Habilidades, C.Nome as Classe
from Habilidade as H
inner join ClasseHabilidade as CH
on H.idHabilidade = CH.idHabilidade
inner join Classe as C
on CH.idClasse = C.idClasse;

--Selecionar todas as habilidades e suas classes (mesmo que elas não tenham correspondência)
select H.Nome as Habilidades, C.Nome as Classes
from Habilidade as H
left join ClasseHabilidade as CH
on H.idHabilidade = CH.idHabilidade
right join Classe as C
on CH.idClasse = C.idClasse;
