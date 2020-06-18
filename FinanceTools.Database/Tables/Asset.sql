﻿CREATE TABLE [dbo].[Asset]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
	[Isin] NVARCHAR(12) NOT NULL, 
    [Class] INT NULL, 
    [Symbol] NVARCHAR(50) NOT NULL, 
    [Label] NVARCHAR(50) NOT NULL, 
    [Currency] INT NOT NULL
)
