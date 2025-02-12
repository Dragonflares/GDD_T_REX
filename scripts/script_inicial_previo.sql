USE [GD2C2019]

GO

IF NOT EXISTS (SELECT * FROM SYS.SCHEMAS WHERE name = 'T_REX')
BEGIN
EXEC ('CREATE SCHEMA [T_REX] AUTHORIZATION [gdCupon2019]')
END
GO

IF NOT EXISTS (
		SELECT *
		FROM INFORMATION_SCHEMA.TABLES
		WHERE TABLE_TYPE = 'BASE TABLE'
		AND TABLE_NAME = 'DOMICILIO'
		AND TABLE_SCHEMA = 'T_REX'
)
BEGIN
CREATE TABLE [T_REX].[DOMICILIO] (
		id_domicilio int IDENTITY(1,1) PRIMARY KEY NOT NULL,
		direc_calle [nvarchar](100) NOT NULL,
		direc_localidad [nvarchar](100) NOT NULL,
		direc_codigoPostal [nvarchar](20) NOT NULL,
		direc_depto [nvarchar](10) NOT NULL,
);
END
GO

IF NOT EXISTS (
		SELECT 1
		FROM INFORMATION_SCHEMA.TABLES
		WHERE TABLE_TYPE = 'BASE TABLE'
		AND TABLE_NAME = 'FUNCIONALIDAD'
		AND TABLE_SCHEMA = 'T_REX'
)
BEGIN
CREATE TABLE [T_REX].[FUNCIONALIDAD] (
		id_funcionalidad int IDENTITY(1,1) PRIMARY KEY NOT NULL,
		func_descripcion [nvarchar](255) NOT NULL
);
END
GO

IF NOT EXISTS (
		SELECT 1
		FROM INFORMATION_SCHEMA.TABLES
		WHERE TABLE_TYPE = 'BASE TABLE'
		AND TABLE_NAME = 'ROL'
		AND TABLE_SCHEMA = 'T_REX'
)
BEGIN
CREATE TABLE [T_REX].[ROL] (
		id_rol int IDENTITY(1,1) PRIMARY KEY NOT NULL,
		rol_nombre [nvarchar](50) NOT NULL,
		rol_estado [bit] NOT NULL DEFAULT 1
);
END

GO

IF NOT EXISTS (
		SELECT 1
		FROM INFORMATION_SCHEMA.TABLES
		WHERE TABLE_TYPE = 'BASE TABLE'
		AND TABLE_NAME = 'FUNCIONALIDAD_ROL'
		AND TABLE_SCHEMA = 'T_REX'
)
BEGIN
CREATE TABLE [T_REX].[FUNCIONALIDAD_ROL] (
		id_funcionalidad_rol int IDENTITY(1,1) PRIMARY KEY NOT NULL,
		rol_id int FOREIGN KEY REFERENCES [T_REX].ROL(id_rol) NOT NULL,
		func_id int FOREIGN KEY REFERENCES [T_REX].FUNCIONALIDAD(id_funcionalidad) NOT NULL
);
END
GO

IF NOT EXISTS (
		SELECT 1
		FROM INFORMATION_SCHEMA.TABLES
		WHERE TABLE_TYPE = 'BASE TABLE'
		AND TABLE_NAME = 'USUARIO'
		AND TABLE_SCHEMA = 'T_REX'
)
BEGIN
CREATE TABLE [T_REX].[USUARIO] (
		id_usuario int IDENTITY(1,1) PRIMARY KEY NOT NULL,
		user_username [nvarchar](255) NOT NULL,
		user_password [nvarchar](24) NOT NULL,
		user_intentos_login [decimal](3,0) NOT NULL,
		user_estado [bit] NOT NULL DEFAULT 1
);
END
GO

IF NOT EXISTS (
		SELECT 1
		FROM INFORMATION_SCHEMA.TABLES
		WHERE TABLE_TYPE = 'BASE TABLE'
		AND TABLE_NAME = 'ROL_USUARIO'
		AND TABLE_SCHEMA = 'T_REX'
)
BEGIN
CREATE TABLE [T_REX].[ROL_USUARIO] (
		id_rol_usuario int IDENTITY(1,1) PRIMARY KEY NOT NULL,
		rol_id int FOREIGN KEY REFERENCES [T_REX].ROL(id_rol) NOT NULL,
		user_id int FOREIGN KEY REFERENCES [T_REX].USUARIO(id_usuario) NOT NULL
);
END
GO

IF NOT EXISTS (
		SELECT 1
		FROM INFORMATION_SCHEMA.TABLES
		WHERE TABLE_TYPE = 'BASE TABLE'
		AND TABLE_NAME = 'RUBRO'
		AND TABLE_SCHEMA = 'T_REX'
)
BEGIN
CREATE TABLE [T_REX].[RUBRO] (
		id_rubro int IDENTITY(1,1) PRIMARY KEY NOT NULL,
		rub_nombre [nvarchar](150) NOT NULL
);
END
GO

