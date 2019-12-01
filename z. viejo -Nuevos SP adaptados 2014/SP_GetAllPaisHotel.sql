CREATE PROCEDURE [CUATROGDD2018].[SP_GetAllPaisHotel]
	@Administrador int
AS
BEGIN
	
	SELECT H.pais
	FROM [CUATROGDD2018].[Hoteles] H 
	JOIN [CUATROGDD2018].[Usuario_X_Hotel_X_Rol] UH ON (UH.id_hotel=H.id_hotel)
	WHERE UH.id_usuario = @Administrador
	GROUP BY H.pais
	
END
GO

