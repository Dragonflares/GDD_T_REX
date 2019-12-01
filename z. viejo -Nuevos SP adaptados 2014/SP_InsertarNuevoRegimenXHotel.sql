
CREATE FUNCTION [CUATROGDD2018].[FUN_IdRegimen]
(
	@descripcion nvarchar(255)
)
RETURNS numeric(18,0)
AS
BEGIN
	RETURN (
	SELECT id_regimen FROM [CUATROGDD2018].[Regimenes_Estadia]
	WHERE descripcion = @descripcion
	)
END
GO



CREATE PROCEDURE [CUATROGDD2018].[SP_InsertarNuevoRegimenXHotel]
	@idHotel int,
	@descripcion NVARCHAR(255)
AS
BEGIN
	
	DECLARE @idRegimen int
	SET @idRegimen = [CUATROGDD2018].[FUN_IdRegimen](@descripcion)
	
	IF (@idRegimen IS NOT NULL)
	BEGIN
		INSERT INTO [CUATROGDD2018].[Regimen_X_Hotel](id_hotel,id_regimen)
		VALUES(@idHotel,@idRegimen)
	END
		
END
GO