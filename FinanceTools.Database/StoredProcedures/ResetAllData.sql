﻿CREATE PROCEDURE [dbo].[ResetAllData]
AS
	DELETE FROM MarketPrice
	DELETE FROM Asset
RETURN 0
