CREATE PROCEDURE [CUATROGDD2018].[SP_GetUsuario_PorId]
	@idUsuario int
AS
BEGIN
	SELECT * FROM [CUATROGDD2018].[Usuarios] u
	WHERE u.id_usuario = @idUsuario
END
GO