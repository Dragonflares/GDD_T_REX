CREATE PROCEDURE [CUATROGDD2018].[SP_GetIdConsumible_PorDescrip]
	@descripcion nvarchar(255)
AS
BEGIN
	SELECT TOP 1(C.id_consumible)
	FROM [CUATROGDD2018].[Consumibles] C
	WHERE C.Descripcion = @descripcion
END
GO