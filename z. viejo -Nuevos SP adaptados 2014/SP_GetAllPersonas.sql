CREATE PROCEDURE [CUATROGDD2018].[SP_GetAllPersonas]
AS
BEGIN
		SELECT id_persona, nombre, apellido, nro_documento, email, tipo_documento, telefono, nacionalidad, 
		direccion, nro_calle,piso,departamento, localidad,pais, fecha_nacimiento,estado 
		FROM [CUATROGDD2018].[Personas]
END
GO