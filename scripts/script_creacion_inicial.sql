USE [GD2C2019]

GO

IF NOT EXISTS (SELECT * FROM SYS.SCHEMAS WHERE name = 'T_REX')
BEGIN
EXEC ('CREATE SCHEMA [T_REX] AUTHORIZATION [gdCupon2019]')
END
GO

/*##########################################################################################################
										CREACION DE TABLAS													
##########################################################################################################*/

-- Creacion de tabla DOMICILIO

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
		direc_calle nvarchar (100) NOT NULL,
		direc_piso	nvarchar (100) NOT NULL,
		direc_localidad nvarchar(100) NOT NULL,
		codigoPostal nvarchar (20) NOT NULL,
		direc_depto nvarchar(10) NOT NULL,
);
END
GO


-- Creacion de tabla FUNCIONALIDAD

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
		descripcion nvarchar (255) NOT NULL
);
END
GO

-- Creacion de tabla ROL

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
		nombre nvarchar (50) NOT NULL,
		estado bit NOT NULL DEFAULT 1
);
END

GO

-- Creacion de tabla FUNCIONALIDAD_ROL

IF NOT EXISTS (
		SELECT 1
		FROM INFORMATION_SCHEMA.TABLES
		WHERE TABLE_TYPE = 'BASE TABLE'
		AND TABLE_NAME = 'FUNCIONALIDAD_ROL'
		AND TABLE_SCHEMA = 'T_REX'
)
BEGIN
CREATE TABLE [T_REX].[FUNCIONALIDAD_ROL] (
		id_funcionalidad int  NOT NULL,
		id_rol int NOT NULL,
		estado bit NOT NULL DEFAULT 1,
		PRIMARY KEY ( [id_funcionalidad], [id_rol]),
		foreign key ([id_funcionalidad]) references [T_REX].[FUNCIONALIDAD]([id_funcionalidad]),
		foreign key ([id_rol]) references [T_REX].[ROL] ([id_rol])
);
END
GO

-- Creacion de tabla USUARIO

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
		username nvarchar (255) NOT NULL,
		password nvarchar (255) NOT NULL,
		intentos_login int NOT NULL DEFAULT (0),
		estado bit NOT NULL DEFAULT 1
);
END
GO

-- Creacion de tabla ROL_USUARIO

IF NOT EXISTS (
		SELECT 1
		FROM INFORMATION_SCHEMA.TABLES
		WHERE TABLE_TYPE = 'BASE TABLE'
		AND TABLE_NAME = 'ROL_USUARIO'
		AND TABLE_SCHEMA = 'T_REX'
)
BEGIN
CREATE TABLE [T_REX].[ROL_USUARIO] (
		id_usuario int NOT NULL,
		id_rol int NOT NULL,
		activo bit NOT NULL DEFAULT 1,
		PRIMARY KEY ( [id_usuario], [id_rol]),
		foreign key ([id_usuario]) references [T_REX].[USUARIO]([id_usuario]),
		foreign key ([id_rol]) references [T_REX].[ROL]([id_rol])
);
END
GO

-- Creacion de tabla RUBRO

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
		nombreDeRubro nvarchar (150) NOT NULL
);
END
GO

-- Creacion de tabla PROVEEDOR

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
		provee_rs nvarchar(150) NOT NULL,
		provee_cuit nvarchar(40) NOT NULL,
		email nvarchar(100) NOT NULL,
		provee_telefono int NOT NULL,
		estado bit NOT NULL DEFAULT 1,
		id_domicilio int FOREIGN KEY REFERENCES [T_REX].DOMICILIO(id_domicilio) NOT NULL,
		id_rubro int FOREIGN KEY REFERENCES [T_REX].RUBRO(id_rubro) NOT NULL,
		id_usuario int FOREIGN KEY REFERENCES [T_REX].USUARIO(id_usuario) NOT NULL
);
END

GO

