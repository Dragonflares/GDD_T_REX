-- selecciona las funcionalidades habilitadas de un ROL /[T_REX].SP_Funcionalidad_por_Rol

IF OBJECT_ID('T_REX.SP_Funcionalidad_por_Rol') IS NOT NULL
    DROP PROCEDURE [T_REX].SP_Funcionalidad_por_Rol
GO

CREATE PROCEDURE [T_REX].SP_Funcionalidad_por_Rol	@id_rol	int
AS
BEGIN
	select f.id_funcionalidad, f.descripcion 
	from [T_REX].FUNCIONALIDAD f 
	JOIN [T_REX].FUNCIONALIDAD_ROL fr ON fr.ID_Funcionalidad = f.id_funcionalidad
	JOIN [T_REX].ROL r ON r.id_rol=fr.id_rol
	WHERE r.id_rol=@id_rol AND fr.estado = '1'
END
GO