IF NOT EXISTS (
		SELECT 1
		FROM INFORMATION_SCHEMA.TABLES
		WHERE TABLE_TYPE = 'BASE TABLE'
		AND TABLE_NAME = 'PROVEEDOR'
		AND TABLE_SCHEMA = 'T_REX'
)
BEGIN
CREATE TABLE [T_REX].[PROVEEDOR] (
		id_proveedor int IDENTITY(1,1) PRIMARY KEY NOT NULL,
		provee_rs [nvarchar](150) NOT NULL,
		provee_cuit [nvarchar](40) NOT NULL,
		provee_email [nvarchar](100) NOT NULL,
		provee_telefono [int] NOT NULL,
		provee_estado [bit] NOT NULL DEFAULT 1,
		provee_domicilio int FOREIGN KEY REFERENCES [T_REX].DOMICILIO(id_domicilio) NOT NULL,
		provee_rubro int FOREIGN KEY REFERENCES [T_REX].RUBRO(id_rubro) NOT NULL,
		provee_usuario int FOREIGN KEY REFERENCES [T_REX].USUARIO(id_usuario) NOT NULL
);
END

GO

IF NOT EXISTS (
		SELECT 1
		FROM INFORMATION_SCHEMA.TABLES
		WHERE TABLE_TYPE = 'BASE TABLE'
		AND TABLE_NAME = 'CLIENTE'
		AND TABLE_SCHEMA = 'T_REX'
)
BEGIN
CREATE TABLE [T_REX].[CLIENTE] (
		id_cliente int IDENTITY(1,1) PRIMARY KEY NOT NULL,
		cli_nombre [nvarchar](150) NOT NULL,
		cli_apellido [nvarchar](150) NOT NULL,
		cli_nro_documento  [decimal](18,0) NOT NULL,
		cli_fecha_de_nacimiento [datetime2](3) NOT NULL,
		cli_mail [nvarchar](150) NOT NULL,
		cli_telefono [int] NOT NULL,
		cli_estado [bit] NOT NULL DEFAULT 1,
		cli_domicilio int FOREIGN KEY REFERENCES [T_REX].DOMICILIO(id_domicilio) NOT NULL,
		cli_usuario int FOREIGN KEY REFERENCES [T_REX].USUARIO(id_usuario) NOT NULL
);
END
GO

IF NOT EXISTS (
		SELECT 1
		FROM INFORMATION_SCHEMA.TABLES
		WHERE TABLE_TYPE = 'BASE TABLE'
		AND TABLE_NAME = 'OFERTA'
		AND TABLE_SCHEMA = 'T_REX'
)
BEGIN
CREATE TABLE [T_REX].[OFERTA] (
		id_oferta int IDENTITY(1,1) PRIMARY KEY NOT NULL,
		of_cod_oferta [nvarchar](60) NOT NULL,
		of_descripcion [nvarchar](255) NOT NULL,
		of_fecha_inicio [datetime2](3) NOT NULL,
		of_fecha_fin [datetime2](3) NOT NULL,
		of_precio_oferta [decimal](30,2) NOT NULL,
		of_precio_lista [decimal](30,2) NOT NULL,
		of_cant_disponible [decimal](30,2) NOT NULL,
		of_cant_max_por_cliente [decimal](30,2) NOT NULL,
		of_proveedor int FOREIGN KEY REFERENCES [T_REX].PROVEEDOR(id_proveedor) NOT NULL
);
END
GO

IF NOT EXISTS (
		SELECT 1
		FROM INFORMATION_SCHEMA.TABLES
		WHERE TABLE_TYPE = 'BASE TABLE'
		AND TABLE_NAME = 'COMPRA'
		AND TABLE_SCHEMA = 'T_REX'
)
BEGIN
CREATE TABLE [T_REX].[COMPRA] (
		id_compra int IDENTITY(1,1) PRIMARY KEY NOT NULL,
		comp_fecha [datetime2](3) NOT NULL,
		comp_oferta int FOREIGN KEY REFERENCES [T_REX].OFERTA(id_oferta) NOT NULL,
		comp_cliente int FOREIGN KEY REFERENCES [T_REX].CLIENTE(id_cliente) NOT NULL,
		comp_cantidad [decimal](15,0) NOT NULL
);
END
GO

IF NOT EXISTS (
		SELECT 1
		FROM INFORMATION_SCHEMA.TABLES
		WHERE TABLE_TYPE = 'BASE TABLE'
		AND TABLE_NAME = 'TARJETA'
		AND TABLE_SCHEMA = 'T_REX'
)
BEGIN
CREATE TABLE [T_REX].[TARJETA] (
		id_tarjeta int IDENTITY(1,1) PRIMARY KEY NOT NULL,
		tarj_num [decimal](25,0) NOT NULL,
		tarj_titular [nvarchar](150) NOT NULL,
		tarj_banco [nvarchar](150) NOT NULL,
		tark_tipo [nvarchar](150) NOT NULL
);
END
GO

