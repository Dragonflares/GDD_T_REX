IF OBJECT_ID('T_REX.CambiarContraseniaModoAdmin') IS NOT NULL
	DROP PROCEDURE [T_REX].CambiarContraseniaModoAdmin;
GO
CREATE PROCEDURE [T_REX].CambiarContraseniaModoAdmin
	@IdUsuario int,
	@Pass varchar(255)
AS
BEGIN
	IF(EXISTS(	SELECT 1 FROM [T_REX].USUARIO us WHERE us.id_usuario = @IdUsuario )	)
	BEGIN
		UPDATE [T_REX].USUARIO 
		SET password = CONVERT(varchar(64), HASHBYTES('SHA2_256', @Pass), 2) 
		WHERE id_usuario = @IdUsuario
	END
	ELSE
	BEGIN
		RAISERROR('ERROR: Usuario incorrecto', 16, 1)
	END			
END
GO

