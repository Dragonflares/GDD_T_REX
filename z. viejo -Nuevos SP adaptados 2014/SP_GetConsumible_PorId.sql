CREATE PROCEDURE [CUATROGDD2018].[SP_GetConsumible_PorId] 
	@idConsumible int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM [CUATROGDD2018].[Consumibles] 
	WHERE id_consumible = @idConsumible
END
GO