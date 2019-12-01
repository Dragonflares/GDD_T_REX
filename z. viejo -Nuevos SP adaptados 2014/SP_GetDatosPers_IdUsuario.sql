CREATE PROCEDURE [CUATROGDD2018].[SP_GetDatosPers_IdUsuario]
	@idUsuario int
AS 
BEGIN
	SELECT * FROM [CUATROGDD2018].[Personas] WHERE id_usuario=@idUsuario
END
GO