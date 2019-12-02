-- Alta ROL		[T_REX].[SP_Alta_NuevoRol]

IF OBJECT_ID('T_REX.[SP_Alta_NuevoRol]') IS NOT NULL
    DROP PROCEDURE [T_REX].[SP_Alta_NuevoRol]
GO
CREATE PROCEDURE [T_REX].[SP_Alta_NuevoRol] @nombre nvarchar(50)
AS
	declare @resultado nvarchar(10)
	if not exists (select 1 from [T_REX].ROL where nombre=@nombre)
		BEGIN
			insert into [T_REX].ROL (nombre)
			values (@nombre)
			
			SELECT @resultado = max(id_rol)
			from [T_REX].ROL

		END
	else set @resultado = 'ERROR'

	select @resultado;

GO