-- [T_REX].SP_GetAll_Roles

IF OBJECT_ID('T_REX.SP_GetAllRoles') IS NOT NULL
    DROP PROCEDURE [T_REX].[SP_GetAllRoles]
GO

CREATE PROCEDURE [T_REX].[SP_GetAllRoles]
as
	select * from [T_REX].ROL

go
