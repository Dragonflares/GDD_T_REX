CREATE PROCEDURE [CUATROGDD2018].[SP_GetIdRol_PorNombre]
	@nombreRol varchar(50)
AS 
BEGIN
	SELECT id_rol FROM [CUATROGDD2018].[Roles] 
	WHERE nombre=@nombreRol
END
GO