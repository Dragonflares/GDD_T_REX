-- Selecciono todas las funcionalidades [T_REX].SP_GetAll_Funcionalidad

IF OBJECT_ID('[T_REX].SP_GetAll_Funcionalidad') IS NOT NULL
    DROP PROCEDURE [T_REX].SP_GetAll_Funcionalidad
GO

CREATE PROCEDURE [T_REX].SP_GetAll_Funcionalidad
AS
	select * from [T_REX].FUNCIONALIDAD
GO