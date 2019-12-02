-- Reiniciar los intentos de login [T_REX].SP_ReiniciarIntentos_Login

IF OBJECT_ID('[T_REX].SP_ReiniciarIntentos_Login') IS NOT NULL
    DROP PROCEDURE [T_REX].SP_ReiniciarIntentos_Login 
GO

CREATE PROCEDURE [T_REX].SP_ReiniciarIntentos_Login 
	@id_usuario int
AS
BEGIN
	UPDATE [T_REX].Usuario  
	SET intentos_login = '0' 
	WHERE id_usuario = @id_usuario;  
END

GO