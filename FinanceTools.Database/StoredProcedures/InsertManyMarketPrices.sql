CREATE TYPE [dbo].[InsertManyMarketPrices_MarketPriceList_Parameter] AS TABLE
(
	[AssetId] UNIQUEIDENTIFIER NOT NULL, 
    [Date] DATE NOT NULL, 
    [Price] DECIMAL(18, 2) NOT NULL
);
GO

CREATE PROCEDURE [dbo].[InsertManyMarketPrices]
	@marketPriceList AS [dbo].[InsertManyMarketPrices_MarketPriceList_Parameter] READONLY
AS
    DELETE mp
    FROM [dbo].[MarketPrice] AS mp
    INNER JOIN @marketPriceList mpl ON mpl.AssetId = mp.AssetId AND mpl.Date = mp.Date

    INSERT INTO [dbo].[MarketPrice]
    SELECT * FROM @marketPriceList
RETURN 0
