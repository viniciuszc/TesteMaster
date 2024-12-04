CREATE DATABASE TesteMaster;

USE TesteMaster;

CREATE TABLE Localizacao (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Sigla CHAR(3) NOT NULL
);

CREATE TABLE Rota (
    Id INT PRIMARY KEY IDENTITY(1,1),
    OrigemId INT NOT NULL,
    DestinoId INT NOT NULL,
    Valor DECIMAL(18, 2) NOT NULL,
    FOREIGN KEY (OrigemId) REFERENCES Localizacao(Id),
    FOREIGN KEY (DestinoId) REFERENCES Localizacao(Id)
);

CREATE TABLE Viagem (
    Id INT PRIMARY KEY IDENTITY(1,1),
    ValorTotal DECIMAL(18, 2) NOT NULL
);

CREATE TABLE ViagemRota (
    ViagemId INT NOT NULL,
    RotaId INT NOT NULL,
    PRIMARY KEY (ViagemId, RotaId),
    FOREIGN KEY (ViagemId) REFERENCES Viagem(Id),
    FOREIGN KEY (RotaId) REFERENCES Rota(Id)
);

INSERT INTO Localizacao (Sigla) VALUES ('GRU');
INSERT INTO Localizacao (Sigla) VALUES ('BRC');
INSERT INTO Localizacao (Sigla) VALUES ('SCL');
INSERT INTO Localizacao (Sigla) VALUES ('CDG');
INSERT INTO Localizacao (Sigla) VALUES ('ORL');

INSERT INTO Rota (OrigemId, DestinoId, Valor) VALUES (
    (SELECT Id FROM Localizacao WHERE Sigla = 'GRU'),
    (SELECT Id FROM Localizacao WHERE Sigla = 'BRC'),
    10
);

INSERT INTO Rota (OrigemId, DestinoId, Valor) VALUES (
    (SELECT Id FROM Localizacao WHERE Sigla = 'BRC'),
    (SELECT Id FROM Localizacao WHERE Sigla = 'SCL'),
    5
);

INSERT INTO Rota (OrigemId, DestinoId, Valor) VALUES (
    (SELECT Id FROM Localizacao WHERE Sigla = 'GRU'),
    (SELECT Id FROM Localizacao WHERE Sigla = 'CDG'),
    75
);

INSERT INTO Rota (OrigemId, DestinoId, Valor) VALUES (
    (SELECT Id FROM Localizacao WHERE Sigla = 'GRU'),
    (SELECT Id FROM Localizacao WHERE Sigla = 'SCL'),
    20
);

INSERT INTO Rota (OrigemId, DestinoId, Valor) VALUES (
    (SELECT Id FROM Localizacao WHERE Sigla = 'GRU'),
    (SELECT Id FROM Localizacao WHERE Sigla = 'ORL'),
    56
);

INSERT INTO Rota (OrigemId, DestinoId, Valor) VALUES (
    (SELECT Id FROM Localizacao WHERE Sigla = 'ORL'),
    (SELECT Id FROM Localizacao WHERE Sigla = 'CDG'),
    5
);

INSERT INTO Rota (OrigemId, DestinoId, Valor) VALUES (
    (SELECT Id FROM Localizacao WHERE Sigla = 'SCL'),
    (SELECT Id FROM Localizacao WHERE Sigla = 'ORL'),
    20
);
