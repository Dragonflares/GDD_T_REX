CREATE FUNCTION [CUATROGDD2018].[FUN_IdRegimen]
(
	@descripcion nvarchar(255)
)
RETURNS numeric(18,0)
AS
BEGIN
	RETURN (
	SELECT id_regimen
	FROM [CUATROGDD2018].[Regimenes_Estadia]
	WHERE descripcion = @descripcion
	)

END
GO

CREATE PROCEDURE [CUATROGDD2018].[SP_EliminarRegimenDeHotel]
	@idHotel int,
	@descripcion nvarchar(255)
AS
BEGIN
	DELETE FROM [CUATROGDD2018].[Regimen_X_Hotel]
	WHERE id_hotel = @idHotel AND id_regimen = [CUATROGDD2018].[FUN_IdRegimen](@descripcion)	

END
GO

