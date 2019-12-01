CREATE PROCEDURE [CUATROGDD2018].[SP_EliminarUsuarioDeHotel]
	@idHotel int,
	@idUsuario int
AS
BEGIN
	DELETE FROM [CUATROGDD2018].[Usuario_X_Hotel_X_Rol]
	WHERE id_hotel=@idHotel AND id_usuario=@idUsuario; 
END
GO