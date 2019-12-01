CREATE PROCEDURE [CUATROGDD2018].[SP_InsertarEstadia]
	@iniciofecha datetime,
	@cantNoches numeric(18,0),
	@idReserva int,
	@usuario int,
	@idHab int
	
AS
BEGIN
	INSERT INTO [CUATROGDD2018].[Estadias] (fecha_Inicio,cant_noches,id_usuario_checkIn,id_usuario_checkOut,id_habitacion,id_reserva) 
	VALUES (@iniciofecha,@cantNoches,@usuario,null,@idHab,@idReserva)
	
	UPDATE [CUATROGDD2018].[Reservas]
	SET id_estado_reserva=6 WHERE id_reserva=@idReserva
END
GO


