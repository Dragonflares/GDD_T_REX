CREATE PROCEDURE [CUATROGDD2018].[SP_GetEstadoReserva_PorId]
	@idEstado int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM [CUATROGDD2018].[Estados_Reservas]  WHERE id_estado_reserva = @idEstado
END
GO