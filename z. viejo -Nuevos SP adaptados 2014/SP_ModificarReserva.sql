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


CREATE PROCEDURE [CUATROGDD2018].[SP_ModificarReserva]
	@fechaDesde date,
	@cantNoches int,
	@fechaReserva date,
	@descripcionRegimen nvarchar(255),
	@idUsuario int,
	@IdReserva int,
	@idPersona int
AS
BEGIN

DECLARE @TIPO_USER NVARCHAR(255)

	IF (NOT(@idUsuario = '2')) -- 2 =guest
	BEGIN
		SET @TIPO_USER = (SELECT TOP 1 (R.Nombre)
						FROM [CUATROGDD2018].[Usuarios] U 
						JOIN [CUATROGDD2018].[Usuario_X_Hotel_X_Rol] UH ON (U.id_usuario = UH.id_usuario)
						JOIN [CUATROGDD2018].[Roles] R ON (R.id_rol = UH.id_rol)
						WHERE U.id_usuario = @idUsuario)
	END
	
	IF (@TIPO_USER IS NOT NULL AND @TIPO_USER = 'Administrador')
	BEGIN
		UPDATE [CUATROGDD2018].[Reservas]
		SET cantidad_noches = @cantNoches, fecha_desde= @fechaDesde,fecha_reserva= @fechaReserva,
			id_estado_reserva = 2, id_persona= @idPersona, id_regimen= [CUATROGDD2018].[FUN_IdRegimen](@descripcionRegimen)
		WHERE id_reserva = @IdReserva
		UPDATE [CUATROGDD2018].[Personas]
		SET id_usuario= @idUsuario
		WHERE id_persona=@idPersona
	END
	
	IF (@TIPO_USER IS NOT NULL AND @TIPO_USER = 'Recepcionista')
	BEGIN
		UPDATE [CUATROGDD2018].[Reservas]
		SET cantidad_noches = @cantNoches, fecha_desde = @fechaDesde, fecha_reserva = @fechaReserva,
			id_estado_reserva = 2,id_persona= @idPersona, id_regimen= [CUATROGDD2018].[FUN_IdRegimen](@descripcionRegimen)
		WHERE id_reserva = @IdReserva
		UPDATE [CUATROGDD2018].[Personas]
		SET id_usuario= @idUsuario
		WHERE id_persona=@idPersona
	END

	IF (@TIPO_USER IS NOT NULL AND @TIPO_USER = 'Administrador General')
	BEGIN
		UPDATE [CUATROGDD2018].[Reservas]
		SET cantidad_noches = @cantNoches, fecha_desde = @fechaDesde, fecha_reserva = @fechaReserva,
			id_estado_reserva = 2,id_persona= @idPersona, id_regimen= [CUATROGDD2018].[FUN_IdRegimen](@descripcionRegimen)
		WHERE id_reserva = @IdReserva
		UPDATE [CUATROGDD2018].[Personas]
		SET id_usuario= @idUsuario
		WHERE id_persona=@idPersona
	END
	
	IF (@idUsuario = '2') -- 2 =guest
	BEGIN
		UPDATE [CUATROGDD2018].[Reservas]
		SET cantidad_noches = @cantNoches,fecha_desde = @fechaDesde, fecha_reserva = @fechaReserva,
			id_estado_reserva = 2,id_persona= @idPersona,id_regimen= [CUATROGDD2018].[FUN_IdRegimen](@descripcionRegimen)
		WHERE  id_reserva = @IdReserva
		UPDATE [CUATROGDD2018].[Personas]
		SET id_usuario= @idUsuario
		WHERE id_persona=@idPersona
	END	
	

END
GO