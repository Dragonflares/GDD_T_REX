--	ALTA PROVEEDOR [T_REX].SP_NewProveedor

IF OBJECT_ID('T_REX.SP_NewProveedor') IS NOT NULL
DROP PROCEDURE [T_REX].SP_NewProveedor
GO

CREATE PROCEDURE [T_REX].SP_NewProveedor
@user nvarchar (255), 
@pass nvarchar (255),

@provee_rs nvarchar(150),
@cuit nvarchar(40),
@email nvarchar(100),
@tel int,
@dir_calle nvarchar(100),
@dir_nropiso nvarchar(100),
@localidad nvarchar(255),
@codpostal nvarchar (50),
@direc_nrodepto nvarchar(50),
@nombre_rubro nvarchar (150)   

as

declare @resultado nvarchar(255)

BEGIN TRANSACTION [T]

BEGIN TRY
	declare @id_usu int, @id_domicilio int, @id_rubro int ;

	if not exists  ( select 1 from [T_REX].USUARIO where username=@user )
		begin

			insert into [T_REX].USUARIO( [username],[password])
			values (@user,@pass);

			set @id_usu = (select id_usuario from [T_REX].USUARIO where username=@user)
			
			insert into [T_REX].ROL_USUARIO(id_usuario,id_rol) 
			values (@id_usu,3);
		end
	else
		begin
			
		RAISERROR('El usuario ya existe en el sistema',16,1)
		end
	
	if not exists (select 1 from [T_REX].PROVEEDOR where provee_cuit=@cuit or email=@email or provee_rs=@provee_rs)
	begin
		
		insert into [T_REX].DOMICILIO(
					direc_calle,
					direc_nro_piso,
					direc_localidad,
					codigoPostal,
					direc_nro_depto )
		values ( @dir_calle, @dir_nropiso, @localidad,@codpostal, @direc_nrodepto)  
		
		set @id_domicilio= (select id_domicilio from T_REX.DOMICILIO where @dir_calle=direc_calle and @dir_nropiso=direc_nro_piso and @localidad=direc_localidad) 

		set @id_rubro= ( select id_rubro from T_REX.RUBRO where @nombre_rubro=nombreDeRubro)

		insert into [T_REX].PROVEEDOR(
					provee_rs,
					provee_cuit,
					email,
					provee_telefono,
					id_usuario,
					id_domicilio,
					id_rubro )
	
		values (@provee_rs,@cuit,@email,@tel,@id_usu, @id_domicilio, @id_rubro )
	
			end
	else
			RAISERROR('La empresa ya existe en el sistema',16,1)
	
COMMIT TRANSACTION [T]

set @resultado = @resultado +';OK';

END TRY

BEGIN CATCH

    ROLLBACK TRANSACTION [T]

	set @resultado = ERROR_MESSAGE()+';;ERROR';

END CATCH;
SELECT @resultado
GO