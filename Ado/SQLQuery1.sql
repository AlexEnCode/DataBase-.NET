﻿CREATE DATABASE commande;
GO

USE commande;
GO

CREATE TABLE Client (
    ID INT PRIMARY KEY,
    Nom NVARCHAR(50) NOT NULL,
    Prenom NVARCHAR(50) NOT NULL,
    Adresse NVARCHAR(50),
    CodePostal NVARCHAR(5),
    Ville NVARCHAR(50),
    Telephone INT(10)
);
GO

CREATE TABLE Commande (
    ID INT PRIMARY KEY,
    ClientID INT FOREIGN KEY REFERENCES Client(ID),
    Date DATETIME NOT NULL,
    Total DECIMAL(18, 2) NOT NULL
);
GO