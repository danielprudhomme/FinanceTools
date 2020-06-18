CREATE PROCEDURE [dbo].[EditAsset]
	@Id UNIQUEIDENTIFIER,
	@Isin NVARCHAR(12),
	@Class INT,
	@Symbol NVARCHAR(50),
	@Label NVARCHAR(50),
	@Currency INT
AS
	UPDATE Asset
	SET Isin = @Isin, Class = @Class, Symbol = @Symbol, Label = @Label, Currency = @Currency
	WHERE Id = @Id
RETURN 0