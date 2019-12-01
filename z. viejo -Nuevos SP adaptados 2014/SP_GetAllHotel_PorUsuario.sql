CREATE PROCEDURE [CUATROGDD2018].[SP_GetAllHotel_PorUsuario]
	@idUsuario int
AS 
BEGIN
	
	SELECT id_hotel FROM [CUATROGDD2018].[Usuario_X_Hotel_X_Rol] 
	WHERE id_usuario=@idUsuario

END
GO