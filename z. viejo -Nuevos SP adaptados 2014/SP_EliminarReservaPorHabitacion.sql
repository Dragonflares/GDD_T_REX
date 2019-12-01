CREATE PROCEDURE [CUATROGDD2018].[SP_EliminarReservaPorHabitacion]
	@idHabi int,
	@idReserva int
AS
BEGIN
	DELETE FROM [CUATROGDD2018].[Habitacion_X_Reserva]
	WHERE id_habitacion = @idHabi AND id_reserva = @idReserva
END
GO