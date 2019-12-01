CREATE PROCEDURE [CUATROGDD2018].[SP_GetAllCiudadesDeHotel_PorIdUsuario]
	@administrador int
AS
BEGIN
	
	SELECT H.Ciudad
	FROM [CUATROGDD2018].[Hoteles] H 
	JOIN [CUATROGDD2018].[Usuario_X_Hotel_X_Rol] UH ON (H.id_hotel = UH.id_hotel)
	WHERE UH.ID_Usuario = @administrador
	GROUP BY H.Ciudad
	
END
GO

