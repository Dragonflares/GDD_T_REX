CREATE PROCEDURE [CUATROGDD2018].[SP_GetTipoHabitacion_PorId]
	@IdTipoHab int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM [CUATROGDD2018].[Tipo_Habitacion] T 
	WHERE T.id_tipo_habitacion = @IdTipoHab
END
GO