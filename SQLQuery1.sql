USE [CRUD]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[SP_GetItems]

SELECT	@return_value as 'Return Value'

GO
