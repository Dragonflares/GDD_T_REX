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
		nombre nvarchar (50) NOT NULL,
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
		username nvarchar (255) NOT NULL,
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
		id_usuario int FOREIGN KEY REFERENCES [T_REX].USUARIO(id_usuario) NOT NULL
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
		cantidad decimal (15,0) NOT NULL
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

--select HASHBYTES('SHA2_256', 'w23e')	contraseña del admin
--select HASHBYTES('SHA2_256', '1234') contraseña para usuarios y proveedores

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

-----------------------------------------------------------------------------------------------------------------

/*Creacion de Funcionalidad_Rol*/

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
SELECT distinct Tipo_Pago_Desc
FROM gd_esquema.Maestra
Where Tipo_Pago_Desc is not null

-------------------------------------------------------------------------------------------------------------------

/*Creacion de Tarjeta*/

INSERT INTO [T_REX].[TARJETA] (nro_tarjeta,titular_tarjeta,banco_tarjeta,tipo_tarjeta)
VALUES('0000000000000000','No se tiene registro', 'No se tiene registro','No se tiene registro')

---------------------------------------------------------------------------------------------------------------------

/*Migracion de Proveedor*/

-- 37 PROVEEDORES

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

/* Insertar en Tabla domicilio*/

insert into [T_REX].[DOMICILIO] (direc_calle, direc_localidad )
select  Provee_Dom,Provee_Ciudad
from #Temp_Proveedor


/*Insertar tabla usuario */

insert into [T_REX].[USUARIO] ( username, password )
select  Provee_CUIT, CONVERT(varchar(64), HASHBYTES('SHA2_256', '1234'), 2) pass
from #Temp_Proveedor

-- NOTA: Los proveedores tienen "nombre usuario": CUIT y contraseña: "1234" para todos, luego cuando realicen el primer logueo deben cambiar la contraseña


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

--El número 0 es FALSE, y el 1  es TRUE.


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
select
		a.Oferta_Fecha_Compra,
		c.id_cliente,
		o.id_oferta,
		count(*) 
from [gd_esquema].[Maestra] a
inner join [T_REX].[CLIENTE] c on a.Cli_Dni=c.nro_documento 
inner join [T_REX].[OFERTA] o on a.Oferta_Codigo=o.cod_oferta
where a.Oferta_Fecha_Compra is not null
group by a.Oferta_Fecha_Compra,
		c.id_cliente,
		o.id_oferta
order by 1,2

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
										SPs y FN													
##########################################################################################################*/

--//---------- USUARIO ----------//

--exec [T_REX].LogearUsuario '88430112', '1234', 'Proveedor';

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
	
	IF(@tipoUsuario = 'Cliente')
	BEGIN
		IF(NOT EXISTS(SELECT 1 FROM [T_REX].USUARIO us JOIN [T_REX].CLIENTE cli ON (us.id_usuario = cli.id_usuario) WHERE us.username = @username))
		BEGIN	
			RAISERROR('ERROR: USUARIO incorrecto, no existe ningun cliente con este username', 16, 1)
			return
		END
	END
	ELSE 
	BEGIN
		IF(@tipoUsuario = 'Proveedor')
		BEGIN	
			IF(NOT EXISTS(SELECT 1 FROM [T_REX].USUARIO us JOIN [T_REX].PROVEEDOR provee ON (us.id_usuario = provee.id_usuario) WHERE us.username = @username))
			BEGIN		
				RAISERROR('ERROR: USUARIO incorrecto, no existe ningun proveedor con este username', 16, 1)
				return
			END
		END	
		ELSE 
		BEGIN
		IF(@tipoUsuario = 'Administrativo')
		BEGIN
			IF(EXISTS(SELECT 1 FROM [T_REX].USUARIO us JOIN [T_REX].PROVEEDOR provee ON (us.id_usuario = provee.id_usuario) WHERE us.username = @username) OR
				EXISTS(SELECT 1 FROM [T_REX].USUARIO us JOIN [T_REX].CLIENTE cli ON (us.id_usuario = cli.id_usuario) WHERE us.username = @username))
				BEGIN
				RAISERROR('ERROR: USUARIO incorrecto, no existe ningun administrativo con este username', 16, 1)
				return
				END
		END
		ELSE
		BEGIN
			RAISERROR('ERROR: USUARIO incorrecto, no coincide el rol con este username', 16, 1)
			return
		END
		END
		
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
				RAISERROR('ERROR: Supero el límite de intentos. Usuario bloqueado',16,1);
			END
			ELSE
			BEGIN
				RAISERROR ('ERROR: Contraseña incorrecta para el usuario %s. Intentos restantes: %i.',16,1,@username,@intentosFaltantes)
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


