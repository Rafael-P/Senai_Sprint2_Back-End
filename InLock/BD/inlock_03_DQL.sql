--InLock DQL

USE inlock_games_manha
GO

SELECT * FROM Usuarios
GO

SELECT * FROM Estudios
GO

SELECT * FROM Jogos
GO

SELECT j.nomeJogo AS Nome, E.nomeEstudio AS Estudio FROM Jogos AS J
INNER JOIN Estudios AS E
ON J.idEstudio = E.idEstudio
GO

SELECT E.nomeEstudio AS Estudio , J.nomeJogo AS Jogo FROM Estudios AS E
LEFT JOIN Jogos AS J
ON E.idEstudio = J.idEstudio
GO

SELECT titulo [Permissão], email Email, senha Senha FROM Usuarios U
INNER JOIN TipoUsuario T
ON U.idTipoUsuario = T.idTipoUsuario
WHERE email = 'admin@admin.com' AND senha = 'admin'
GO

SELECT idJogo, nomeJogo [Nome do Jogo] FROM Jogos
WHERE idJogo = '2'
GO

SELECT idEstudio, nomeEstudio Nome FROM Estudios
WHERE idEstudio = '3'
GO