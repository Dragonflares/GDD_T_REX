CREATE PROCEDURE [CUATROGDD2018].[SP_ModificarRol]
	@idRol int,
	@nombre varchar(50),
	@habilitado bit
AS 
BEGIN
	UPDATE CUATROGDD2018.Roles 
	SET nombre=@nombre, 
	habilitado=@habilitado
	WHERE id_rol=@idRol

END
GO