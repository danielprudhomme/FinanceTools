CREATE PROCEDURE [dbo].[InsertAsset]
	@Id UNIQUEIDENTIFIER,
	@Isin NVARCHAR(12),
	@Class INT,
	@Label NVARCHAR(50),
	@Currency INT
AS
	INSERT INTO Asset (Id, Isin, Class, Label, Currency)
	VALUES (@Id, @Isin, @Class, @Label, @Currency)
RETURN 0