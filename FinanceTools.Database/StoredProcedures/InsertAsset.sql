CREATE PROCEDURE [dbo].[InsertAsset]
	@Id UNIQUEIDENTIFIER,
	@Class INT,
	@Symbol NVARCHAR(50),
	@Label NVARCHAR(50),
	@Currency INT
AS
	INSERT INTO Asset (Id, Class, Symbol, Label, Currency)
	VALUES (@Id, @Class, @Symbol, @Label, @Currency)
RETURN 0