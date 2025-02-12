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

--Tabla DOMICILIO

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


-- Tabla FUNCIONALIDAD

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

-- Tabla ROL

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
		nombre nvarchar (50) UNIQUE NOT NULL,
		estado bit NOT NULL DEFAULT 1
);
END

GO

--Tabla FUNCIONALIDAD_ROL

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

-- Tabla USUARIO

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
		username nvarchar (255) unique NOT NULL,
		password nvarchar (255) NOT NULL,
		intentos_login int NOT NULL DEFAULT (0),
		estado bit NOT NULL DEFAULT 1
);
END
GO

-- Tabla ROL_USUARIO

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

-- Tabla RUBRO

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

-- Tabla PROVEEDOR

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

-- Tabla CLIENTE

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
		email nvarchar (150) NOT NULL,
		telefono int NOT NULL,
		baja_logica bit NOT NULL DEFAULT 1,
		estado bit NOT NULL DEFAULT 1,
		creditoTotal decimal (18,0) NOT NULL,
		id_domicilio int FOREIGN KEY REFERENCES [T_REX].DOMICILIO(id_domicilio) NOT NULL,
		id_usuario int FOREIGN KEY REFERENCES [T_REX].USUARIO(id_usuario) NOT NULL,
		CONSTRAINT [UNIQUE_DNI] UNIQUE NONCLUSTERED ([nro_documento], [tipo_documento])
);
END
GO

-- Tabla OFERTA

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
		cod_oferta nvarchar (60) NULL,
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

-- Tabla COMPRA

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
		compra_fecha datetime2(3) NOT NULL,
		id_oferta int FOREIGN KEY REFERENCES [T_REX].OFERTA(id_oferta) NOT NULL,
		id_cliente int FOREIGN KEY REFERENCES [T_REX].CLIENTE(id_cliente) NOT NULL,
		cantidad decimal (15,0) NOT NULL,
		facturado bit NOT NULL DEFAULT 0
);
END
GO

-- Tabla TARJETA

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

-- Tabla FORMA_PAGO

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

-- Tabla CREDITO

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

-- Tabla FACTURA_PROVEEDOR

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
		tipo_factura char(15) default 'No definido',
		importe_fact decimal (20,2) NOT NULL,
		fecha_inicio datetime2 (3) NOT NULL,
		fecha_fin datetime2 (3) NOT NULL,
		id_proveedor int FOREIGN KEY REFERENCES [T_REX].PROVEEDOR(id_proveedor) NOT NULL
);
END
GO

-- Tabla ITEM_FACTURA

IF NOT EXISTS (
		SELECT 1
		FROM INFORMATION_SCHEMA.TABLES
		WHERE TABLE_TYPE = 'BASE TABLE'
		AND TABLE_NAME = 'ITEM_FACTURA'
		AND TABLE_SCHEMA = 'T_REX'
)
BEGIN
CREATE TABLE [T_REX].[ITEM_FACTURA] (
		id_itemFactura int IDENTITY(1,1) PRIMARY KEY NOT NULL,
		importe_oferta decimal (20,2) NOT NULL,
		cantidad decimal (15,0) NOT NULL,
		id_factura int FOREIGN KEY REFERENCES [T_REX].FACTURA_PROVEEDOR(id_factura) NOT NULL,
		id_oferta int FOREIGN KEY REFERENCES [T_REX].[OFERTA](id_oferta) NOT NULL
);
END
GO

-- Tabla CUPON

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
		cupon_codigo nvarchar(60) DEFAULT NULL,
		cupon_fecha_deconsumo datetime2(3)  NULL,
		cupon_precio_oferta decimal (20,2) NOT NULL,
		cupon_precio_lista decimal (20,2) NOT NULL,
		id_consumidor int FOREIGN KEY REFERENCES [T_REX].CLIENTE(id_cliente) NULL,
		cupon_estado bit NOT NULL DEFAULT 1,
		id_compra int FOREIGN KEY REFERENCES [T_REX].COMPRA(id_compra) NOT NULL,
		id_oferta int FOREIGN KEY REFERENCES [T_REX].[OFERTA](id_oferta) NOT NULL
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

-- Comestibles, electronica, Hoteleria 

-------------------------------------------------------------------------------------------------------------

/*Creacion de Roles*/

INSERT INTO [T_REX].[ROL](nombre) VALUES ('Administrativo'); --1
INSERT INTO [T_REX].[ROL](nombre) VALUES ('Cliente');	--2
INSERT INTO [T_REX].[ROL](nombre) VALUES ('Proveedor');	--3

--------------------------------------------------------------------------------------------------------------

/*Creacion de usuario Admin */

INSERT INTO [T_REX].[USUARIO] (username,password)
--user :admin pass: t12r
VALUES ('admin', CONVERT(varchar(64), HASHBYTES('SHA2_256', 'w23e'), 2));

--select HASHBYTES('SHA2_256', 'w23e')	contrase�a del admin
--select HASHBYTES('SHA2_256', '1234') contrase�a para usuarios y proveedores

--select CONVERT(varchar(64), HASHBYTES('SHA2_256', 'w23e'))

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
INSERT INTO [T_REX].[FUNCIONALIDAD] (descripcion) VALUES ('ABM Usuario');  --10

-----------------------------------------------------------------------------------------------------------------

/*Creacion de Funcionalidad_Rol*/

INSERT INTO [T_REX].[FUNCIONALIDAD_ROL] (id_rol,id_funcionalidad) VALUES (1,10);-- Admin ABM Usuario
INSERT INTO [T_REX].[FUNCIONALIDAD_ROL] (id_rol,id_funcionalidad) VALUES (1,1);	-- Admin ABM ROL -
INSERT INTO [T_REX].[FUNCIONALIDAD_ROL] (id_rol,id_funcionalidad) VALUES (1,2);	-- Admin ABM CLIENTES - 
INSERT INTO [T_REX].[FUNCIONALIDAD_ROL] (id_rol,id_funcionalidad) VALUES (1,3); --	Admin ABM PROVEEDOR -
INSERT INTO [T_REX].[FUNCIONALIDAD_ROL] (id_rol,id_funcionalidad) VALUES (1,8);	-- Admin  FACTURACION PROVEEDOR -
INSERT INTO [T_REX].[FUNCIONALIDAD_ROL] (id_rol,id_funcionalidad) VALUES (1,9);	-- Admin LISTADO ESTADISTICO -
INSERT INTO [T_REX].[FUNCIONALIDAD_ROL] (id_rol,id_funcionalidad) VALUES (1,6);	-- Admin PUBLICAR OFERTA
INSERT INTO [T_REX].[FUNCIONALIDAD_ROL] (id_rol,id_funcionalidad) VALUES (2,4);	-- Cliente CARGAR CREDITO -
INSERT INTO [T_REX].[FUNCIONALIDAD_ROL] (id_rol,id_funcionalidad) VALUES (2,5);	-- Cliente COMPRAR OFERTA -
INSERT INTO [T_REX].[FUNCIONALIDAD_ROL] (id_rol,id_funcionalidad) VALUES (3,7);	-- Proveedor CONSUMO DE OFERTA -
INSERT INTO [T_REX].[FUNCIONALIDAD_ROL] (id_rol,id_funcionalidad) VALUES (3,6);	-- Proveedor CREAR OFERTA -

------------------------------------------------------------------------------------------------------------------

/*Creacion de Forma_pago*/

INSERT INTO [T_REX].[FORMA_PAGO] (tipo_pago_desc)
SELECT distinct LOWER(Tipo_Pago_Desc)
FROM gd_esquema.Maestra
Where Tipo_Pago_Desc is not null

/* agrego forma de pago debido*/
INSERT INTO [T_REX].[FORMA_PAGO] (tipo_pago_desc) VALUES('d�bito')


-------------------------------------------------------------------------------------------------------------------

/*Creacion de Tarjeta*/

INSERT INTO [T_REX].[TARJETA] (nro_tarjeta,titular_tarjeta,banco_tarjeta,tipo_tarjeta)
VALUES('0000000000000000','No se tiene registro', 'No se tiene registro','No se tiene registro')

---------------------------------------------------------------------------------------------------------------------

/*Migracion de Proveedor*/

-- 37 PROVEEDORES

-- Inserto en tabla temporal
IF OBJECT_ID('tempdb.dbo.#Temp_Proveedor', 'U') IS NOT NULL
  DROP TABLE #Temp_Proveedor;

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

/* Insertar en Tabla domicilio*/

insert into [T_REX].[DOMICILIO] (direc_calle, direc_localidad )
select  Provee_Dom,Provee_Ciudad
from #Temp_Proveedor


