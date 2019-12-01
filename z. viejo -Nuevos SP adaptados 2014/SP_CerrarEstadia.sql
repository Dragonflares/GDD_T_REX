CREATE PROCEDURE [CUATROGDD2018].[SP_CerrarEstadia]
	@idEstadia int,
	@usuario int
AS
BEGIN
	UPDATE [CUATROGDD2018].[Estadias]
	SET id_usuario_checkOut=@usuario 
	WHERE id_estadia=@idEstadia
END
GO