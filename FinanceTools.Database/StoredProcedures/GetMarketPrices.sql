CREATE PROCEDURE [dbo].[GetMarketPrices]
	@AssetId UNIQUEIDENTIFIER,
	@StartDate DATE,
	@EndDate DATE
AS
	SELECT AssetId, Date, Price
	FROM [dbo].[MarketPrice]
	WHERE AssetId = @AssetId
	AND Date BETWEEN @StartDate AND @EndDate
RETURN
