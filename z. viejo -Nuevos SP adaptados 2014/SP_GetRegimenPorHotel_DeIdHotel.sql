CREATE PROCEDURE [CUATROGDD2018].[SP_GetRegimenPorHotel_DeIdHotel]
	@idHotel int
AS
BEGIN
	SELECT R.id_regimen, R.descripcion, R.precio_base
	FROM [CUATROGDD2018].[Regimenes_Estadia] R 
	JOIN [CUATROGDD2018].[Regimen_X_Hotel] RH ON (RH.id_regimen= R.id_regimen)
	WHERE RH.id_hotel = @idHotel
	GROUP BY R.id_regimen, R.descripcion, R.precio_base
END
GO