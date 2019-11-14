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
		direc_nro_piso	nvarchar (100) default 'No definido',
		direc_localidad nvarchar(255) NOT NULL,
		codigoPostal nvarchar (50) default 'No definido',
		direc_nro_depto nvarchar(50) default 'No definido',
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
		intentos_USUARIO int NOT NULL DEFAULT (0),
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
		email nvarchar(100) default 'No definido',
		provee_telefono int default 'No definido',
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
		fechaDeNacimiento datetime2 (3) NOT NULL,
		mail nvarchar (150) NOT NULL,
		telefono int NOT NULL,
		estado bit NOT NULL DEFAULT 1,
		creditoTotal decimal (18,0) NOT NULL,
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
		nro_tarjeta [nvarchar](150) NOT NULL,
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

-------------------------------------------------------------------------------------------------------------

/*Creacion de Roles*/

INSERT INTO [T_REX].[ROL](nombre) VALUES ('Administrativo');
INSERT INTO [T_REX].[ROL](nombre) VALUES ('Cliente');
INSERT INTO [T_REX].[ROL](nombre) VALUES ('Proveedor');

--------------------------------------------------------------------------------------------------------------

/*Creacion de usuario Admin */

INSERT INTO [T_REX].[USUARIO] (username,password)
--user :admin pass: t12r
VALUES ('admin', '0xCA4D710175F395034CD7CA5D3B5E9D5CD34018A4FA8281E8D37389836D5F0E23');

--select HASHBYTES('SHA2_256', 't12r')
--select HASHBYTES('SHA2_256', '1234') contraseña para usuarios y proveedores

---------------------------------------------------------------------------------------------------------------

/*Creacion de ROL_USUARIO para el usuario admin*/

INSERT INTO [T_REX].[ROL_USUARIO] (id_usuario,id_rol) VALUES (1,1);
INSERT INTO [T_REX].[ROL_USUARIO] (id_usuario,id_rol) VALUES (1,2);
INSERT INTO [T_REX].[ROL_USUARIO] (id_usuario,id_rol) VALUES (1,3);

---------------------------------------------------------------------------------------------------------------

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

-----------------------------------------------------------------------------------------------------------------

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

------------------------------------------------------------------------------------------------------------------

/*Creacion de Forma_pago*/
INSERT INTO [T_REX].[FORMA_PAGO] (tipo_pago_desc)
	(SELECT distinct Tipo_Pago_Desc
		FROM gd_esquema.Maestra
		Where Tipo_Pago_Desc is not null);
GO

-------------------------------------------------------------------------------------------------------------------

/*Creacion de Tarjeta*/
INSERT INTO [T_REX].[TARJETA] (nro_tarjeta,titular_tarjeta,banco_tarjeta,tipo_tarjeta)
	   VALUES('0000000000000000','No se tiene registro', 'No se tiene registro','No se tiene registro'
	   );
GO

---------------------------------------------------------------------------------------------------------------------

/*Migracion de Proveedor*/

-- Inserto en tabla temporal

SELECT 
	Provee_RS,
	Provee_Dom,
	Provee_Ciudad,
	Provee_Telefono,
	Provee_CUIT,
	Provee_Rubro
into #Temp_Proveedor
FROM [gd_esquema].[Maestra]
where Provee_RS  is not null
group by 
	Provee_RS,
	Provee_Dom,
	Provee_Ciudad,
	Provee_Telefono,
	Provee_CUIT,
	Provee_Rubro
;
GO


/* Insertar en Tabla domicilio*/

insert into [T_REX].[DOMICILIO] (
			direc_calle,
			direc_localidad )
(select  Provee_Dom,
		Provee_Ciudad
from #Temp_Proveedor
);


/*Insertar tabla usuario */
GO
insert into [T_REX].[USUARIO] (
			username,
			password )
(select  Provee_CUIT,
		'4f37c061f1854f9682f543fecb5ee9d652c803235970202de97c6e40c8361766' pass
	from #Temp_Proveedor
);
GO

