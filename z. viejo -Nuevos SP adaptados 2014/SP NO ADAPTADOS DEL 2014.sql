/****** Object:  UserDefinedFunction [LOS_NULL].[CANTIDAD_DIAS_SIN_SERVICIO]    Script Date: 11/11/2014 21:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [LOS_NULL].[CANTIDAD_DIAS_SIN_SERVICIO]
(
	@ID_HOTEL numeric (18,0),
	@FECHA datetime
)

RETURNS numeric (18,0)

AS
BEGIN
	
	RETURN
	(
	SELECT SUM (DATEDIFF(day,Fecha_Inicio,LOS_NULL.MENOR_FECHA(Fecha_Fin,@FECHA))) FROM   
		(SELECT Id_Hotel FROM LOS_NULL.Hotel WHERE Id_Hotel = @ID_HOTEL) HO 
		JOIN LOS_NULL.BajaTemporalHotel BH ON (HO.Id_Hotel = BH.Id_Hotel)
		WHERE DATEDIFF (QUARTER,Fecha_Inicio,@FECHA)=0
	)

	/*--utilizo la funcion MENOR_FECHA para lo siguiente:
	Si por ejemplo:
	Fecha_Inicio_de_baja=11/3/2014
	Fecha_Fin_de_baja=2/4/2014
	Entonces, la fecha de fin supera el primer trimestre de consulta (que termina el 31/3/2014)
	Utilizando esta funcion, me va a devolver la cantidad de dias inhabilitados desde inicio hasta la fecha limite del fin del trimestre
	Por ahi esta demás, pero me parece logico
	
	*/
	
