CREATE PROCEDURE [CUATROGDD2018].[SP_GetHabitacionesPorHotel]
	@idHotel int,
	@nroHab NUMERIC(18,0)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM [CUATROGDD2018].[Habitaciones] H 
	WHERE H.ID_Hotel = @idHotel AND H.nro_habitacion = @nroHab
END
GO