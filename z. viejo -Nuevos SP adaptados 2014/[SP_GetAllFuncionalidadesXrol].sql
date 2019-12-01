CREATE PROCEDURE [CUATROGDD2018].[SP_GetAllFuncionalidadesXrol]
	@idRol	int
AS
BEGIN
	SET NOCOUNT ON;
	select F.ID_Funcionalidad, F.descripcion from [CUATROGDD2018].[Funcionalidades] F 
	JOIN [CUATROGDD2018].[Funcionalidad_X_Rol] FR ON (FR.ID_Funcionalidad = F.ID_Funcionalidad)
	JOIN [CUATROGDD2018].[Roles] R ON (R.id_rol=FR.id_rol)
	WHERE R.id_rol=@idRol
END
GO


