CREATE FUNCTION [CUATROGDD2018].[FUN_IdRegimen]
(
	@descripcion nvarchar(255)
)
RETURNS numeric(18,0)
AS
BEGIN
	RETURN (
	SELECT id_regimen FROM [CUATROGDD2018].[Regimenes_Estadia]
	WHERE descripcion = @descripcion
	)
END
GO

CREATE PROCEDURE [CUATROGDD2018].[SP_InsertReserva]
	@fechaDesde date,
	@cantNoches int,
	@fechaReserva date,
	@fechaHasta date,
	@descripcionRegimen nvarchar(255),
	@idPersona int
AS
BEGIN
	INSERT INTO [CUATROGDD2018].[Reservas](cantidad_noches,fecha_desde,fecha_hasta,fecha_reserva,id_estado_reserva,id_regimen,id_persona)
	VALUES (@cantNoches,@fechaDesde,@fechaHasta,@fechaReserva,1,[CUATROGDD2018].[FUN_IdRegimen](@descripcionRegimen),@idPersona)
	-- estado 1= reserva correcta
	
	DECLARE @RETORNO_RESERVA int
	SET @RETORNO_RESERVA = @@IDENTITY
	
	SELECT @RETORNO_RESERVA
END
GO

