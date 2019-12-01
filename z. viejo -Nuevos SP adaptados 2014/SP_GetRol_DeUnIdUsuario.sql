CREATE PROCEDURE [CUATROGDD2018].[SP_GetRol_DeUnIdUsuario]
	@idUsuario int	
AS 
BEGIN
	SELECT nombre, habilitado 
	FROM [CUATROGDD2018].[Roles] R 
	JOIN  [CUATROGDD2018].[Usuario_X_Hotel_X_Rol] UR ON (UR.id_rol = R.id_rol)
	WHERE id_usuario=@idUsuario

END
GO


