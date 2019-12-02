-- Selecciono todos los roles asignados a un usuario [T_REX].[SP_GetRoles_id_usuario]

IF OBJECT_ID('[T_REX].[SP_GetRoles_id_usuario]') IS NOT NULL
	DROP PROCEDURE [T_REX].[SP_GetRoles_id_usuario];
GO

CREATE PROCEDURE [T_REX].[SP_GetRoles_id_usuario]
	@id_usuario int
as
begin
	select * from [T_REX].ROL r
	inner join [T_REX].ROL_USUARIO ru on r.id_rol=ru.id_rol 
	where id_usuario=@id_usuario
end
go