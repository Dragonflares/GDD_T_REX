
-- [T_REX].[UpdateRol]

IF OBJECT_ID('T_REX.UpdateRol') IS NOT NULL
    DROP PROCEDURE [T_REX].[UpdateRol]
GO

CREATE PROCEDURE [T_REX].[UpdateRol]
	@idRol int,
	@nombre varchar(50),
	@estado bit
as 
begin
	UPDATE [T_REX].ROL 
	SET nombre=@nombre, 
	estado=@estado
	WHERE id_rol=@idRol

end
go