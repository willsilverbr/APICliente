USE ANALISEDECREDITO
GO

CREATE TABLE VendasCliente
(Codigo INT IDENTITY(1,1) not null,
Data_Venda DateTime not null, 
Valor_Venda FLOAT not null,
PRIMARY KEY(Codigo),
);
GO