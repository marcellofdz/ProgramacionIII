CREATE PROCEDURE [dbo].[registrar_citas]
	@Nombres nvarchar(150),
	@Apellidos nvarchar(150),
	@Cedula nvarchar(150),
	@FechaNacimiento nvarchar(150),
	@MatriculaCentro nvarchar(150),
	@NombreCentro nvarchar(150),
	@FechaCita nvarchar(150),
	@HoraCita nvarchar(150),
	@Estados nvarchar(150),
	@FaseVacunacion nvarchar(150)

AS
	IF NOT EXISTS ( select 1 from tblCita where Cedula = @Cedula )
	insert into tblCita(
		Cedula,
		Nombres,
		Apellido,
		FechaNacimiento,
		MatriculaCentro,
		NombreCentro,
		FechaCita,
		Horacita,
		Estado,
		FaseVacunacion
		)
	values (
		@Cedula,
		@Nombres,
		@Apellidos,
		@FechaNacimiento,
		@MatriculaCentro,
		@NombreCentro,
		@FechaCita,
		@HoraCita,
		@Estados,
		@FaseVacunacion
		)



RETURN 0



ALTER TABLE [dbo].[tblUsuario] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Cedula]          NVARCHAR(150)    NOT NULL,
    [Nombres]         NVARCHAR(150)    NOT NULL,
    [Apellido]        NVARCHAR(150)    NOT NULL,
    [Sexo]            NVARCHAR(150)    NOT NULL,
    [Direccion]       NVARCHAR(150)    NOT NULL,
    [Ciudad]          NVARCHAR(150)    NOT NULL,
    [FechaIngreso]    DATETIME       NOT NULL DEFAULT getdate(),
    [FechaNacimiento] NVARCHAR(150)    NOT NULL,
    [Estado]          NVARCHAR(150)    NULL,
    [CantidadVisitas] INT,
    PRIMARY KEY CLUSTERED ([Cedula] ASC)
)