/*Insertar tabla usuario */

insert into [T_REX].[USUARIO] ( username, password )
select  Provee_CUIT, CONVERT(varchar(64), HASHBYTES('SHA2_256', '1234'), 2) pass
from #Temp_Proveedor

-- NOTA: Los proveedores tienen "nombre usuario": CUIT y contrase�a: "1234" para todos, luego cuando realicen el primer logueo deben cambiar la contrase�a


/* Inserta Rol_Usuario*/

INSERT INTO [T_REX].[ROL_USUARIO] (id_usuario,id_rol) 
SELECT id_usuario,3
FROM [T_REX].[USUARIO]
where id_usuario not in (select id_usuario from [T_REX].[ROL_USUARIO])

/* Inserta Proveedor*/			

INSERT INTO [T_REX].[PROVEEDOR](
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
/*Migracion de clientes*/

--218 clientes

-- Inserto en tabla temporal
IF OBJECT_ID('tempdb.dbo.#Temp_cliente', 'U') IS NOT NULL
  DROP TABLE #Temp_cliente;

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

-- Se busca inconsistencias en los datos con otra tabla temporal
IF OBJECT_ID('tempdb.dbo.#Temp_cliente_incons', 'U') IS NOT NULL
  DROP TABLE #Temp_cliente_incons;

SELECT 
	Cli_Nombre,
	Cli_Apellido,
	Cli_Dni,
	Cli_Fecha_Nac,
	Cli_Mail,
	Cli_Telefono,
	Cli_Ciudad,
	Cli_Direccion,
	row_number() OVER(PARTITION BY [Cli_Dni] ORDER BY [Cli_Mail]) AS cantDni,
	row_number() OVER(PARTITION BY [Cli_Mail] ORDER BY [Cli_Mail]) AS cantEmail
into #Temp_cliente_incons
FROM #Temp_cliente
group by 
	Cli_Nombre,
	Cli_Apellido,
	Cli_Dni,
	Cli_Fecha_Nac,
	Cli_Mail,
	Cli_Telefono,
	Cli_Ciudad,
	Cli_Direccion


DROP TABLE #Temp_cliente;


-- Insertar en tabla Domicilio

insert into [T_REX].[DOMICILIO] (direc_calle, direc_localidad )
select Cli_Direccion, Cli_Ciudad
from #Temp_cliente_incons


--Insertar en tabla usuario los clientes que tienen datos correctos

INSERT INTO [T_REX].[USUARIO] ( username, password, intentos_login, estado )
select  Cli_Dni, CONVERT(varchar(64), HASHBYTES('SHA2_256', '1234'), 2) pass, 0, 1
from #Temp_cliente_incons
where cantDni=1 and cantEmail=1



--Insertar en tabla cliente con datos unicos
 
INSERT INTO [T_REX].[CLIENTE](
					nombre,
					apellido,
					nro_documento,
					fechaDeNacimiento,
					email,
					telefono,
					creditoTotal,
					id_domicilio,
					id_usuario)
select a.Cli_Nombre,
		a.Cli_Apellido, 
		a.Cli_Dni,
		a.Cli_Fecha_Nac,
		a.Cli_Mail,
		a.Cli_Telefono,
		isnull(((select sum(isnull(d.Carga_Credito,0)) from gd_esquema.Maestra d
		where d.Cli_Dni=a.Cli_Dni and d.Carga_Credito is not null)-
		(select sum(isnull(e.Oferta_Precio,0)) from gd_esquema.Maestra e 
		where e.Cli_Dni=a.Cli_Dni
		and e.Factura_Nro is null
		and e.Oferta_Entregado_Fecha is null)),0),
		b.id_domicilio,
		c.id_usuario 
from #Temp_cliente_incons a
inner join T_REX.DOMICILIO b on a.Cli_Direccion=b.direc_calle and a.Cli_Ciudad = b.direc_localidad 
inner join T_REX.USUARIO c on CAST(a.Cli_Dni  AS NVARCHAR(255))=c.username
where cantDni=1 and cantEmail=1
order by a.Cli_Dni


--Inserto en tabla usuarios los clientes con datos duplicados

INSERT INTO [T_REX].[USUARIO] ( username, password, intentos_login, estado )
select  Cli_Dni, CONVERT(varchar(64), HASHBYTES('SHA2_256', '1234'), 2) pass, 0, 0
from #Temp_cliente_incons
where cantDni=1 and cantEmail >1

--El n�mero 0 es FALSE, y el 1  es TRUE.


-- Inserto en tabla rol_usuario 

INSERT INTO [T_REX].[ROL_USUARIO] (id_usuario,id_rol) 
SELECT id_usuario,2
FROM [T_REX].[USUARIO]
where id_usuario not in (select id_usuario from [T_REX].[ROL_USUARIO])


-- Inserto en tabla clientes los usuarios con datos repetidos ( dos mails iguales con distinto dni)

INSERT INTO [T_REX].[CLIENTE](
					nombre,
					apellido,
					nro_documento,
					fechaDeNacimiento,
					email,
					telefono,
					creditoTotal,
					baja_logica,
					estado,
					id_domicilio,
					id_usuario)
select a.Cli_Nombre,
		a.Cli_Apellido, 
		a.Cli_Dni,
		a.Cli_Fecha_Nac,
		a.Cli_Mail,
		a.Cli_Telefono,
		isnull(((select sum(isnull(d.Carga_Credito,0)) from gd_esquema.Maestra d
		where d.Cli_Dni=a.Cli_Dni and d.Carga_Credito is not null)-
		(select sum(isnull(e.Oferta_Precio,0)) from gd_esquema.Maestra e 
		where e.Cli_Dni=a.Cli_Dni
		and e.Factura_Nro is null
		and e.Oferta_Entregado_Fecha is null)),0),
		0,
		0,
		b.id_domicilio,
		c.id_usuario 
from #Temp_cliente_incons a
inner join T_REX.DOMICILIO b on a.Cli_Direccion=b.direc_calle and a.Cli_Ciudad = b.direc_localidad 
inner join T_REX.USUARIO c on CAST(a.Cli_Dni  AS NVARCHAR(255))=c.username
where cantDni=1 and cantEmail>1
order by a.Cli_Dni


DROP TABLE #Temp_cliente_incons

-----------------------------------------------------------------------------------------------------------------------

/*Creacion de Credito, antes cargar tablas: cliente,forma_pago y tarjeta*/

-- 93679 registros

INSERT INTO [T_REX].[CREDITO] (fecha_Credito, 
								id_cliente, 
								id_forma_pago,
								monto_credito,
								id_tarjeta)
SELECT	a.Carga_Fecha,
		c.id_cliente,
		b.id_forma_pago, 
		a.Carga_Credito,
		1
FROM gd_esquema.Maestra a
inner join T_REX.FORMA_PAGO b on a.Tipo_Pago_Desc = b.tipo_pago_desc
inner join T_REX.CLIENTE c on a.Cli_Dni=c.nro_documento
where  Carga_Credito is not null
group by a.Carga_Fecha, c.id_cliente, b.id_forma_pago, a.Carga_Credito
order by 1,4

----------------------------------------------------------------------------------------------------------------

/*Migracion oferta*/

--84262 registros

-- Inseto tabla temporal datos de ofertas
IF OBJECT_ID('tempdb.dbo.#TEMP_Oferta', 'U') IS NOT NULL
  DROP TABLE #TEMP_Oferta;

select	a.Oferta_Codigo,
		a.Oferta_Descripcion,
		a.Oferta_Fecha,
		a.Oferta_Fecha_Venc,
		a.Oferta_Precio,
		a.Oferta_Precio_Ficticio,
		a.Oferta_Cantidad,
		a.Provee_RS
into #TEMP_Oferta
from [gd_esquema].[Maestra] a
where Oferta_Codigo is not null
group by a.Oferta_Codigo,
		a.Oferta_Descripcion,
		a.Oferta_Fecha,
		a.Oferta_Fecha_Venc,
		a.Oferta_Precio,
		a.Oferta_Precio_Ficticio,
		a.Oferta_Cantidad,
		a.Provee_RS
order by 1,3


-- Inserto en tabla OFERTAS

insert into [T_REX].[OFERTA](
					cod_oferta,
					descripcion,
					fecha_inicio,
					fecha_fin,
					precio_oferta,
					precio_lista,
					cantDisponible,
					cant_max_porCliente,
					id_proveedor)
select	a.Oferta_Codigo,
		a.Oferta_Descripcion,
		a.Oferta_Fecha,
		a.Oferta_Fecha_Venc,
		a.Oferta_Precio,
		a.Oferta_Precio_Ficticio,
		a.Oferta_Cantidad,
		a.Oferta_Cantidad,
		b.id_proveedor
from #TEMP_Oferta a
inner join T_REX.PROVEEDOR b on b.provee_rs= a.Provee_RS 
group by Oferta_Codigo,
		Oferta_Descripcion,
		Oferta_Fecha,
		Oferta_Fecha_Venc,
		Oferta_Precio,
		Oferta_Precio_Ficticio,
		Oferta_Cantidad,
		b.id_proveedor
order by 1, 3

drop table #TEMP_Oferta

----------------------------------------------------------------------------------------------------------------

/*Migracion compra*/ -- advertencia valor null

--119678 registros

insert into [T_REX].[COMPRA] (
		compra_fecha,
		id_cliente,
		id_oferta,
		cantidad)
select Oferta_Fecha_Compra, 
	(select id_cliente from T_REX.CLIENTE where nro_documento= Cli_Dni), 
	(select id_oferta from T_REX.OFERTA where cod_oferta=Oferta_Codigo), 
	count(*) 
from gd_esquema.Maestra 
where Oferta_Entregado_Fecha is null 
	and Oferta_Codigo is not NULL
	and Factura_Nro is null  
	and Factura_Fecha is null
group by Cli_Dni, Oferta_Codigo, Oferta_Fecha_Compra
order by Oferta_Fecha_Compra asc, Oferta_Codigo;

----------------------------------------------------------------------------------------------------------------
/*Migracion cupon*/

--119678 registros
insert into [T_REX].[CUPON] (

		cupon_codigo,
		cupon_fecha_deconsumo,
		cupon_precio_oferta,
		cupon_precio_lista,
		id_consumidor,
		cupon_estado,
		id_compra,
		id_oferta
)
select 
Oferta_codigo cupon_codigo,
max(Oferta_Entregado_Fecha),
Oferta_Precio,
Oferta_Precio_Ficticio,
CASE WHEN max(Oferta_Entregado_Fecha) IS NOT NULL
    THEN (select id_cliente from [T_REX].CLIENTE where nro_documento= Cli_Dni)
    ELSE NULL
END id_cliente,
CASE WHEN max(Oferta_Entregado_Fecha) IS NOT NULL
    THEN 0
    ELSE 1
END,
(select c.id_compra 
	from T_REX.COMPRA c
	inner join T_REX.OFERTA o on c.id_oferta = o.id_oferta
	inner join T_REX.CLIENTE cli on c.id_cliente=cli.id_cliente
	where o.cod_oferta=Oferta_Codigo
	and cli.nro_documento=Cli_Dni
	and c.compra_fecha=Oferta_Fecha_Compra), 
(select id_oferta from [T_REX].OFERTA where cod_oferta=Oferta_Codigo)
from gd_esquema.Maestra a
where Factura_Nro is null  
and Factura_Fecha is null
and Oferta_Codigo is not NULL
group by Cli_Dni, Oferta_Codigo, Oferta_Fecha_Compra,Oferta_Precio_Ficticio, Oferta_Precio
order by Oferta_Fecha_Compra asc, Oferta_Codigo;

----------------------------------------------------------------------------------------------------------------
/*Migracion Factura Proveedor*/
--481
insert into [T_REX].[FACTURA_PROVEEDOR] (
		nro_factura,
		importe_fact,
		fecha_inicio,
		fecha_fin,
		id_proveedor)
select a.Factura_Nro, 
	sum(isnull(a.Oferta_Precio,0)),
	a.Factura_Fecha,
	a.Factura_Fecha,
		id_proveedor
from gd_esquema.Maestra a
inner join T_REX.PROVEEDOR b on a.Provee_CUIT=b.provee_cuit and a.Provee_RS=b.provee_rs
where a.Oferta_Codigo is not NULL
and a.Factura_Nro is not null  
and a.Factura_Fecha is not null
group by a.Factura_Nro,a.Factura_Fecha,id_proveedor
order by Factura_Nro;

----------------------------------------------------------------------------------------------------------------
/*Migracion Item Factura*/
--66644

insert into [T_REX].[ITEM_FACTURA] (
		importe_oferta,
		cantidad,
		id_factura,
		id_oferta)
select sum(isnull(a.Oferta_Precio,0)),
		isnull(count(*),0),
		c.id_factura,
		(select id_oferta from T_REX.OFERTA b where b.cod_oferta=a.Oferta_Codigo)
from gd_esquema.Maestra a
inner join T_REX.FACTURA_PROVEEDOR c on c.nro_factura=a.Factura_Nro
where a.Oferta_Codigo is not NULL
and a.Factura_Nro is not null  
and a.Factura_Fecha is not null
group by a.Oferta_Codigo, c.id_factura, a.Factura_Nro
order by a.Factura_Nro;


/*##########################################################################################################
											SPs 													
##########################################################################################################*/

--//---------- USUARIO ----------//

--exec [T_REX].LogearUsuario '88430112', '1234', 'Proveedor';
GO
IF OBJECT_ID('T_REX.LogearUsuario') IS NOT NULL
	DROP PROCEDURE [T_REX].LogearUsuario;
GO
CREATE PROCEDURE [T_REX].LogearUsuario
@username nvarchar(255),
@password varchar(255),
@tipoUsuario nvarchar(255)
AS
BEGIN
	DECLARE @intentosFallidos INT
	DECLARE @intentosFaltantes INT

	IF(NOT EXISTS(SELECT u.id_usuario FROM [T_REX].USUARIO u WHERE u.username = @username))
	BEGIN	
		RAISERROR('ERROR: USUARIO incorrecto, no existe ningun usuario con este username', 16, 1)
		return
	END
	
	IF(EXISTS(SELECT 1 FROM [T_REX].USUARIO us 
		inner join  [T_REX].ROL_USUARIO ru on us.id_usuario=ru.id_usuario
		inner join T_REX.ROL r on ru.id_rol=r.id_rol
		where us.username=@username and r.nombre='Administrativo')  AND @tipoUsuario != 'Administrativo')
	BEGIN
		RAISERROR('ERROR: No existe usuario para ese rol', 16, 1)
		return
	END

	IF(NOT EXISTS(SELECT 1 FROM [T_REX].USUARIO us 
		inner join  [T_REX].ROL_USUARIO ru on us.id_usuario=ru.id_usuario
		inner join T_REX.ROL r on ru.id_rol=r.id_rol
		where us.username=@username and r.nombre=@tipoUsuario))
	BEGIN
		RAISERROR('ERROR: No existe usuario para ese rol', 16, 1)
		return
	END

	IF(EXISTS(SELECT 1 FROM [T_REX].USUARIO us WHERE us.username = @username AND us.estado = 0))
	BEGIN
		RAISERROR('ERROR: Usuario %s bloqueado.',16,1,@username)
	END
	ELSE
	BEGIN 
		IF(NOT EXISTS(SELECT us.id_usuario FROM [T_REX].USUARIO us WHERE us.username = @username AND us.password = convert(varchar(64), HashBytes('SHA2_256', @password), 2)))
		BEGIN				
			SET @intentosFallidos = (SELECT us.intentos_login FROM [T_REX].USUARIO us WHERE us.username = @username) +1					
			UPDATE [T_REX].USUARIO SET intentos_login = @intentosFallidos WHERE username = @username
			SET @intentosFaltantes = 3-@intentosFallidos
			IF(@intentosFaltantes <= 0)
			BEGIN
				UPDATE [T_REX].USUARIO SET estado = 0 WHERE username = @username
				RAISERROR('ERROR: Supero el l�mite de intentos. Usuario bloqueado',16,1);
			END
			ELSE
			BEGIN
				RAISERROR ('ERROR: Contrase�a incorrecta para el usuario %s. Intentos restantes: %i.',16,1,@username,@intentosFaltantes)
			END	
		END
		ELSE
		begin
		BEGIN TRANSACTION
			UPDATE [T_REX].USUARIO SET intentos_login = 0 WHERE username = @username
			DECLARE @idUsuarioLoggeado INT
			SET @idUsuarioLoggeado = (SELECT id_usuario FROM [T_REX].USUARIO WHERE username = @username)
			UPDATE [T_REX].USUARIO set estado = 1 WHERE id_usuario = @idUsuarioLoggeado
			COMMIT TRANSACTION
		END			
	END		
END	
GO

IF OBJECT_ID('T_REX.ValidarContrasenia') IS NOT NULL
    DROP PROCEDURE T_REX.ValidarContrasenia
GO

CREATE PROCEDURE T_REX.ValidarContrasenia
@Username varchar(255),
@Password varchar(255),
@out bit OUTPUT
AS
BEGIN
	IF(EXISTS(SELECT 1 FROM [T_REX].USUARIO us WHERE us.username = @Username AND us.password = convert(varchar(64), HashBytes('SHA2_256', @Password), 2)))
	BEGIN
		SET @out=1
	END
	ELSE
	BEGIN
		SET @out=0
	END
END

GO

-- BAJA USUARIO // T_REX.BajaUsuario

IF OBJECT_ID('T_REX.BajaUsuario') IS NOT NULL
    DROP PROCEDURE T_REX.BajaUsuario
GO

CREATE PROCEDURE T_REX.BajaUsuario
@IdUsuario int
AS
BEGIN
	UPDATE [T_REX].Usuario
	SET estado='0'
	where id_usuario=@IdUsuario
END

GO

-- HABILITAR USUARIO // [T_REX].HabilitarUsuario

IF OBJECT_ID('T_REX.HabilitarUsuario') IS NOT NULL
    DROP PROCEDURE [T_REX].HabilitarUsuario
GO

CREATE PROCEDURE [T_REX].HabilitarUsuario
@IdUsuario int
as
	update [T_REX].USUARIO
	set estado = '1'
	where id_usuario=@IdUsuario

go

-- AGREGAR ROL A USUARIO // [T_REX].AgregarRolUsuario

IF OBJECT_ID('T_REX.AgregarRolUsuario') IS NOT NULL
	DROP PROCEDURE [T_REX].AgregarRolUsuario;
GO
CREATE PROCEDURE [T_REX].AgregarRolUsuario
	@IdUsuario int,
	@IdRol int
AS
BEGIN
	INSERT INTO [T_REX].ROL_USUARIO (id_usuario, id_rol, activo)
	VALUES (@idUsuario, @IdRol, '1');
END
GO

-- ALTA USUARIO 

IF OBJECT_ID('T_REX.AltaUsuario') IS NOT NULL
	DROP PROCEDURE [T_REX].AltaUsuario;
GO
CREATE PROCEDURE [T_REX].AltaUsuario
	
	@IdUsuario int= NULL,
	@Password  varchar (255),
	@Nombre nvarchar (255),
	@Accion varchar(1),
	@out varchar(1000) OUTPUT
AS

BEGIN
	
	begin try
		declare @idDomicilio int, @id_usuario int;

	if(@Accion = 'A')

		begin
			if(@Password is null)
			begin
				RAISERROR('Tiene que elegir una password.',16 ,1)
				return
			end
			
			if(@Nombre is null)
			begin
				RAISERROR('Tiene que elegir una nombre de usuario.',16 ,1)
				return
			end

			begin TRANSACTION [T]
				if(EXISTS(select 1 from T_REX.USUARIO where username=@Nombre))
				begin
					RAISERROR('El USUARIO ya existe',16 ,1)
					return
				end
				else
				begin
					insert into T_REX.USUARIO(username, password, intentos_login, estado) 
					values (@Nombre, CONVERT(varchar(64), HASHBYTES('SHA2_256', @Password), 2), '0', '1');
				end

			commit TRANSACTION [T]
		end
	
	else if (@Accion = 'M')

		begin
			begin TRANSACTION [T]
					
					select @IdUsuario=id_usuario from T_REX.USUARIO where id_usuario=@IdUsuario
					if(@@ROWCOUNT = 0) 
					begin
						RAISERROR('Usuario Inexistente',16 ,1);
						return
					end

											
					if(@Password is null)
					begin
						update T_REX.USUARIO
						set username = @Nombre
						where id_usuario= @IdUsuario
					end
					else
					begin
						update T_REX.USUARIO
						set username = @Nombre,
							password = CONVERT(varchar(64), HASHBYTES('SHA2_256', @Password), 2)
						Where id_usuario= @IdUsuario
					end
					
			commit TRANSACTION [T]
		end

	end try
	begin catch
		ROLLBACK TRANSACTION [T]
		set @out = ERROR_MESSAGE();
	end catch

END

-- CAMBIAR CONTRASE�A
GO
IF OBJECT_ID('T_REX.CambiarContrasenia') IS NOT NULL
	DROP PROCEDURE [T_REX].CambiarContrasenia;
GO
CREATE PROCEDURE [T_REX].CambiarContrasenia
	@IdUsuario int,
	@Pass varchar(255),
	@NewPass varchar(255)
AS
BEGIN
	IF(EXISTS(SELECT 1 FROM [T_REX].USUARIO us WHERE us.id_usuario = @IdUsuario AND us.password = convert(varchar(64), HashBytes('SHA2_256', @Pass), 2)))
	BEGIN
		UPDATE [T_REX].USUARIO SET password = CONVERT(varchar(64), HASHBYTES('SHA2_256', @NewPass), 2) WHERE id_usuario = @IdUsuario
	END
	ELSE
	BEGIN
		RAISERROR('ERROR: Contrase�a incorrecta.', 16, 1)
	END			
END
GO

-- CAMBIAR CONTRASE�A MODO ADMIN

IF OBJECT_ID('T_REX.CambiarContraseniaModoAdmin') IS NOT NULL
	DROP PROCEDURE [T_REX].CambiarContraseniaModoAdmin;
GO
CREATE PROCEDURE [T_REX].CambiarContraseniaModoAdmin
	@IdUsuario int,
	@Pass varchar(255)
AS
BEGIN
	IF(EXISTS(	SELECT 1 FROM [T_REX].USUARIO us WHERE us.id_usuario = @IdUsuario )	)
	BEGIN
		UPDATE [T_REX].USUARIO 
		SET password = CONVERT(varchar(64), HASHBYTES('SHA2_256', @Pass), 2) 
		WHERE id_usuario = @IdUsuario
	END
	ELSE
	BEGIN
		RAISERROR('ERROR: Usuario incorrecto', 16, 1)
	END			
END
GO

-- CAMBIAR USERNAME MODO ADMIN

IF OBJECT_ID('T_REX.CambiarUsernameModoAdmin') IS NOT NULL
	DROP PROCEDURE [T_REX].CambiarUsernameModoAdmin;
GO
CREATE PROCEDURE [T_REX].CambiarUsernameModoAdmin
	@IdUsuario int,
	@Nombre varchar(255)
AS
BEGIN
	IF(EXISTS(	SELECT 1 FROM [T_REX].USUARIO us WHERE us.id_usuario = @IdUsuario )	)
	BEGIN
		UPDATE [T_REX].USUARIO 
		SET username = @Nombre
		WHERE id_usuario = @IdUsuario
	END
	ELSE
	BEGIN
		RAISERROR('ERROR: Usuario incorrecto', 16, 1)
	END			
END
GO


--//---------- ROL ----------//


--- AGREGAR FUNCIONALIDAD AL ROL / [T_REX].AgregarfuncionalidadRol

IF OBJECT_ID('T_REX.AgregarfuncionalidadRol') IS NOT NULL
    DROP PROCEDURE [T_REX].AgregarfuncionalidadRol
GO

CREATE PROCEDURE [T_REX].AgregarfuncionalidadRol
@rol_id int, 
@funcionalidad int
as
	declare @resultado varchar(10);

	if not exists (select 1 from [T_REX].FUNCIONALIDAD_ROL where id_rol=@rol_id and id_funcionalidad=@funcionalidad)
		begin
			insert into [T_REX].FUNCIONALIDAD_ROL (id_rol,id_funcionalidad)
			values (@rol_id,@funcionalidad);

			set @resultado='OK';
		end
	else
		begin
		if exists (select 1 from [T_REX].FUNCIONALIDAD_ROL  where id_rol=@rol_id and id_funcionalidad=@funcionalidad)
			begin
				update [T_REX].FUNCIONALIDAD_ROL
				set estado = '1'
				where id_rol=@rol_id 
				and id_funcionalidad=@funcionalidad;

				set @resultado='OK';
			end
		else set @resultado='ERROR';
		end
	
	select @resultado;
GO

-- Quitar funcionalidad a un rol // [T_REX].QuitarFuncionalidadRol

IF OBJECT_ID('T_REX.QuitarFuncionalidadRol') IS NOT NULL
    DROP PROCEDURE [T_REX].QuitarFuncionalidadRol
GO

CREATE PROCEDURE [T_REX].QuitarFuncionalidadRol
@rol_id int, 
@funcionalidad int
as
	if exists (select 1 from [T_REX].FUNCIONALIDAD_ROL where id_rol=@rol_id and id_funcionalidad=@funcionalidad and estado='1')
	begin
		update [T_REX].FUNCIONALIDAD_ROL 
		set estado = '0'
		where id_funcionalidad=@funcionalidad and id_rol=@rol_id;
	end
GO

-- Baja logica tabla Rol_Usuario y tabla Rol - [T_REX].SP_Inhabilitar_Rol

IF OBJECT_ID('T_REX.InhabilitarRol') IS NOT NULL
    DROP PROCEDURE [T_REX].InhabilitarRol
GO

CREATE PROCEDURE [T_REX].InhabilitarRol 
@rol_id int
AS
	
	begin
		update [T_REX].ROL_USUARIO 
		set activo='0'
		where [id_rol]=@rol_id;

		update [T_REX].ROL
		set estado='0'
		where [id_rol]=@rol_id;

	end


GO

-- ACTIVAR ROL // T_REX.ActivarRol

IF OBJECT_ID('T_REX.ActivarRol') IS NOT NULL
    DROP PROCEDURE T_REX.ActivarRol
GO

CREATE PROCEDURE [T_REX].ActivarRol  
@rol_id int
as
	update [T_REX].ROL
	set estado = '1'
	where id_rol=@rol_id

	update [T_REX].ROL_USUARIO 
		set activo='1'
		where [id_rol]=@rol_id;
go

-- CAMBIAR NOMBRE ROL // T_REX.CambiarNombreRol

IF OBJECT_ID('T_REX.CambiarNombreRol') IS NOT NULL
    DROP PROCEDURE T_REX.CambiarNombreRol
GO


CREATE PROCEDURE T_REX.CambiarNombreRol
@rol_id int,
@nombre varchar(50)

AS 
BEGIN
	UPDATE T_REX.ROL
	SET nombre=@nombre
	WHERE id_rol=@rol_id

END
GO

-- ALTA ROL // T_REX.AltaRol

IF OBJECT_ID('T_REX.AltaRol') IS NOT NULL
    DROP PROCEDURE T_REX.AltaRol
GO


CREATE PROCEDURE T_REX.AltaRol
	@nombre_rol varchar(50),
	@activo bit 
AS
BEGIN
	INSERT INTO T_REX.ROL (nombre, estado)
	VALUES (@nombre_rol,@activo)
	
END
GO


--//---------- CLIENTE ----------//

IF OBJECT_ID('T_REX.AbmUsuario') IS NOT NULL
	DROP PROCEDURE [T_REX].AbmUsuario;
GO
CREATE PROCEDURE [T_REX].AbmUsuario

	
	@Nombre nvarchar(150),
	@Apellido nvarchar(150),
	@TipoDocumento nvarchar(20),
	@Documento decimal(18,0),
	@FechaNacimiento datetime2(3),
	@Mail nvarchar(150),
	@Telefono int,
	@Domicilio nvarchar(100),
	@NroPiso nvarchar(100),
	@NroDpto nvarchar(50),
	@Localidad nvarchar(255),
	@CodigoPostal nvarchar(50),
	@user nvarchar(255),
	@pass varchar(255) = NULL,
	@Accion varchar(1),
	@out varchar(1000) OUTPUT,
	@IdCliente int = NULL
AS

BEGIN
	
	begin try
		declare @idDomicilio int, @id_usuario int;
	if(@Accion = 'A')

		begin
			if(@pass is null)
			begin
				RAISERROR('Tiene que elegir una password.',16 ,1)
				return
			end
			declare @creditoInicial int=200, @id_cliente int, @fechaDeEntrada datetime2(3);
			begin TRANSACTION [T]

				insert into T_REX.USUARIO(username, password) values (@user, CONVERT(varchar(64), HASHBYTES('SHA2_256', @pass), 2));
				select @id_usuario=id_usuario from T_REX.USUARIO where username=@user;
				if(@@ROWCOUNT = 0) 
				begin
					RAISERROR('Usuario Inexistente',16 ,1)
					return
				end
				insert into T_REX.ROL_USUARIO(id_usuario,id_rol) VALUES (@id_usuario,2);

				insert into T_REX.DOMICILIO(direc_calle,direc_nro_piso,direc_localidad,codigoPostal,direc_nro_depto)
				values(@Domicilio,@NroPiso,@Localidad,@CodigoPostal,@NroDpto)

				select @idDomicilio=max(id_domicilio) from T_REX.DOMICILIO where direc_calle=@Domicilio and direc_nro_piso=@NroPiso and direc_localidad=@Localidad and 
				codigoPostal=@CodigoPostal and direc_nro_depto=@NroDpto

				if(@@ROWCOUNT = 0) 
				begin
					RAISERROR('Domicilio Inexistente',16 ,1)
					return
				end

				if(EXISTS(select 1 from T_REX.CLIENTE where nro_documento=@Documento and tipo_documento=@TipoDocumento or email=@Mail))
				begin
					RAISERROR('ERROR: cliente duplicado, email o documento ya existente', 16, 1)
					return
				end
				else
				begin
					insert into T_REX.CLIENTE(Nombre,Apellido,nro_documento,tipo_documento,fechaDeNacimiento,email,telefono,creditoTotal,id_domicilio,id_usuario)
						values(@Nombre,@Apellido,@Documento,@TipoDocumento,@FechaNacimiento,@Mail,@Telefono,@creditoInicial,@idDomicilio,@id_usuario)
				end

			commit TRANSACTION [T]
		end
	
	else if (@Accion = 'M')

		begin
			begin TRANSACTION [T]
				select @idDomicilio=id_domicilio from T_REX.CLIENTE where id_cliente=@IdCliente
				if(@@ROWCOUNT = 0) 
				begin
					RAISERROR('Cliente Inexistente',16 ,1);
					return
				end

				if(exists(select 1 from T_REX.CLIENTE where (nro_documento=@Documento and tipo_documento=@TipoDocumento or email=@Mail) and id_cliente!= @idCliente))
				begin
					RAISERROR('ERROR: cliente duplicado, email o documento ya existente', 16, 1)
					return
				end
				else
				begin
					update T_REX.CLIENTE
					set nombre = @Nombre,
						apellido = @Apellido,
						tipo_documento=@TipoDocumento,
						nro_documento=@Documento,
						fechaDeNacimiento = @FechaNacimiento,
						email = @Mail,
						telefono = @Telefono,
						baja_logica = '1'
					Where id_cliente = @IdCliente
			
					update T_REX.DOMICILIO
					set direc_calle = @Domicilio,
						direc_nro_piso = @NroPiso,
						direc_localidad = @Localidad,
						codigoPostal = @CodigoPostal,
						direc_nro_depto = @NroDpto
					Where id_domicilio= @idDomicilio


					select @id_usuario=id_usuario from T_REX.CLIENTE where id_cliente=@IdCliente
				
					if(@@ROWCOUNT = 0) 
					begin
						RAISERROR('usuario Inexistente',16 ,1);
						return
					end

					if(@pass is null)
					begin
						update T_REX.USUARIO
						set username = @user
						Where id_usuario= @id_usuario
					end
					else
					begin
						update T_REX.USUARIO
						set username = @user,
							password = CONVERT(varchar(64), HASHBYTES('SHA2_256', @pass), 2)
						Where id_usuario= @id_usuario
					end
					
				end
			commit TRANSACTION [T]
		end

	end try
	begin catch
		ROLLBACK TRANSACTION [T]
		set @out = ERROR_MESSAGE();
	end catch

END
GO
IF OBJECT_ID('T_REX.DeshabilitarCliente') IS NOT NULL
	DROP PROCEDURE T_REX.DeshabilitarCliente;
GO
CREATE PROCEDURE T_REX.DeshabilitarCliente
	@out varchar(1000) OUTPUT,
	@IdCliente int
AS

BEGIN
	
	begin try
		update T_REX.CLIENTE
		set baja_logica = '0'
		Where id_cliente = @IdCliente

		if(@@ROWCOUNT = 0) 
		begin
			RAISERROR('Cliente Inexistente',16 ,1)
			return
		end

	end try
	begin catch
		ROLLBACK TRANSACTION [T]
		set @out = ERROR_MESSAGE();
	end catch

END
GO

IF OBJECT_ID('T_REX.HabilitarCliente') IS NOT NULL
	DROP PROCEDURE [T_REX].HabilitarCliente;
GO
CREATE PROCEDURE [T_REX].HabilitarCliente
	@out varchar(1000) OUTPUT,
	@IdCliente int
AS

BEGIN
	
	begin try
		update T_REX.CLIENTE
		set baja_logica = '1'
		Where id_cliente = @IdCliente

		if(@@ROWCOUNT = 0) 
		begin
			RAISERROR('Cliente Inexistente',16 ,1)
			return
		end

	end try
	begin catch
		ROLLBACK TRANSACTION [T]
		set @out = ERROR_MESSAGE();
	end catch

END

--//---------- PROVEEDOR ----------//
GO
IF OBJECT_ID('T_REX.AbmProveedor') IS NOT NULL
	DROP PROCEDURE [T_REX].AbmProveedor;
GO
CREATE PROCEDURE [T_REX].AbmProveedor

	@Provee_rs nvarchar(150),
	@Provee_cuit nvarchar(40),
	@Mail nvarchar(150),
	@Telefono int,
	@NombreDeRubro nvarchar (150),
	@Domicilio nvarchar(100),
	@NroPiso nvarchar(100),
	@NroDpto nvarchar(50),
	@Localidad nvarchar(255),
	@CodigoPostal nvarchar(50),
	@user nvarchar(255),
	@pass varchar(255) = NULL,
	@Accion varchar(1),
	@out varchar(1000) OUTPUT,
	@IdProveedor int = NULL
AS

BEGIN
	
	begin try
		declare @idDomicilio int, @id_usuario int, @id_rubro int
	if(@Accion = 'A')

		begin
			if(@pass is null)
			begin
				RAISERROR('Tiene que elegir una password.',16 ,1)
				return
			end
			declare @id_proveedor int;
			begin TRANSACTION [T]

				select @id_rubro=id_rubro from T_REX.RUBRO where nombreDeRubro=@NombreDeRubro;
				if(@@ROWCOUNT = 0) 
				begin
					RAISERROR('Rubro Inexistente',16 ,1)
					return
				end

				insert into T_REX.USUARIO(username, password) values (@user, CONVERT(varchar(64), HASHBYTES('SHA2_256', @pass), 2));
				select @id_usuario=id_usuario from T_REX.USUARIO where username=@user;
				if(@@ROWCOUNT = 0) 
				begin
					RAISERROR('Usuario Inexistente',16 ,1)
					return
				end
				insert into T_REX.ROL_USUARIO(id_usuario,id_rol) VALUES (@id_usuario,2);

				insert into T_REX.DOMICILIO(direc_calle,direc_nro_piso,direc_localidad,codigoPostal,direc_nro_depto)
				values(@Domicilio,@NroPiso,@Localidad,@CodigoPostal,@NroDpto)

				select @idDomicilio=max(id_domicilio) from T_REX.DOMICILIO where direc_calle=@Domicilio and direc_nro_piso=@NroPiso and direc_localidad=@Localidad and 
				codigoPostal=@CodigoPostal and direc_nro_depto=@NroDpto

				if(@@ROWCOUNT = 0) 
				begin
					RAISERROR('Domicilio Inexistente',16 ,1)
					return
				end

				if(EXISTS(select 1 from T_REX.PROVEEDOR where provee_rs=@Provee_rs and provee_cuit=@Provee_cuit or email=@Mail))
				begin
					RAISERROR('ERROR: proveedor duplicado, email o razon social/cuit ya existente', 16, 1)
					return
				end
				else
				begin
					insert into T_REX.PROVEEDOR(provee_rs, provee_cuit, email, provee_telefono, id_domicilio, id_rubro, id_usuario)
						values(@Provee_rs, @Provee_cuit, @Mail, @Telefono, @idDomicilio, @id_rubro, @id_usuario)
				end

			commit TRANSACTION [T]
		end
	
	else if (@Accion = 'M')
		begin
			begin TRANSACTION [T]
				select @idDomicilio=id_domicilio, @id_usuario=id_usuario from T_REX.PROVEEDOR where id_proveedor=@IdProveedor
				if(@@ROWCOUNT = 0) 
				begin
					RAISERROR('Proveedor Inexistente',16 ,1);
					return
				end

				select @id_rubro=id_rubro from T_REX.RUBRO where nombreDeRubro=@NombreDeRubro;
				if(@@ROWCOUNT = 0) 
				begin
					RAISERROR('Rubro Inexistente',16 ,1)
					return
				end

				if(@Mail = 'No definido') 
				begin
					RAISERROR('ERROR: Ingrese un email valido', 16, 1)
					return
				end

				if(exists(select 1 from T_REX.PROVEEDOR where (provee_rs=@Provee_rs and provee_cuit=@Provee_cuit or email=@Mail) and id_proveedor!= @IdProveedor))
				begin
					RAISERROR('ERROR: Proveedor duplicado, email o razon social/cuit ya existente', 16, 1)
					return
				end
				else
				begin
					update T_REX.PROVEEDOR
					set provee_rs=@Provee_rs,
						provee_cuit=@Provee_cuit,
						email = @Mail,
						provee_telefono = @Telefono,
						estado = '1',
						id_rubro = @id_rubro
					Where id_proveedor = @IdProveedor
			
					update T_REX.DOMICILIO
					set direc_calle = @Domicilio,
						direc_nro_piso = @NroPiso,
						direc_localidad = @Localidad,
						codigoPostal = @CodigoPostal,
						direc_nro_depto = @NroDpto
					Where id_domicilio= @idDomicilio

/*
					select @id_usuario=id_usuario from T_REX.CLIENTE where id_cliente=@IdCliente
				
					if(@@ROWCOUNT = 0) 
					begin
						RAISERROR('usuario Inexistente',16 ,1);
						return
					end
*/
					if(@pass is null)
					begin
						update T_REX.USUARIO
						set username = @user
						Where id_usuario= @id_usuario
					end
					else
					begin
						update T_REX.USUARIO
						set username = @user,
							password = CONVERT(varchar(64), HASHBYTES('SHA2_256', @pass), 2)
						Where id_usuario= @id_usuario
					end
					
				end
			commit TRANSACTION [T]
		end

	end try
	begin catch
		ROLLBACK TRANSACTION [T]
		set @out = ERROR_MESSAGE();
	end catch

END
GO

IF OBJECT_ID('T_REX.DeshabilitarProveedor') IS NOT NULL
	DROP PROCEDURE [T_REX].DeshabilitarProveedor;
GO
CREATE PROCEDURE [T_REX].DeshabilitarProveedor
	@out varchar(1000) OUTPUT,
	@IdProveedor int
AS

BEGIN
	
	begin try
		update T_REX.PROVEEDOR
		set estado = '0'
		Where id_proveedor = @IdProveedor

		if(@@ROWCOUNT = 0) 
		begin
			RAISERROR('Provedor Inexistente',16 ,1)
			return
		end

	end try
	begin catch
		ROLLBACK TRANSACTION [T]
		set @out = ERROR_MESSAGE();
	end catch

END
GO

IF OBJECT_ID('T_REX.HabilitarProveedor') IS NOT NULL
	DROP PROCEDURE [T_REX].HabilitarProveedor;
GO
CREATE PROCEDURE [T_REX].HabilitarProveedor
	@out varchar(1000) OUTPUT,
	@IdProveedor int
AS

BEGIN
	
	begin try
		update T_REX.PROVEEDOR
		set estado = '1'
		Where id_proveedor = @IdProveedor

		if(@@ROWCOUNT = 0) 
		begin
			RAISERROR('Provedor Inexistente',16 ,1)
			return
		end

	end try
	begin catch
		ROLLBACK TRANSACTION [T]
		set @out = ERROR_MESSAGE();
	end catch

END
GO

IF OBJECT_ID('T_REX.ExisteUsuarioConNombre') IS NOT NULL
	DROP PROCEDURE [T_REX].ExisteUsuarioConNombre;
GO
CREATE PROCEDURE [T_REX].ExisteUsuarioConNombre
	@out bit OUTPUT,
	@username nvarchar(255)
AS
BEGIN
	IF(EXISTS(SELECT 1 FROM T_REX.USUARIO u WHERE u.username = @username))
		set @out = 1
	else
		set @out = 0
END
GO




--//---------- OFERTA ----------//

GO
IF OBJECT_ID('T_REX.ABMOferta') IS NOT NULL
	DROP PROCEDURE [T_REX].ABMOferta;
GO
CREATE PROCEDURE [T_REX].ABMOferta
	@IdOferta int = NULL,
	@Accion varchar(1),
	@Descripcion nvarchar(255),
	@fecha_inicio datetime,
	@fecha_fin datetime,
	@precio_oferta decimal(30,2),
	@precio_lista decimal(30,2),
	@cantDisp int,
	@cantMax int,
	@id_proveedor int,
	@out varchar(1000) OUTPUT
AS
BEGIN
	IF( NOT EXISTS (SELECT 1 FROM [T_REX].PROVEEDOR WHERE id_proveedor=@id_proveedor) )
	BEGIN
		RAISERROR('ERROR: No existe proveedor.', 16, 1)
		return
	END

	IF(@Accion = 'A')
	BEGIN
		INSERT INTO [T_REX].OFERTA (
					cod_oferta,
					descripcion,
					fecha_inicio,
					fecha_fin,
					precio_oferta,
					precio_lista,
					cantDisponible,
					cant_max_porCliente,
					id_proveedor) VALUES (NULL, @Descripcion, @fecha_inicio, @fecha_fin, @precio_oferta, @precio_lista, @cantDisp, @cantMax, @id_proveedor);
	END
	ELSE IF(@Accion = 'M')
	BEGIN
		IF(NOT EXISTS (SELECT 1 FROM [T_REX].OFERTA WHERE id_oferta = @IdOferta))
		BEGIN
			RAISERROR('ERROR: No existe oferta.', 16, 1)
			return
		END
		ELSE
		BEGIN
			UPDATE [T_REX].OFERTA SET descripcion=@Descripcion, fecha_inicio=@fecha_inicio, fecha_fin=@fecha_fin, 
			precio_oferta=@precio_oferta, precio_lista=@precio_lista, cantDisponible=@cantDisp, cant_max_porCliente=@cantMax, @id_proveedor=@id_proveedor
			WHERE id_oferta = @IdOferta;
		END
	END
END
GO

--//---------- Listado Estadistico ----------//
GO
--1--
IF OBJECT_ID('T_REX.ProveedoresConMasDescuento') IS NOT NULL
    DROP PROCEDURE [T_REX].ProveedoresConMasDescuento
GO

CREATE PROCEDURE [T_REX].ProveedoresConMasDescuento ( @anio int, @semestre int)
AS 
BEGIN
	select top 5 
		p.id_proveedor,
		p.provee_rs,
		p.provee_cuit,
		convert( decimal(18,2), ((( avg(o.precio_lista)-avg(o.precio_oferta))*100)/ avg(precio_lista))) as "Mayor Porcentaje de descuento"
	from T_REX.OFERTA o
	inner join T_REX.PROVEEDOR p on p.id_proveedor=o.id_proveedor
	WHERE @anio=YEAR(o.fecha_inicio) and @semestre=((DATEPART(QUARTER,o.fecha_inicio)/3)+1)
	group by p.id_proveedor, p.provee_rs,p.provee_cuit
	order by [Mayor Porcentaje de descuento] desc, avg(precio_lista) desc
END
GO

--2--
IF OBJECT_ID('T_REX.ProveedoresConMayorFacturacion') IS NOT NULL
    DROP PROCEDURE [T_REX].ProveedoresConMayorFacturacion
GO
CREATE PROCEDURE [T_REX].ProveedoresConMayorFacturacion ( @anio int, @semestre int)
AS 
BEGIN
	SELECT top 5
			p.id_proveedor,
			p.provee_rs,
			p.provee_cuit,
			f.importe_fact as 'Mayor facturacion'
	from T_REX.PROVEEDOR p
	INNER JOIN T_REX.FACTURA_PROVEEDOR f on p.id_proveedor=f.id_proveedor
	WHERE @anio=YEAR(f.fecha_fin) and @semestre=((DATEPART(QUARTER,f.fecha_inicio)/3)+1)
	group by p.id_proveedor, p.provee_rs, p.provee_cuit, f.importe_fact 
	order by f.importe_fact desc
END
GO

--//---------- CREDITO ----------//

IF OBJECT_ID('T_REX.CargarSaldo') IS NOT NULL
	DROP PROCEDURE [T_REX].CargarSaldo;
GO

CREATE PROCEDURE [T_REX].CargarSaldo
	@IdCliente int,
	@Monto int,
	@fecha_credito datetime,
	@forma_pago nvarchar (150),
	@tipo_tarjeta nvarchar (150),
	@nro_tarjeta nvarchar (150),
	@titular_tarjeta nvarchar (150),
	@banco_tarjeta nvarchar(150),
	@out varchar(1000) OUTPUT
AS
BEGIN
	IF( NOT EXISTS (SELECT 1 FROM [T_REX].CLIENTE WHERE id_cliente=@IdCliente AND baja_logica=1 AND estado=1) )
	BEGIN
		RAISERROR('ERROR: No existe cliente o no se encuentra habilitado.', 16, 1)
		return
	END
	DECLARE @id_forma_pago int, @id_tarjeta int, @titular_tarjeta_ex nvarchar (150), @banco_tarjeta_ex nvarchar(150), @tipo_tarjeta_ex nvarchar (150)

	SELECT @id_forma_pago=id_forma_pago from T_REX.FORMA_PAGO where lower(tipo_pago_desc)=lower(@forma_pago);
	if(@@ROWCOUNT = 0) 
	begin
		RAISERROR('Forma de pago Inexistente',16 ,1)
		return
	end
	if(@forma_pago <> @tipo_tarjeta)
	begin
		RAISERROR('Forma de pago no coincide con tipo de tarjeta.',16 ,1)
		return
	end

	BEGIN TRY
		BEGIN TRANSACTION [T]
		SELECT @id_tarjeta=id_tarjeta, @titular_tarjeta_ex=titular_tarjeta, @banco_tarjeta_ex=banco_tarjeta, @tipo_tarjeta_ex=tipo_tarjeta FROM T_REX.TARJETA WHERE nro_tarjeta=@nro_tarjeta;
		if(@@ROWCOUNT > 0) 
		begin
			if(@titular_tarjeta_ex <> @titular_tarjeta)
			begin
				RAISERROR('Tarjeta invalida: Actualmente asignada a otro titular.',16 ,1)
				return
			end

			if(@banco_tarjeta_ex <> @banco_tarjeta)
			begin
				RAISERROR('Tarjeta invalida: Actualmente asignada a otro banco.',16 ,1)
				return
			end

			if(@tipo_tarjeta_ex <> @tipo_tarjeta)
			begin
				RAISERROR('Tarjeta invalida: Actualmente asignada a otro tipo de tarjeta.',16 ,1)
				return
			end
		end
		else
		begin
			INSERT INTO T_REX.TARJETA (nro_tarjeta, titular_tarjeta, banco_tarjeta, tipo_tarjeta) VALUES (@nro_tarjeta, @titular_tarjeta, @banco_tarjeta, @tipo_tarjeta)
			select @id_tarjeta=max(id_tarjeta) from T_REX.TARJETA
		end

		INSERT INTO T_REX.CREDITO (fecha_credito, id_cliente, id_forma_pago, monto_credito, id_tarjeta) VALUES (@fecha_credito, @IdCliente, @id_forma_pago, @Monto, @id_tarjeta)
		UPDATE T_REX.CLIENTE SET creditoTotal=(creditoTotal+@Monto) WHERE id_cliente=@IdCliente

		COMMIT TRANSACTION [T]
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION [T]
		set @out = ERROR_MESSAGE();
	END CATCH
END
GO

-- CREACION STRING RANDOM PARA CODIGO
IF OBJECT_ID('T_REX.getNewID', 'V') IS NOT NULL
	DROP VIEW [T_REX].getNewID;
GO

CREATE VIEW [T_REX].getNewID as select newid() as new_id
GO

IF OBJECT_ID('T_REX.RANDOM_STRING') IS NOT NULL
	DROP FUNCTION [T_REX].RANDOM_STRING;
GO

CREATE FUNCTION [T_REX].RANDOM_STRING (@Length int)
RETURNS VARCHAR(255)
AS
 BEGIN
	DECLARE @ret VARCHAR(255);
	SELECT @ret = t.Random FROM (
	 SELECT (
		SELECT
			c1 AS [text()]
		FROM
			(
			SELECT TOP (@Length) c1
			FROM
			  (
			VALUES
			  ('A'), ('B'), ('C'), ('D'), ('E'), ('F'), ('G'), ('H'), ('I'), ('J'),
			  ('K'), ('L'), ('M'), ('N'), ('O'), ('P'), ('Q'), ('R'), ('S'), ('T'),
			  ('U'), ('V'), ('W'), ('X'), ('Y'), ('Z'), ('0'), ('1'), ('2'), ('3'),
			  ('4'), ('5'), ('6'), ('7'), ('8'), ('9')	
			  ) AS T1(c1)
			ORDER BY ABS(CHECKSUM( (select new_id from [T_REX].getNewID) ))
			) AS T2
		FOR XML PATH('')
		) Random ) t
	RETURN @ret;
 END
GO

--//---------- COMPRA ----------//


IF OBJECT_ID('T_REX.CrearCompra') IS NOT NULL
	DROP PROCEDURE [T_REX].CrearCompra;
GO
CREATE PROCEDURE [T_REX].CrearCompra
	@IdOferta int,
	@IdCliente int,
	@Fecha datetime,
	@Cantidad int,
	@IdOut int OUTPUT,
	@out varchar(1000) OUTPUT
AS
BEGIN
	DECLARE @Monto int, @CantidadCompradosPorCliente int, @MaxPorCliente int, @CreditoCliente int, @PrecioOferta decimal (20,2), @PrecioLista decimal (20,2)
	
	SELECT @CreditoCliente=creditoTotal FROM [T_REX].CLIENTE WHERE id_cliente=@IdCliente AND baja_logica=1 AND estado=1
	IF(@@ROWCOUNT = 0) 
	BEGIN
		RAISERROR('ERROR: No existe cliente o no se encuentra habilitado.', 16, 1)
		return
	END

	SELECT @MaxPorCliente=cant_max_porCliente FROM [T_REX].OFERTA WHERE id_oferta=@IdOferta AND cantDisponible >= @Cantidad AND cant_max_porCliente >= @Cantidad
	IF(@@ROWCOUNT = 0)
	BEGIN
		RAISERROR('ERROR: Asegurese que existe la oferta con cantidad disponible que no supere el maximo permitido por cliente.', 16, 1)
		return
	END

	IF( NOT EXISTS (SELECT 1 FROM [T_REX].OFERTA WHERE id_oferta=@IdOferta AND fecha_inicio <= @Fecha AND @Fecha <= fecha_fin) )
	BEGIN
		RAISERROR('ERROR: La oferta no esta vigente.', 16, 1)
		return
	END

	SELECT @Monto=(precio_oferta * @Cantidad), @PrecioOferta=precio_oferta, @PrecioLista=precio_lista FROM [T_REX].OFERTA WHERE id_oferta=@IdOferta

	IF(@CreditoCliente < @Monto)
	BEGIN
		RAISERROR('ERROR: Credito insuficiente.', 16, 1)
		return
	END

	SELECT @CantidadCompradosPorCliente=SUM(cantidad) from [T_REX].COMPRA WHERE id_cliente=@IdCliente AND id_oferta=@IdOferta

	IF( (@CantidadCompradosPorCliente + @Cantidad) > @MaxPorCliente)
	BEGIN
		RAISERROR('ERROR: Supera el Maximo de cupones permitido por cliente.', 16, 1)
		return
	END

	BEGIN TRY
		BEGIN TRANSACTION [T]

			UPDATE [T_REX].OFERTA SET cantDisponible=(cantDisponible - @Cantidad) WHERE id_oferta = @IdOferta

			UPDATE T_REX.CLIENTE SET creditoTotal=(creditoTotal - @Monto) WHERE id_cliente=@IdCliente

			INSERT INTO [T_REX].COMPRA (compra_fecha, id_cliente, id_oferta, cantidad) VALUES (@Fecha, @IdCliente, @IdOferta, @Cantidad)
			SELECT @IdOut = MAX(id_compra) FROM [T_REX].COMPRA

			DECLARE @i int
			SET @i = 1
			WHILE (@i <= @Cantidad)
			BEGIN

				INSERT INTO [T_REX].CUPON (cupon_codigo, cupon_precio_oferta, cupon_precio_lista, cupon_estado, id_compra, id_oferta)
				VALUES ([T_REX].RANDOM_STRING(12), @PrecioOferta, @PrecioLista, 1, @IdOut, @IdOferta)

				SET @i = @i + 1
			END

		COMMIT TRANSACTION [T]
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION [T]
		set @out = ERROR_MESSAGE();
	END CATCH
END
GO

--//---------- CUPON ----------//

IF OBJECT_ID('T_REX.EntregarCupon') IS NOT NULL
	DROP PROCEDURE [T_REX].EntregarCupon;
GO
CREATE PROCEDURE [T_REX].EntregarCupon
	@id_cupon int,
	@id_consumidor int,
	@fecha_consumo datetime,
	@out varchar(1000) OUTPUT
AS
BEGIN
	IF( NOT EXISTS (SELECT 1 FROM [T_REX].CLIENTE WHERE id_cliente=@id_consumidor AND baja_logica=1 AND estado=1) )
	BEGIN
		RAISERROR('ERROR: Cliente no habilitado para canjear cupon.', 16, 1)
		return
	END

	IF( NOT EXISTS (SELECT 1 FROM [T_REX].CUPON WHERE id_cupon=@id_cupon AND cupon_estado=1) )
	BEGIN
		RAISERROR('ERROR: No existe cupon disponible para canjear.', 16, 1)
		return
	END

	UPDATE T_REX.CUPON SET cupon_fecha_deconsumo=@fecha_consumo, id_consumidor=@id_consumidor, cupon_estado=0 WHERE id_cupon=@id_cupon
END
GO

--//---------- Factura ----------//

IF OBJECT_ID('T_REX.CrearFactura') IS NOT NULL
	DROP PROCEDURE [T_REX].CrearFactura;
GO
CREATE PROCEDURE [T_REX].CrearFactura
	@IdProveedor int,
	@FechaDesde datetime,
	@FechaHasta datetime,
	@IdOut int OUTPUT,
	@out varchar(1000) OUTPUT
AS
BEGIN
	DECLARE @ImporteFactura decimal (20,2), @NroFactura int
	
	IF( NOT EXISTS (SELECT 1 FROM [T_REX].PROVEEDOR WHERE id_proveedor=@IdProveedor) )
	BEGIN
		RAISERROR('ERROR: No existe proveedor.', 16, 1)
		return
	END

	IF(@FechaDesde > @FechaHasta)
	BEGIN
		RAISERROR('ERROR: Fecha desde tiene que ser menor a fecha hasta.', 16, 1)
		return
	END

	BEGIN TRY
		BEGIN TRANSACTION [T]
		
		SELECT @ImporteFactura = sum(c.cupon_precio_oferta) FROM T_REX.CUPON c
			INNER JOIN T_REX.COMPRA cp ON cp.id_compra=c.id_compra
			INNER JOIN T_REX.OFERTA o ON c.id_oferta=o.id_oferta
			WHERE o.id_proveedor=@IdProveedor 
			AND cp.facturado = 0
			AND cp.compra_fecha BETWEEN @FechaDesde AND @FechaHasta

		IF(@ImporteFactura IS NULL OR @ImporteFactura = 0)
		BEGIN
			RAISERROR('ERROR: No se han encontrado ofertas disponibles para facturar en el periodo indicado.', 16, 1)
			return
		END

		SELECT @NroFactura = max(cast((nro_factura) as int))+1 FROM [T_REX].Factura_Proveedor

		-- INSERT FACTURA
		INSERT INTO [T_REX].FACTURA_PROVEEDOR (nro_factura, importe_fact, tipo_factura, fecha_inicio, fecha_fin, id_proveedor)
		VALUES ( @NroFactura, @ImporteFactura, 'B', @FechaDesde, @FechaHasta, @IdProveedor )

		-- GET ID_FACTURA
		SELECT @IdOut = max(id_factura) FROM [T_REX].FACTURA_PROVEEDOR

		-- INSERT ITEMs FACTURA
		INSERT INTO [T_REX].ITEM_FACTURA (importe_oferta, cantidad, id_factura, id_oferta)
			select sum(c.cupon_precio_oferta) importe_oferta, count(c.id_cupon) cantidad, @IdOut id_factura, o.id_oferta 
			from T_REX.CUPON c
			INNER JOIN T_REX.COMPRA cp ON cp.id_compra=c.id_compra
			INNER JOIN T_REX.OFERTA o ON c.id_oferta=o.id_oferta
			WHERE o.id_proveedor=@IdProveedor
			AND cp.facturado = 0 
			AND cp.compra_fecha BETWEEN @FechaDesde AND @FechaHasta
			GROUP BY o.id_oferta

		UPDATE [T_REX].COMPRA SET facturado = 1 
		FROM [T_REX].COMPRA c
		INNER JOIN [T_REX].OFERTA o ON c.id_oferta = o.id_oferta
		WHERE o.id_proveedor=@IdProveedor
		AND c.compra_fecha BETWEEN @FechaDesde AND @FechaHasta

		COMMIT TRANSACTION [T]
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION [T]
		set @out = ERROR_MESSAGE();
	END CATCH
END
GO