CREATE PROCEDURE [CUATROGDD2018].[SP_FiltrarHoteles_SegunVariables]
	@IdUsuario int,
	@cantEstrellas numeric(18,0),
	@ciudad nvarchar(255),
	@pais nvarchar(255)
AS
BEGIN
	SELECT H.id_hotel, H.calle, H.cant_estrellas, H.ciudad, H.fecha_creacion,H.nro_calle, H.pais, H.recarga_estrellas, H.telefono
	FROM [CUATROGDD2018].[Hoteles] H 
	JOIN [CUATROGDD2018].[Usuario_X_Hotel_X_Rol] UH ON (H.id_hotel = UH.id_hotel)
	WHERE UH.ID_Usuario= @IdUsuario
	AND (H.Ciudad = @ciudad OR @ciudad IS NULL OR @ciudad = '')
	AND (H.Cant_Estrellas = @cantEstrellas OR @cantEstrellas IS NULL OR @cantEstrellas = 0)
	AND (H.Pais = @pais OR @pais IS NULL OR @pais = '')
END
GO


