
IF OBJECT_ID('T_REX.SP_GetClientePor_IdUsuario') IS NOT NULL
	DROP PROCEDURE [T_REX].SP_GetClientePor_IdUsuario;
GO
CREATE PROCEDURE [T_REX].SP_GetClientePor_IdUsuario
	
	@id_usuario int
AS
BEGIN
	SELECT * FROM T_REX.CLIENTE
	WHERE id_usuario =@id_usuario
END
GO


