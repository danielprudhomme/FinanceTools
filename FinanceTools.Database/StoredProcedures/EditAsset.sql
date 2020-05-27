CREATE PROCEDURE [dbo].[EditAsset]
	@Id UNIQUEIDENTIFIER,
	@Class INT,
	@Symbol NVARCHAR(50),
	@Label NVARCHAR(50),
	@Currency INT
AS
	UPDATE Asset
	SET Class = @Class, Symbol = @Symbol, Label = @Label, Currency = @Currency
	WHERE Id = @Id
RETURN 0