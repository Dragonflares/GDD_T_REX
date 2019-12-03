-- Selecciono proveedores segun razon social / cuit /rubro SP_GetProveedores_porRs_cuit_rubro

IF OBJECT_ID('T_REX.SP_GetClientes_pornombre_apellido_mail_dni') IS NOT NULL
    DROP PROCEDURE [T_REX].SP_GetClientes_pornombre_apellido_mail_dni 
GO
CREATE PROCEDURE [T_REX].SP_GetClientes_pornombre_apellido_mail_dni
	
	@nombre nvarchar(150),
	@apellido nvarchar(150),
	@mail nvarchar (150),
	@dni nvarchar (150)
AS
BEGIN
	SELECT * FROM T_REX.CLIENTE c   
	where c.nombre=@nombre or c.apellido=@apellido or c.email=@mail or c.nro_documento=@dni
END
GO

--exec [T_REX].SP_GetClientes_pornombre_apellido_mail_dni ('admin', , , , '988') 