--//---------- ROLES ----------//

-- Habilitar un rol -- [T_REX].SP_HabilitarRol

IF OBJECT_ID('T_REX.SP_HabilitarRol') IS NOT NULL
    DROP PROCEDURE T_REX.SP_HabilitarRol
GO

CREATE PROCEDURE [T_REX].[SP_HabilitarRol]  @id_Rol int
as
	update [T_REX].ROL
	set estado = '1'
	where id_rol=@id_Rol

go

-- Modificar rol [T_REX].[UpdateRol]

IF OBJECT_ID('T_REX.UpdateRol') IS NOT NULL
    DROP PROCEDURE [T_REX].[UpdateRol]
GO

CREATE PROCEDURE [T_REX].[UpdateRol]
	@idRol int,
	@nombre varchar(50),
	@estado bit
as 
begin
	UPDATE [T_REX].ROL 
	SET nombre=@nombre, 
	estado=@estado
	WHERE id_rol=@idRol

end
go

-- TODOS LOS ROLES [T_REX].SP_GetAll_Roles

IF OBJECT_ID('T_REX.SP_GetAllRoles') IS NOT NULL
    DROP PROCEDURE [T_REX].[SP_GetAllRoles]
GO

CREATE PROCEDURE [T_REX].[SP_GetAllRoles]
as
	select * from [T_REX].ROL

go

-- Eliminar rol del usuario [T_REX].SP_Eliminar_RolDeUsuario

IF OBJECT_ID('T_REX.SP_Eliminar_RolDeUsuario') IS NOT NULL
    DROP PROCEDURE [T_REX].SP_Eliminar_RolDeUsuario
GO

CREATE PROCEDURE [T_REX].SP_Eliminar_RolDeUsuario
	@id_rol int,
	@id_usuario int
as
begin
	delete from [T_REX].ROL_USUARIO 
	where id_rol=@id_rol AND id_usuario=@id_usuario; 
end
go

-- Alta ROL		[T_REX].[SP_Alta_NuevoRol]

IF OBJECT_ID('T_REX.[SP_Alta_NuevoRol]') IS NOT NULL
    DROP PROCEDURE [T_REX].[SP_Alta_NuevoRol]
GO
CREATE PROCEDURE [T_REX].[SP_Alta_NuevoRol] @nombre nvarchar(50)
AS
	declare @resultado nvarchar(10)
	if not exists (select 1 from [T_REX].ROL where nombre=@nombre)
		BEGIN
			insert into [T_REX].ROL (nombre)
			values (@nombre)
			
			SELECT @resultado = max(id_rol)
			from [T_REX].ROL

		END
	else set @resultado = 'ERROR'

	select @resultado;

GO

-- Baja logica Rol - [T_REX].SP_Inhabilitar_Rol

IF OBJECT_ID('T_REX.SP_Inhabilitar_Rol') IS NOT NULL
    DROP PROCEDURE [T_REX].SP_Inhabilitar_Rol
GO

CREATE PROCEDURE [T_REX].SP_Inhabilitar_Rol @id_rol int
AS
	declare @resultado varchar(10);
	if not exists (select 1 from [T_REX].ROL_USUARIO ru
				   inner join [T_REX].USUARIO u on ru.id_usuario=u.id_usuario
				   where ru.id_rol=@id_rol )
	begin
		update [T_REX].ROL_USUARIO 
		set activo='0'
		where [id_rol]=@id_rol;

		update [T_REX].ROL
		set estado = '1'
		where id_rol=@id_rol;

		set @resultado='OK'
	end
	else set @resultado='Error'

	Select @resultado;

GO