IF NOT EXISTS (
		SELECT 1
		FROM INFORMATION_SCHEMA.TABLES
		WHERE TABLE_TYPE = 'BASE TABLE'
		AND TABLE_NAME = 'FORMA_PAGO'
		AND TABLE_SCHEMA = 'T_REX'
)
BEGIN
CREATE TABLE [T_REX].[FORMA_PAGO] (
		id_forma_pago int IDENTITY(1,1) PRIMARY KEY NOT NULL,
		fp_tipo_pago_desc [nvarchar](150) NOT NULL,
		fp_marca [nvarchar](100) NOT NULL
);
END
GO

IF NOT EXISTS (
		SELECT 1
		FROM INFORMATION_SCHEMA.TABLES
		WHERE TABLE_TYPE = 'BASE TABLE'
		AND TABLE_NAME = 'CREDITO'
		AND TABLE_SCHEMA = 'T_REX'
)
BEGIN
CREATE TABLE [T_REX].[CREDITO] (
		id_credito int IDENTITY(1,1) PRIMARY KEY NOT NULL,
		cred_fecha [datetime2](3) NOT NULL,
		cred_cliente int FOREIGN KEY REFERENCES [T_REX].CLIENTE(id_cliente) NOT NULL,
		cred_tipo_pago int FOREIGN KEY REFERENCES [T_REX].FORMA_PAGO(id_forma_pago) NOT NULL,
		cred_monto [decimal](20,2) NOT NULL,
		cred_tarjeta int FOREIGN KEY REFERENCES [T_REX].TARJETA(id_tarjeta) NOT NULL
);
END
GO

IF NOT EXISTS (
		SELECT 1
		FROM INFORMATION_SCHEMA.TABLES
		WHERE TABLE_TYPE = 'BASE TABLE'
		AND TABLE_NAME = 'FACTURA_PROVEEDOR'
		AND TABLE_SCHEMA = 'T_REX'
)
BEGIN
CREATE TABLE [T_REX].[FACTURA_PROVEEDOR] (
		id_factura int IDENTITY(1,1) PRIMARY KEY NOT NULL,
		fact_num_factura [decimal](100,0) NOT NULL,
		fact_importe [decimal](20,2) NOT NULL,
		fact_fecha_inicio [datetime2](3) NOT NULL,
		fact_fecha_fin [datetime2](3) NOT NULL,
		fact_proveedor int FOREIGN KEY REFERENCES [T_REX].PROVEEDOR(id_proveedor) NOT NULL
);
END
GO

IF NOT EXISTS (
		SELECT 1
		FROM INFORMATION_SCHEMA.TABLES
		WHERE TABLE_TYPE = 'BASE TABLE'
		AND TABLE_NAME = 'CLIENTE_DESTINO'
		AND TABLE_SCHEMA = 'T_REX'
)
BEGIN
CREATE TABLE [T_REX].[CLIENTE_DESTINO] (
		id_consumidor int IDENTITY(1,1) PRIMARY KEY NOT NULL,
		cli_dest_nombre nvarchar(150) NOT NULL,
		cli_dest_apellido [nvarchar](150) NOT NULL,
		cli_dest_documento [decimal](18,0) NOT NULL,
		cli_dest_tipo_documento [nvarchar](20) NOT NULL DEFAULT 'DNI',
		cli_dest_fecha_de_nacimiento [datetime2](3) NOT NULL,
		cli_dest_mail [nvarchar](100) NOT NULL,
		cli_dest_telefono [int] NOT NULL,
		cli_dest_domicilio int FOREIGN KEY REFERENCES [T_REX].DOMICILIO(id_domicilio) NOT NULL
);
END
GO

IF NOT EXISTS (
		SELECT 1
		FROM INFORMATION_SCHEMA.TABLES
		WHERE TABLE_TYPE = 'BASE TABLE'
		AND TABLE_NAME = 'CUPON'
		AND TABLE_SCHEMA = 'T_REX'
)
BEGIN
CREATE TABLE [T_REX].[CUPON] (
		id_cupon int IDENTITY(1,1) PRIMARY KEY NOT NULL,
		cupon_codigo [nvarchar](60) NOT NULL,
		cupon_fecha_de_consumo [datetime2](3) NOT NULL,
		cupon_precio_oferta [decimal](20,2) NOT NULL,
		cupon_precio_lista [decimal](20,2) NOT NULL,
		cupon_consumidor int FOREIGN KEY REFERENCES [T_REX].CLIENTE_DESTINO(id_consumidor) NOT NULL,
		cupon_estado [bit] NOT NULL DEFAULT 1,
		cupon_compra int FOREIGN KEY REFERENCES [T_REX].COMPRA(id_compra) NOT NULL
);
END