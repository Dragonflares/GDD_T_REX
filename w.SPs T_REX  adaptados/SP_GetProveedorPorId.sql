-- Selecciono un proveedor por ID  // [T_REX].SP_GetProveedorPorId

IF OBJECT_ID('[T_REX].SP_GetProveedorPorId') IS NOT NULL
    DROP PROCEDURE [T_REX].SP_GetProveedorPorId
GO
CREATE PROCEDURE [T_REX].[SP_GetEmpresaPorId]
	
	@id_proveedor int
AS
BEGIN
	SELECT * FROM T_REX.PROVEEDOR WHERE id_proveedor=@id_proveedor
END
GO