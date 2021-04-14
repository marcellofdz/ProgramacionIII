CREATE PROCEDURE [dbo].[registrar_usuario]
	@Nombres nvarchar(150),
	@Apellidos nvarchar(150),
	@Sexo nvarchar(150),
	@Direccion nvarchar(150),
	@Ciudad nvarchar(150),
	@Estado nvarchar(150),
	@Cedula nvarchar(150),
	@FechaNacimiento nvarchar(150)

AS
	IF NOT EXISTS (select 1 from tblUsuario where Cedula = @Cedula )
	insert into tblUsuario(
		Cedula,
		Nombres,
		Apellido,
		Sexo,
		Direccion,
		Ciudad,
		FechaNacimiento,
		Estado
		)
	values (
		@Cedula,
		@Nombres,
		@Apellidos,
		@Sexo,
		@Direccion,
		@Ciudad,
		@FechaNacimiento,
		@Estado
		)
	
	else

	UPDATE	tblUsuario set CantidadVisitas = CantidadVisitas + 1


RETURN 0


