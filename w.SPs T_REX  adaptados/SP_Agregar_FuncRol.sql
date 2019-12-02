--- AGREGAR FUNCIONALIDAD AL ROL / T_REX.SP_Agregar_FuncRol

IF OBJECT_ID('T_REX.SP_Agregar_FuncRol') IS NOT NULL
    DROP PROCEDURE T_REX.SP_Agregar_FuncRol
GO

CREATE PROCEDURE [T_REX].[SP_Agregar_FuncRol] @id_rol int, @id_func int
as
	declare @resultado varchar(10);

	if not exists (select 1 from [T_REX].FUNCIONALIDAD_ROL where id_rol=@id_rol and id_funcionalidad=@id_func)
		begin
			insert into [T_REX].FUNCIONALIDAD_ROL (id_rol,id_funcionalidad)
			values (@id_rol,@id_func);

			set @resultado='OK';
		end
	else
		begin
		if exists (select 1 from [T_REX].FUNCIONALIDAD_ROL  where id_rol=@id_rol and id_funcionalidad=@id_func)
			begin
				update [T_REX].FUNCIONALIDAD_ROL
				set estado = '1'
				where id_rol=@id_rol 
				and id_funcionalidad=@id_func;

				set @resultado='OK';
			end
		else set @resultado='ERROR';
		end
	
	select @resultado;
GO
