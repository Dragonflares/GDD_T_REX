CREATE PROCEDURE [CUATROGDD2018].[SP_GetRegimenesFaltantesHotel]
	@idHotel int
AS
BEGIN
	SELECT R.id_regimen, R.descripcion, R.precio_base
	FROM [CUATROGDD2018].[Regimenes_Estadia] R 
	WHERE (SELECT COUNT(RH.id_regimen) FROM [CUATROGDD2018].[Regimen_X_Hotel] RH WHERE RH.id_regimen = R.id_regimen AND RH.id_hotel = @idHotel ) = 0
	GROUP BY R.id_regimen,R.descripcion,R.precio_base
END
GO