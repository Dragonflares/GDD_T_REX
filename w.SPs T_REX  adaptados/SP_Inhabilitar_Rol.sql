-- Baja logica Rol - [T_REX].SP_Inhabilitar_Rol

IF OBJECT_ID('T_REX.SP_Inhabilitar_Rol') IS NOT NULL
    DROP PROCEDURE [T_REX].SP_Inhabilitar_Rol
GO

CREATE PROCEDURE [T_REX].SP_Inhabilitar_Rol @id_rol int
AS
	declare @resultado varchar(10);
	if not exists (select 1 from [T_REX].ROL_USUARIO ru
				   inner join [T_REX].USUARIO u on ru.id_usuario=u.id_usuario
				   where ru.id_rol=@id_rol )
	begin
		update [T_REX].ROL_USUARIO 
		set activo='0'
		where [id_rol]=@id_rol;

		update [T_REX].ROL
		set estado = '1'
		where id_rol=@id_rol;

		set @resultado='OK'
	end
	else set @resultado='Error'

	Select @resultado;

GO