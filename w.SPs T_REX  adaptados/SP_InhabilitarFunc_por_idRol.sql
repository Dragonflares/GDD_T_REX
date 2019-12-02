-- Inhabilitar funcionalidad de un rol SP_InhabilitarFunc_por_idRol

IF OBJECT_ID('T_REX.SP_InhabilitarFunc_por_idRol') IS NOT NULL
    DROP PROCEDURE [T_REX].SP_InhabilitarFunc_por_idRol
GO

CREATE PROCEDURE [T_REX].SP_InhabilitarFunc_por_idRol 
@id_rol int

as
begin
		update [T_REX].FUNCIONALIDAD_ROL
		set estado = '0'
		where id_rol=@id_rol;
end
go