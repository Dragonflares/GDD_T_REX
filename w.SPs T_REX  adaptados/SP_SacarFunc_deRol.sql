-- Sacar funcionalidad a un rol // [T_REX].SP_SacarFunc_deRol

IF OBJECT_ID('T_REX.SP_SacarFunc_deRol') IS NOT NULL
    DROP PROCEDURE [T_REX].SP_SacarFunc_deRol
GO

CREATE PROCEDURE [T_REX].[SP_SacarFunc_deRol] 
@id_rol int, 
@id_funcionalidad int
as
	if exists (select 1 from [T_REX].FUNCIONALIDAD_ROL where id_rol=@id_rol and id_funcionalidad=@id_funcionalidad and estado='1')
	begin
		update [T_REX].FUNCIONALIDAD_ROL 
		set estado = '0'
		where id_funcionalidad=@id_funcionalidad and id_rol=@id_rol;
	end
GO
