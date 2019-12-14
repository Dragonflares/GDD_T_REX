/*T_REX.AltaUsuario*/

IF OBJECT_ID('T_REX.AltaUsuario') IS NOT NULL
	DROP PROCEDURE T_REX.AltaUsuario;
GO

CREATE PROCEDURE T_REX.AltaUsuario
@Nombre nvarchar (255),
@Password nvarchar (255)

AS
Begin
	DECLARE @id int, @nuevoUser varchar(255), @pass varchar(255)
	SET @nuevoUser = @Nombre
	SET @pass = @Password
	
	INSERT INTO T_REX.USUARIO (username, password,intentos_login, estado)
	VALUES (@nuevoUser,@pass, '0', '1' )
	
	SET @id= ( select id_usuario from T_REX.USUARIO where username=@Nombre)

	RETURN @id
End
GO