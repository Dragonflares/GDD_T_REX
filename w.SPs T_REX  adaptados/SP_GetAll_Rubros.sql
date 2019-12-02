-- Selecciona todos los rubros [T_REX].SP_GetAll_Rubros

IF OBJECT_ID('T_REX.SP_GetAll_Rubros') IS NOT NULL
    DROP PROCEDURE [T_REX].SP_GetAll_Rubros
GO

CREATE PROCEDURE [T_REX].SP_GetAll_Rubros
AS
	SELECT * from [T_REX].RUBRO
GO