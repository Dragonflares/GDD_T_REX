CREATE PROCEDURE [CUATROGDD2018].[SP_GetRegimen_PorId]
	@idRegimen int
AS
BEGIN
		SELECT * FROM [CUATROGDD2018].[Regimenes_Estadia] R 
		WHERE R.id_regimen = @idRegimen
END
GO