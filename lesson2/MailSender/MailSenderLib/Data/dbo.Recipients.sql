CREATE TABLE [dbo].[Recipients]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(MAX) NOT NULL, 
    [Adddress] NVARCHAR(MAX) NOT NULL, 
    [Description] NVARCHAR(MAX) NULL
)
