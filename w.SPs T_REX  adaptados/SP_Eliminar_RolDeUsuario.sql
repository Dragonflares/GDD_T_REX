-- [T_REX].SP_Eliminar_RolDeUsuario

IF OBJECT_ID('T_REX.SP_Eliminar_RolDeUsuario') IS NOT NULL
    DROP PROCEDURE [T_REX].SP_Eliminar_RolDeUsuario
GO

CREATE PROCEDURE [T_REX].SP_Eliminar_RolDeUsuario
	@id_rol int,
	@id_usuario int
as
begin
	delete from [T_REX].ROL_USUARIO 
	where id_rol=@id_rol AND id_usuario=@id_usuario; 
end
go