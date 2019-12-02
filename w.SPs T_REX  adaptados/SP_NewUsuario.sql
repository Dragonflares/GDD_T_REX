--	ALTA USUARIO [T_REX].SP_NewUsuario

IF OBJECT_ID('T_REX.SP_NewUsuario') IS NOT NULL
DROP PROCEDURE [T_REX].SP_NewUsuario
GO

CREATE PROCEDURE [T_REX].SP_NewUsuario

@user nvarchar (255), 
@pass nvarchar (255),
@nombre_rol nvarchar (50)

as

declare @resultado nvarchar(255)

BEGIN TRANSACTION [T]

BEGIN TRY
	declare @id_usu int, @id_rol int ;

	if not exists  ( select 1 from [T_REX].USUARIO where username=@user )
		begin

			insert into [T_REX].USUARIO( [username],[password])
			values (@user,@pass);

			set @id_rol = (select id_rol from [T_REX].ROL where nombre=@nombre_rol)
			
			set @id_usu = (select id_usuario from [T_REX].USUARIO where username=@user )

			insert into [T_REX].ROL_USUARIO(id_usuario,id_rol) 
			values (@id_usu,@id_rol);
		end
	else
		begin
			
		RAISERROR('El usuario ya existe en el sistema',16,1)
		
		end
COMMIT TRANSACTION [T]

set @resultado = @resultado +';OK';

END TRY

BEGIN CATCH

    ROLLBACK TRANSACTION [T]

	set @resultado = ERROR_MESSAGE()+';;ERROR';

END CATCH;
SELECT @resultado
GO