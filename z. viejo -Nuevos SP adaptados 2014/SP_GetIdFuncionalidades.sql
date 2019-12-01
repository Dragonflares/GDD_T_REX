CREATE PROCEDURE [CUATROGDD2018].[SP_GetIdFuncionalidades]
	@descripcion varchar(30)
AS 
BEGIN
	SELECT id_funcionalidad FROM [CUATROGDD2018].[Funcionalidades] WHERE descripcion=@descripcion
END
GO