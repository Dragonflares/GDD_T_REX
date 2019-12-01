CREATE PROCEDURE [CUATROGDD2018].[SP_GetHabitacion_PorId]
	@idHabitacion int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM [CUATROGDD2018].[Habitaciones] H WHERE H.id_habitacion = @idHabitacion
END
GO