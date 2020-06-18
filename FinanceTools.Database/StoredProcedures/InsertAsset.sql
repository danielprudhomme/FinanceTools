CREATE PROCEDURE [dbo].[InsertAsset]
	@Id UNIQUEIDENTIFIER,
	@Isin NVARCHAR(12),
	@Class INT,
	@Symbol NVARCHAR(50),
	@Label NVARCHAR(50),
	@Currency INT
AS
	INSERT INTO Asset (Id, Isin, Class, Symbol, Label, Currency)
	VALUES (@Id, @Isin, @Class, @Symbol, @Label, @Currency)
RETURN 0