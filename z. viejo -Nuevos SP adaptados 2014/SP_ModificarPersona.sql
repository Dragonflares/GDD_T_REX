CREATE PROCEDURE [CUATROGDD2018].[SP_ModificarPersona]
(	
	@id_persona int,
	@nacionalidad nvarchar(255),
	@nro_documento numeric(18, 0), 
	@apellido nvarchar(255), 
	@nombre nvarchar(255),
	@fecha_nac datetime,
	@email nvarchar(255),
	@direccion nvarchar(255),
	@piso numeric(18, 0),
	@depto nvarchar(255),
	@nro_calle numeric(18, 0),
	@estado bit,
	@pais nvarchar(255),
	@telefono numeric(18, 0),
	@tipo_Documento nvarchar(50),
	@localidad nvarchar(255)
)
AS
BEGIN
	DECLARE @MENSAJE nvarchar(255);
	
	IF EXISTS (SELECT nro_documento FROM [CUATROGDD2018].[Personas]  WHERE nro_documento = @nro_documento)
	BEGIN
		SET @MENSAJE = 'El numero de documento ya se encuentra registrado'
		SELECT @MENSAJE
		RETURN
	END
	ELSE IF EXISTS (SELECT email FROM [CUATROGDD2018].[Personas] WHERE email = @email)
	BEGIN
		SET @MENSAJE = 'El mail ya se encuentra registrado'
		SELECT @MENSAJE
		RETURN
	END
	ELSE
		
		UPDATE [CUATROGDD2018].[Personas]
		SET 
			nacionalidad=@nacionalidad,
			nro_documento=@nro_documento,
			nombre=@nombre, 
			apellido=@apellido,
			fecha_nacimiento=@fecha_nac, 
			direccion=@direccion, 
			piso=@piso,
			departamento=@depto, 
			email=@email,
			estado=@estado,
			nro_calle= @nro_calle,
			pais = @pais,
			telefono= @telefono,
			tipo_documento= @tipo_Documento,
			localidad=@localidad 

		WHERE id_persona=@id_persona

END
GO