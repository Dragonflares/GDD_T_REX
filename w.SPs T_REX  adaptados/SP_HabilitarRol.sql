-- [T_REX].SP_HabilitarRol

IF OBJECT_ID('T_REX.SP_HabilitarRol') IS NOT NULL
    DROP PROCEDURE T_REX.SP_HabilitarRol
GO

CREATE PROCEDURE [T_REX].[SP_HabilitarRol]  @id_Rol int
as
	update [T_REX].ROL
	set estado = '1'
	where id_rol=@id_Rol

go