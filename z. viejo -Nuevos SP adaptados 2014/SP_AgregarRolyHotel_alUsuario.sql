CREATE PROCEDURE [CUATROGDD2018].[SP_AgregarRolyHotel_alUsuario]
	@idRol int,
	@idUsuario int,
	@idHotel int
AS
BEGIN
	INSERT INTO [CUATROGDD2018].[Usuario_X_Hotel_X_Rol] (id_usuario, id_hotel, id_rol)
	VALUES (@idUsuario, @idHotel, @idRol);
END
GO