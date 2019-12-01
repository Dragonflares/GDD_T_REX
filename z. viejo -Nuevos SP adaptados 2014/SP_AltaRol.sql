CREATE PROCEDURE [CUATROGDD2018].[SP_AltaRol]
	@nombre varchar(50),
	@habilitado bit out
	
AS
BEGIN
	INSERT INTO [CUATROGDD2018].[Roles] (nombre, habilitado)
	VALUES (@nombre,@habilitado)
	
END
GO