END
GO
/****** Object:  Table [LOS_NULL].[CancelacionReserva]    Script Date: 11/11/2014 21:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [LOS_NULL].[CancelacionReserva](
	[ID_Cancelacion] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Motivo] [nvarchar](255) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Usuario] [nvarchar](255) NOT NULL,
	[Codigo_Reserva] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_CancelacionReserva] PRIMARY KEY CLUSTERED 
(
	[ID_Cancelacion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [LOS_NULL].[DAMEMENORFECHA]    Script Date: 11/11/2014 21:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[DAMEMENORFECHA] 

AS
BEGIN
	
	SELECT TOP 1 (YEAR(R.Fecha_Inicio)) AÑO
	FROM LOS_NULL.Reserva R
	ORDER BY R.Fecha_Inicio ASC
	
END
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [LOS_NULL].[ID_HABITACION]
(
	@ID_HOTEL numeric(18,0),
	@Numero numeric(18,0),
	@Piso numeric(18,0),
	@Frente nvarchar(255)
)
RETURNS numeric(18,0)
AS
BEGIN

	RETURN 
	(
	SELECT H.ID_Habitacion
	FROM LOS_NULL.Habitacion H
	WHERE H.ID_Hotel = @ID_HOTEL 
	AND H.Numero = @Numero
	AND H.Piso = @Piso
	AND H.Frente = @Frente
	)

END
GO
/****** Object:  StoredProcedure [LOS_NULL].[LISTADO_CLIENTES_POR_CAMPOS]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [LOS_NULL].[LISTADO_CLIENTES_POR_CAMPOS] 
	@NRO_PASAPORTE numeric(18,0),
	--@NACIONALIDAD nvarchar(255),
	@EMAIL nvarchar(255),
	@NOMBRE nvarchar(255),
	@APELLIDO nvarchar(255)	
AS
BEGIN

	SELECT * --C.Nombre,C.Apellido,C.Nro_Pasaporte,C.Mail
	FROM LOS_NULL.Cliente C
	WHERE (C.Nro_Pasaporte = @NRO_PASAPORTE  OR @NRO_PASAPORTE IS NULL)
	--AND (LOS_NULL.ID_NACIONALIDAD(@NACIONALIDAD) = C.ID_Nacionalidad OR @NACIONALIDAD IS NULL)
	AND (UPPER(C.Apellido) LIKE '%'+@APELLIDO OR @APELLIDO+'%' IS NULL OR @APELLIDO = '')
	AND (UPPER(C.Nombre) LIKE '%'+@NOMBRE+'%' OR @NOMBRE IS NULL OR @NOMBRE = '')
	AND (UPPER(C.Mail) LIKE '%'+@EMAIL+'%' OR @EMAIL IS NULL OR @EMAIL = '')

END



SET ANSI_NULLS ON
GO

/****** Object:  StoredProcedure [LOS_NULL].[TOP5HOTELESFUERADESERVICIO]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [LOS_NULL].[TOP5HOTELESFUERADESERVICIO]
	@FECHA datetime
	
AS
BEGIN
	
	SELECT * FROM
		(SELECT TOP 5 HO.ID_HOTEL,
			LOS_NULL.CANTIDAD_DIAS_SIN_SERVICIO(HO.Id_Hotel,@FECHA) Dias_Inhabilitado
		FROM LOS_NULL.Hotel HO
		ORDER BY Dias_Inhabilitado DESC) TAB
	WHERE TAB.Dias_Inhabilitado IS NOT NULL

    
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[UPDATESTATUS_NOSHOW]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [LOS_NULL].[UPDATESTATUS_NOSHOW]
	@RESERVA numeric(18,0),
	@STATUS numeric(18,0),
	@FECHA date,
	@USER varchar(50)
	
AS 
BEGIN
	
	DECLARE @MOTIVO varchar(255)
	SET @MOTIVO = 'El cliente no se presentó a tiempo para el Check-In'
	
	UPDATE LOS_NULL.Reserva
	SET ID_Estado=@STATUS, Usuario=@USER
	WHERE Codigo_Reserva=@RESERVA
	
	INSERT INTO LOS_NULL.CancelacionReserva (Codigo_Reserva,Fecha,Motivo,Usuario)
	VALUES (@RESERVA,@FECHA,@MOTIVO,@USER)

END
GO
-- =============================================
-- Author:		<Author,,Name>
-- ALTER date: <ALTER Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[INSERTARCLIENTERESERVA]
	@COD_RESERVA NUMERIC(18,0),
	@ID_CLIENTE NUMERIC(18,0)
AS
BEGIN
		IF EXISTS (SELECT * FROM LOS_NULL.ReservaXCliente WHERE Codigo_Reserva=@COD_RESERVA)
			BEGIN
				INSERT INTO ReservaXCliente(Codigo_Reserva,Nro_Cliente,Flag_Reserva)
				VALUES (@COD_RESERVA,@ID_CLIENTE,0) --ya existia la reserva, ya fue guardado el cliente generador
			END
		ELSE
			BEGIN
				INSERT INTO ReservaXCliente(Codigo_Reserva,Nro_Cliente,Flag_Reserva)
				VALUES (@COD_RESERVA,@ID_CLIENTE,1) --es la primera vez que se guarda en esta tabla con este codigo de reserva
			END
		

END
GO

/****** Object:  StoredProcedure [LOS_NULL].[BAJATEMPORALDEHOTEL]    Script Date: 11/11/2014 21:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- ALTER date: <ALTER Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[BAJATEMPORALDEHOTEL]
	@ID_HOTEL NUMERIC(18,0),
	@FECHA_INICIO DATETIME,
	@FECHA_FIN DATETIME,
	@DESCRIPCION NVARCHAR(255)
AS
BEGIN
    
    DECLARE @CANTIDAD_RESERVAS_EXISTENTES NUMERIC(18,0)           
            
	SET @CANTIDAD_RESERVAS_EXISTENTES = 
	(
	SELECT COUNT(*) Reservas_Existentes_Entre_Fechas
	FROM LOS_NULL.Hotel H 
			JOIN LOS_NULL.Habitacion HA ON (H.ID_Hotel = HA.ID_Hotel)
			JOIN LOS_NULL.ReservaXHabitacion RHA ON (RHA.ID_Habitacion = HA.ID_Habitacion)
			JOIN LOS_NULL.Reserva R ON (R.Codigo_Reserva = RHA.ID_Reserva)
	WHERE H.ID_Hotel = @ID_HOTEL	
		AND 
		(
		(R.Fecha_Inicio BETWEEN @FECHA_INICIO AND @FECHA_FIN AND DATEADD(D,R.Cant_Noches,R.Fecha_Inicio) BETWEEN @FECHA_INICIO AND @FECHA_FIN)	
		OR
		((DATEADD(D,R.Cant_Noches,R.Fecha_Inicio) BETWEEN @FECHA_INICIO AND @FECHA_FIN) AND R.Fecha_Inicio < @FECHA_INICIO)	
		OR	
		(R.Fecha_Inicio BETWEEN @FECHA_INICIO AND @FECHA_FIN) AND (DATEADD(D,R.Cant_Noches,R.Fecha_Inicio) > @FECHA_FIN)
		)		
	)		
	
	IF (@CANTIDAD_RESERVAS_EXISTENTES = 0)
	BEGIN
		INSERT INTO BajaTemporalHotel(ID_Hotel,Fecha_Inicio,Fecha_Fin,Descripcion)
		VALUES(@ID_HOTEL,@FECHA_INICIO,@FECHA_FIN,@DESCRIPCION)	
	END
	
	SELECT @CANTIDAD_RESERVAS_EXISTENTES
	           
END
GO


/****** Object:  StoredProcedure [LOS_NULL].[CANTIDADPERSONAS_RESERVA]    Script Date: 11/11/2014 21:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [LOS_NULL].[CANTIDADPERSONAS_RESERVA]
	@RESERVA numeric(18,0)
	
AS
BEGIN

	SELECT SUM(TH.Capacidad) FROM LOS_NULL.ReservaXHabitacion RH JOIN LOS_NULL.Habitacion H ON (RH.ID_Habitacion=H.ID_Habitacion)
	JOIN LOS_NULL.TipoHabitacion TH ON (TH.Codigo_Tipo=H.Codigo_Tipo)
	WHERE RH.ID_Reserva=@RESERVA

END
GO


