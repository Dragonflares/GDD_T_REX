
-- Selecciona un usuario T_REX.SP_GetUsuario

IF OBJECT_ID('T_REX.SP_GetUsuario') IS NOT NULL
	DROP PROCEDURE [T_REX].[SP_GetUsuario];
GO

CREATE PROCEDURE [T_REX].[SP_GetUsuario]
	@username nvarchar(255)
AS
BEGIN
	select * from [T_REX].USUARIO U
	where username=@username
END
GO
