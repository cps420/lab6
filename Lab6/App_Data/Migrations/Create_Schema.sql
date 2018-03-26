DROP TABLE [dbo].[Students];
CREATE TABLE [dbo].[Students]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(50) NULL, 
    [Scholar] BIT NOT NULL
);