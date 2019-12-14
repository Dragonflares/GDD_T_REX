-- ACTIVAR ROL[T_REX].ActivarRol

IF OBJECT_ID('T_REX.ActivarRol') IS NOT NULL
    DROP PROCEDURE [T_REX].ActivarRol
GO

CREATE PROCEDURE T_REX.ActivarRol
@rol_id int
as
	update [T_REX].ROL
	set estado = '1'
	where id_rol=@rol_id

go