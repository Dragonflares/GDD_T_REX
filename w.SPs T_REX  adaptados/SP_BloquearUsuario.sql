-- Bloquear usuario T_REX.SP_BloquearUsuario

IF OBJECT_ID('T_REX.SP_BloquearUsuario') IS NOT NULL
    DROP PROCEDURE T_REX.SP_BloquearUsuario
GO

CREATE PROCEDURE [T_REX].SP_BloquearUsuario 
@id_usuario int
AS
BEGIN
	UPDATE [T_REX].Usuario
	SET estado='0'
	where id_usuario=@id_usuario
END

GO