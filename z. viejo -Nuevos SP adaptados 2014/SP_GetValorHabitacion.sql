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


CREATE PROCEDURE [CUATROGDD2018].[SP_GetValorHabitacion]
	@idHotel int,
	@idHabitacion int,
	@descripcionRegimen nvarchar(255),
	@descripcionTipoHab nvarchar(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	DECLARE @ValorHab NUMERIC(18,2), @capacidad int
	SET @capacidad = ( select resultado = case descripcion
												when 'Base Simple' then '1'
												when 'Base Doble' then '2'
												when 'Base Triple' then '3'
												when 'Base Cuadruple' then '4'
												when 'King' then '5'
											else 'sin datos'
											end 
						from [CUATROGDD2018].Tipo_Habitacion
						where descripcion= @descripcionTipoHab)
		
	SET @ValorHab = 
	(
	SELECT(H.recarga_estrellas+R.precio_base)*@capacidad+TH.porcentual*(H.recarga_estrellas+R.precio_base)*@capacidad/100
	FROM [CUATROGDD2018].[Hoteles] H 
		JOIN [CUATROGDD2018].[Habitaciones] HA ON (H.id_hotel = HA.id_hotel)
		JOIN  [CUATROGDD2018].[Tipo_Habitacion] TH ON (HA.id_tipo_habitacion = TH.id_tipo_habitacion)
		JOIN [CUATROGDD2018].[Regimen_X_Hotel] RH ON (RH.id_hotel = H.id_hotel)
		JOIN [CUATROGDD2018].[Regimenes_Estadia] R ON (R.id_regimen = RH.id_regimen)
	WHERE H.id_hotel =@idHotel AND R.id_regimen = [CUATROGDD2018].[FUN_IdRegimen](@descripcionRegimen) AND HA.id_habitacion = @idHabitacion
	)
	IF (@ValorHab IS NULL)
	BEGIN
		SET @ValorHab = 0;
	END
	
	SELECT @ValorHab

END

