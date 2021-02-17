CREATE PROCEDURE [dbo].[insertar_paciente]
	@Nombres nvarchar = 150,
	@Apellidos nvarchar = 150,
	@Cedula nvarchar = 150,
	@FechaNacimiento nvarchar = 150,
	@Estado nvarchar = 150
AS

if not exists (select 1 from tblPaciente where Cedula = @Cedula)
	insert into
		tblPaciente(Nombres,Apellido,Cedula)
		values (@Nombres, @Apellidos, @Cedula)

RETURN 0

