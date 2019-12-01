CREATE PROCEDURE [CUATROGDD2018].[SP_EliminarHabitacion]
	@idHab int
AS
BEGIN
		DELETE FROM [CUATROGDD2018].[Habitaciones]
		WHERE id_habitacion = @idHab
END
GO