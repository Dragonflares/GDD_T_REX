-- Nuevo intento fallido [T_REX].SP_NewIntento_Fallido

IF OBJECT_ID('T_REX.SP_NewIntento_Fallido') IS NOT NULL
    DROP PROCEDURE [T_REX].SP_NewIntento_Fallido
GO
CREATE PROCEDURE [T_REX].SP_NewIntento_Fallido
	@id_usuario int
AS
BEGIN
	UPDATE [T_REX].Usuario
	SET intentos_login= intentos_login + 1 
	WHERE id_usuario=@id_usuario
END
GO
