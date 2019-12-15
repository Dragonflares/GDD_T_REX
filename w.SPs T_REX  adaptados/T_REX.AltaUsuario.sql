IF OBJECT_ID('T_REX.AltaUsuario') IS NOT NULL
	DROP PROCEDURE [T_REX].AltaUsuario;
GO
CREATE PROCEDURE [T_REX].AltaUsuario
	
	@IdUsuario int= NULL,
	@Password  nvarchar (255),
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