-- Selecciono proveedores segun razon social / cuit /rubro SP_GetProveedores_porRs_cuit_rubro

IF OBJECT_ID('T_REX.SP_GetProveedores_porRs_cuit_rubro') IS NOT NULL
    DROP PROCEDURE [T_REX].SP_GetProveedores_porRs_cuit_rubro
GO
CREATE PROCEDURE [T_REX].SP_GetProveedores_porRs_cuit_rubro
	
	@razon_social nvarchar(150),
	@cuit nvarchar(40),
	@nombre_rubro nvarchar(150) 
AS
BEGIN
	SELECT * FROM T_REX.PROVEEDOR p   
	inner join T_REX.RUBRO r on r.id_rubro=p.id_rubro
	where p.provee_rs=@razon_social or p.provee_cuit=@cuit or r.nombreDeRubro=@nombre_rubro
END
GO