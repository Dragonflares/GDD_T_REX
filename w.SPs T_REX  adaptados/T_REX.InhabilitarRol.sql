-- Baja logica tabla Rol_Usuario y tabla Rol - [T_REX].SP_Inhabilitar_Rol

IF OBJECT_ID('T_REX.InhabilitarRol') IS NOT NULL
    DROP PROCEDURE [T_REX].InhabilitarRol
GO

CREATE PROCEDURE [T_REX].InhabilitarRol 
@rol_id int
AS
	declare @resultado varchar(10);
	if not exists (select 1 from [T_REX].ROL_USUARIO ru
				   inner join [T_REX].ROL r on ru.id_rol=r.id_rol
				   where ru.id_rol=@rol_id )
	begin
		update [T_REX].ROL_USUARIO 
		set activo='0'
		where [id_rol]=@rol_id;

		update [T_REX].ROL
		set estado='0'
		where [id_rol]=@rol_id;

		set @resultado='OK'
	end
	else set @resultado='Error'

	Select @resultado;

GO
