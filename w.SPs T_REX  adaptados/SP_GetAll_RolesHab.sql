-- Selecciono roles habilitados  [T_REX].SP_GetAll_RolesHab

IF OBJECT_ID('T_REX.SP_GetAll_RolesHab') IS NOT NULL
    DROP PROCEDURE [T_REX].SP_GetAll_RolesHab
GO

CREATE PROCEDURE [T_REX].SP_GetAll_RolesHab
as
begin
	select * from [T_REX].Rol
	where estado='1'
	order by nombre
end
go