-- NOTA: Los proveedores tienen "nombre usuario": CUIT y contraseña: "1234" para todos, luego cuando realicen el primer USUARIO deben cambiar la contraseña

/* Inserta Rol_Usuario*/

INSERT INTO [T_REX].[ROL_USUARIO] (id_usuario,id_rol) 
SELECT id_usuario,3
FROM [T_REX].[USUARIO]
where id_usuario not in (select id_usuario from [T_REX].[ROL_USUARIO])

/* Inserta Proveedor*/			

insert into [T_REX].[PROVEEDOR](
					provee_rs, 
					provee_cuit, 
					provee_telefono, 
					id_domicilio, 
					id_rubro, 
					id_usuario )
select	Provee_RS, 
		Provee_CUIT, 
		Provee_Telefono, 
		id_domicilio, 
		id_rubro, 
		id_usuario 
FROM #Temp_Proveedor t
inner join [T_REX].[USUARIO] u on u.username= t.Provee_CUIT 
inner join [T_REX].[RUBRO] r  on r.nombreDeRubro= t.Provee_Rubro
inner join [T_REX].[DOMICILIO] d on d.direc_calle= t.Provee_Dom
order by Provee_CUIT

DROP TABLE #Temp_Proveedor


----------------------------------------------------------------------------------------------------------------

/*Migracion cliente*/

--218 registros
-- Inserto tabla temporal

SELECT 
	Cli_Nombre,
	Cli_Apellido,
	Cli_Dni,
	Cli_Fecha_Nac,
	Cli_Mail,
	Cli_Telefono,
	Cli_Ciudad,
	Cli_Direccion
into #Temp_cliente
FROM [gd_esquema].[Maestra]
group by 
	Cli_Nombre,
	Cli_Apellido,
	Cli_Dni,
	Cli_Fecha_Nac,
	Cli_Mail,
	Cli_Telefono,
	Cli_Ciudad,
	Cli_Direccion


/* Insertar en Tabla domicilio los clientes*/

insert into [T_REX].[DOMICILIO] (direc_calle, direc_localidad )
select Cli_Direccion, Cli_Ciudad
from #Temp_cliente


/*Insertar tabla usuario los clientes */

insert into [T_REX].[USUARIO] ( username, password )
select  Cli_Dni, '4f37c061f1854f9682f543fecb5ee9d652c803235970202de97c6e40c8361766' pass
from #Temp_cliente

/* Inserte tabla rol_usuario */

INSERT INTO [T_REX].[ROL_USUARIO] (id_usuario,id_rol) 
SELECT id_usuario,2
FROM [T_REX].[USUARIO]
where id_usuario not in (select id_usuario from [T_REX].[ROL_USUARIO])


/*Insertar tabla cliente: antes de usuario y domicilio*/

