CREATE PROCEDURE [dbo].[registrar_empleado]
	@Matricula nvarchar(150),
	@Direccion nvarchar(150),
	@Ciudad nvarchar(150),
	@Estado nvarchar(150),
	@MatriculaCentro nvarchar(150),
	@NombreCentro nvarchar(150),
	@Cedula nvarchar(150),
	@Nombres nvarchar(150),
	@Apellidos nvarchar(150),
	@Sexo nvarchar(150),
	@FechaNacimiento nvarchar(150),
	@Puesto nvarchar(150),
	@Sueldo nvarchar(150)

AS
	IF EXISTS (select 1 from tblEmpleados WHERE Cedula = @Cedula)

	raiserror('YA EXISTE UN USUARIO CON ESE LOGIN O CON ESE ICONO, POR FAVOR INGRESE DE NUEVO',16,1 )
	
else

	insert into tblEmpleados
			(
			MatriculaCentro,
			Cedula,
			Nombres,
			Apellidos,
			Sexo,
			FechaNacimiento,
			Puesto,
			Sueldo,
			Estado
			)
	values (
			@MatriculaCentro,
			@Cedula,
			@Nombres,
			@Apellidos,
			@Sexo,
			@FechaNacimiento,
			@Puesto,
			@Sueldo,
			@Estado
			);


	insert into tblCentroVacunacion
			(
				Matricula,
				NombreCentro,
				Direccion,
				Ciudad,
				Estado
			)
	values (
		@Matricula,
		@NombreCentro,
		@Direccion,
		@Ciudad,
		@Estado	
		);

UPDATE tblCentroVacunacion set CantidadEmpleados = CantidadEmpleados + 1




RETURN 0



