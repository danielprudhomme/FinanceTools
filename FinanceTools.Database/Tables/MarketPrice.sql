CREATE TABLE [dbo].[MarketPrice]
(
	[AssetId] UNIQUEIDENTIFIER NOT NULL , 
    [Date] DATE NOT NULL, 
    [Price] DECIMAL(18, 2) NOT NULL, 
    CONSTRAINT [PK_MarketPrice] PRIMARY KEY ([AssetId], [Date]), 
    CONSTRAINT [FK_MarketPrice_AssetId] FOREIGN KEY ([AssetId]) REFERENCES [Asset]([Id])
)
