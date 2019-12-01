CREATE PROCEDURE [CUATROGDD2018].[SP_GetAllHabitacion_PorHotel]
	@idHotel int
AS
BEGIN
	SELECT *FROM [CUATROGDD2018].[Habitaciones] 
	WHERE  id_hotel = @idHotel
	ORDER BY nro_habitacion
END
GO