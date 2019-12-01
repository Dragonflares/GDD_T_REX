CREATE PROCEDURE [CUATROGDD2018].[SP_GetAllHotel_PorIdUsuario]
	@idUsuario int
AS
BEGIN
		SELECT *FROM [CUATROGDD2018].[Hoteles] H 
		JOIN [CUATROGDD2018].[Usuario_X_Hotel_X_Rol] UH ON (H.id_hotel = UH.id_hotel)
		WHERE UH.ID_Usuario = @idUsuario
END
GO