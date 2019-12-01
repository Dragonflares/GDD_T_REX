CREATE PROCEDURE [CUATROGDD2018].[SP_InsertarReservaXHabitacion]
	@idHabi int,
	@idReserva int
AS
BEGIN
	INSERT INTO [CUATROGDD2018].[Habitacion_X_Reserva] (id_habitacion,id_reserva)
	VALUES (@idHabi,@idReserva)
END
GO