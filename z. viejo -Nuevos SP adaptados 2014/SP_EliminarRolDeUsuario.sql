CREATE PROCEDURE [CUATROGDD2018].[SP_EliminarRolDeUsuario]
	@idRol int,
	@id_Usuario int
AS
BEGIN
	DELETE FROM [CUATROGDD2018].[Usuario_X_Hotel_X_Rol]
	WHERE ID_Rol=@idRol AND ID_Usuario=@id_Usuario; 
END
GO