-- Creacion de tabla CLIENTE

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
		nombre nvarchar(150) NOT NULL,
		apellido nvarchar(150) NOT NULL,
		nro_documento  decimal (18,0) NOT NULL,
		tipo_documento nvarchar(20) NOT NULL DEFAULT('DNI'),
		fechaDenacimiento datetime2 (3) NOT NULL,
		mail nvarchar (150) NOT NULL,
		telefono int NOT NULL,
		estado bit NOT NULL DEFAULT 1,
		creditoTotal int NOT NULL,
		id_domicilio int FOREIGN KEY REFERENCES [T_REX].DOMICILIO(id_domicilio) NOT NULL,
		id_usuario int FOREIGN KEY REFERENCES [T_REX].USUARIO(id_usuario) NOT NULL
);
END
GO

-- Creacion de tabla OFERTA

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
		cod_oferta nvarchar (60) NOT NULL,
		descripcion nvarchar (255) NOT NULL,
		fecha_inicio datetime  NOT NULL,
		fecha_fin datetime NOT NULL,
		precio_oferta decimal(30,2) NOT NULL,
		precio_lista decimal(30,2) NOT NULL,
		cantDisponible int NOT NULL,
		cant_max_porCliente  int NOT NULL,
		id_proveedor int FOREIGN KEY REFERENCES [T_REX].PROVEEDOR(id_proveedor) NOT NULL
);
END
GO

-- Creacion de tabla COMPRA

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
		compra_fecha datetime2 (3) NOT NULL,
		id_oferta int FOREIGN KEY REFERENCES [T_REX].OFERTA(id_oferta) NOT NULL,
		id_cliente int FOREIGN KEY REFERENCES [T_REX].CLIENTE(id_cliente) NOT NULL,
		cantidad decimal (15,0) NOT NULL
);
END
GO

-- Creacion de tabla TARJETA

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
		nro_tarjeta decimal (25,0) NOT NULL,
		titular_tarjeta nvarchar (150) NOT NULL,
		banco_tarjeta nvarchar(150) NOT NULL,
		tipo_tarjeta nvarchar (150) NOT NULL
);
END
GO

-- Creacion de tabla FORMA_PAGO

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
		tipo_pago_desc nvarchar (150) NOT NULL,
		marca nvarchar(100) NOT NULL
);
END
GO

-- Creacion de tabla CREDITO

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
		fecha_credito datetime2 (3) NOT NULL,
		id_cliente int FOREIGN KEY REFERENCES [T_REX].CLIENTE(id_cliente) NOT NULL,
		id_forma_pago int FOREIGN KEY REFERENCES [T_REX].FORMA_PAGO(id_forma_pago) NOT NULL,
		monto_credito decimal (20,2) NOT NULL,
		id_tarjeta int FOREIGN KEY REFERENCES [T_REX].TARJETA(id_tarjeta) NOT NULL
);
END
GO

-- Creacion de tabla FACTURA_PROVEEDOR

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
		nro_factura decimal(20,0) NOT NULL,
		importe_fact decimal (20,2) NOT NULL,
		fecha_inicio datetime2 (3) NOT NULL,
		fecha_fin datetime2 (3) NOT NULL,
		id_proveedor int FOREIGN KEY REFERENCES [T_REX].PROVEEDOR(id_proveedor) NOT NULL
);
END
GO

-- Creacion de tabla CLIENTE_DESTINO

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
		dest_nombre nvarchar(150) NOT NULL,
		dest_apellido nvarchar(150) NOT NULL,
		dest_nrodocumento decimal(18,0) NOT NULL,
		dest_tipo_documento nvarchar(20) NOT NULL DEFAULT 'DNI',
		dest_fecha_nacimiento datetime2(3) NOT NULL,
		dest_mail nvarchar(100) NOT NULL,
		dest_telefono int NOT NULL,
		id_domicilio int FOREIGN KEY REFERENCES [T_REX].DOMICILIO(id_domicilio) NOT NULL
);
END
GO

-- Creacion de tabla CUPON

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
		cupon_codigo nvarchar(60) NOT NULL,
		cupon_fecha_deconsumo datetime2(3) NOT NULL,
		cupon_precio_oferta decimal (20,2) NOT NULL,
		cupon_precio_lista decimal (20,2) NOT NULL,
		id_consumidor int FOREIGN KEY REFERENCES [T_REX].CLIENTE_DESTINO(id_consumidor) NOT NULL,
		cupon_estado bit NOT NULL DEFAULT 1,
		id_compra int FOREIGN KEY REFERENCES [T_REX].COMPRA(id_compra) NOT NULL
);
END