--218 clientes (?

insert into [T_REX].[CLIENTE](
					nombre,apellido,
					nro_documento,
					fechaDeNacimiento,
					mail,telefono,
					creditoTotal,
					id_domicilio,
					id_usuario)
select a.Cli_Nombre,
		a.Cli_Apellido, 
		a.Cli_Dni,
		a.Cli_Fecha_Nac,
		a.Cli_Mail,
		a.Cli_Telefono,
		0,
		b.id_domicilio,
		c.id_usuario 
from #Temp_cliente a
inner join T_REX.DOMICILIO b on a.Cli_Direccion=b.direc_calle and a.Cli_Ciudad = b.direc_localidad 
inner join T_REX.USUARIO c on CAST(a.Cli_Dni  AS NVARCHAR(255))=c.username

DROP TABLE #Temp_cliente
-----------------------------------------------------------------------------------------------------------------------

/*Creacion de Credito, antes cargar tablas: cliente,forma_pago y tarjeta*/

INSERT INTO [T_REX].[CREDITO] (fecha_Credito, id_cliente, id_forma_pago,monto_credito,id_tarjeta)
SELECT a.Carga_Fecha,c.id_cliente,b.id_forma_pago, a.Carga_Credito,1
FROM gd_esquema.Maestra a
inner join T_REX.FORMA_PAGO b on a.Tipo_Pago_Desc = b.tipo_pago_desc
inner join T_REX.CLIENTE c on a.Cli_Dni=c.nro_documento
where a.Provee_RS is null


------------ USUARIO ----------

GO 

CREATE PROCEDURE [T_REX].LogearUsuario
@username nvarchar(255),
@password nvarchar(255),
@tipoUsuario nvarchar(255)
AS
BEGIN
	DECLARE @intentosFallidos INT
	DECLARE @intentosFaltantes INT
	IF(NOT EXISTS(SELECT u.id_usuario FROM [T_REX].USUARIO u WHERE u.username = @username))
	BEGIN
			RAISERROR('ERROR: USUARIO incorrecto, no existe ningun usuario con este username', 16, 1)
	END
	ELSE
		IF(@tipoUsuario = 'Cliente')
		BEGIN
			IF(EXISTS(SELECT 1 FROM [T_REX].USUARIO us JOIN [T_REX].CLIENTE cli ON (us.id_usuario = cli.id_usuario)
			WHERE us.username = @username AND us.estado = 0))
				RAISERROR('ERROR: Usuario %s bloqueado.',16,1,@username)
			ELSE IF(NOT EXISTS(SELECT us.id_usuario FROM [T_REX].USUARIO us WHERE us.username = @username AND us.password = @password))
			BEGIN
				SET @intentosFallidos = (SELECT us.intentos_login FROM [T_REX].USUARIO us WHERE us.username = @username) +1					
				UPDATE [T_REX].USUARIO SET intentos_login = @intentosFallidos WHERE username = @username
				SET @intentosFaltantes = 3-@intentosFallidos
				IF(@intentosFaltantes = 0)
					RAISERROR('ERROR: Supero el límite de intentos. Usuario bloqueado',16,1);
				ELSE
					RAISERROR ('ERROR: Loggin incorrecto para el usuario %s. Intentos restantes: %i.',16,1,@username,@intentosFaltantes)
			END	
			ELSE
			BEGIN
				BEGIN TRANSACTION
					UPDATE [T_REX].USUARIO SET intentos_login = 0 WHERE username = @username
					DECLARE @idUsuarioLoggeado INT
					SET @idUsuarioLoggeado = (SELECT id_usuario FROM [T_REX].USUARIO WHERE username = @username)
					UPDATE [T_REX].USUARIO set estado = 1 WHERE id_usuario = @idUsuarioLoggeado
				COMMIT TRANSACTION
			END				
		END	
		ELSE
		BEGIN
			IF(EXISTS(SELECT 1 FROM [T_REX].USUARIO us JOIN [T_REX].PROVEEDOR cli ON (us.id_usuario = cli.id_usuario)
			WHERE us.username = @username AND us.estado = 0))
				RAISERROR('ERROR: Usuario %s bloqueado.',16,1,@username)
			ELSE IF(NOT EXISTS(SELECT us.id_usuario FROM [T_REX].USUARIO us WHERE us.username = @username AND us.password = @password))
			BEGIN
				SET @intentosFallidos = (SELECT us.intentos_login FROM [T_REX].USUARIO us WHERE us.username = @username) +1					
				UPDATE [T_REX].USUARIO SET intentos_login = @intentosFallidos WHERE username = @username
				SET @intentosFaltantes = 3-@intentosFallidos
				IF(@intentosFaltantes = 0)
					RAISERROR('ERROR: Supero el límite de intentos. Usuario bloqueado',16,1);
				ELSE
					RAISERROR ('ERROR: Loggin incorrecto para el usuario %s. Intentos restantes: %i.',16,1,@username,@intentosFaltantes)
			END	
			ELSE
			BEGIN
				BEGIN TRANSACTION
					UPDATE [T_REX].USUARIO SET intentos_login = 0 WHERE username = @username
					DECLARE @idProvLoggeado INT
					SET @idProvLoggeado = (SELECT id_usuario FROM [T_REX].USUARIO WHERE username = @username)
					UPDATE [T_REX].USUARIO set estado = 1 WHERE id_usuario = @idProvLoggeado
				COMMIT TRANSACTION
			END				
		END	
 
END