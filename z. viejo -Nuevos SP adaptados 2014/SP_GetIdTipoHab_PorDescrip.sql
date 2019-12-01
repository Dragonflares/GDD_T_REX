CREATE PROCEDURE [CUATROGDD2018].[SP_GetIdTipoHab_PorDescrip]
	@descripcion nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT TOP 1 (T.id_tipo_habitacion) FROM [CUATROGDD2018].[Tipo_Habitacion] T 
	WHERE T.descripcion = @descripcion
END
GO