/*##########################################################################################################
										MIGRACION DE DATOS													
##########################################################################################################*/


/*Migracion de Rubros*/

INSERT INTO [T_REX].[RUBRO](
			nombreDeRubro
			)
SELECT DISTINCT Provee_Rubro 
FROM [gd_esquema].[Maestra] m
WHERE m.Provee_Rubro is not null
ORDER BY m.Provee_Rubro

--------

/*Creacion de Roles*/

INSERT INTO [T_REX].[ROL](nombre) VALUES ('Administrativo');
INSERT INTO [T_REX].[ROL](nombre) VALUES ('Cliente');
INSERT INTO [T_REX].[ROL](nombre) VALUES ('Proveedor');

----------------

/*Creacion de usuario Admin */

INSERT INTO [T_REX].[USUARIO] (username,password)
--user :admin pass: t12r
VALUES ('admin', '0xCA4D710175F395034CD7CA5D3B5E9D5CD34018A4FA8281E8D37389836D5F0E23');

--select HASHBYTES('SHA2_256', 't12r')

----------------

/*Creacion de ROL_USUARIO para el usuario admin*/

INSERT INTO [T_REX].[ROL_USUARIO] (id_usuario,id_rol) VALUES (1,1);
INSERT INTO [T_REX].[ROL_USUARIO] (id_usuario,id_rol) VALUES (1,2);
INSERT INTO [T_REX].[ROL_USUARIO] (id_usuario,id_rol) VALUES (1,3);

-------------------

/*Creacion de funcionalidades*/

INSERT INTO [T_REX].[FUNCIONALIDAD] (descripcion) VALUES ('ABM Rol');  --1
INSERT INTO [T_REX].[FUNCIONALIDAD] (descripcion) VALUES ('ABM Clientes'); --2
INSERT INTO [T_REX].[FUNCIONALIDAD] (descripcion) VALUES ('ABM Proveedor'); --3
INSERT INTO [T_REX].[FUNCIONALIDAD] (descripcion) VALUES ('Cargar Credito'); --4
INSERT INTO [T_REX].[FUNCIONALIDAD] (descripcion) VALUES ('Comprar Oferta'); --5
INSERT INTO [T_REX].[FUNCIONALIDAD] (descripcion) VALUES ('Publicar Oferta'); --6
INSERT INTO [T_REX].[FUNCIONALIDAD] (descripcion) VALUES ('Consumo Oferta'); --7
INSERT INTO [T_REX].[FUNCIONALIDAD] (descripcion) VALUES ('Facturacion Proveedor'); --8
INSERT INTO [T_REX].[FUNCIONALIDAD] (descripcion) VALUES ('Listado Estadistico');  --9

---------------------
/*Creacion de Funcionalidad_Rol*/

INSERT INTO [T_REX].[FUNCIONALIDAD_ROL] (id_rol,id_funcionalidad) VALUES (1,1);
INSERT INTO [T_REX].[FUNCIONALIDAD_ROL] (id_rol,id_funcionalidad) VALUES (1,2);
INSERT INTO [T_REX].[FUNCIONALIDAD_ROL] (id_rol,id_funcionalidad) VALUES (1,3);
INSERT INTO [T_REX].[FUNCIONALIDAD_ROL] (id_rol,id_funcionalidad) VALUES (1,8);
INSERT INTO [T_REX].[FUNCIONALIDAD_ROL] (id_rol,id_funcionalidad) VALUES (1,9);
INSERT INTO [T_REX].[FUNCIONALIDAD_ROL] (id_rol,id_funcionalidad) VALUES (2,4);
INSERT INTO [T_REX].[FUNCIONALIDAD_ROL] (id_rol,id_funcionalidad) VALUES (2,5);
INSERT INTO [T_REX].[FUNCIONALIDAD_ROL] (id_rol,id_funcionalidad) VALUES (3,7);
INSERT INTO [T_REX].[FUNCIONALIDAD_ROL] (id_rol,id_funcionalidad) VALUES (3,6);

