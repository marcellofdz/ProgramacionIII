CREATE TABLE [dbo].[tblUsuario] (
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

CREATE TABLE [dbo].[tblCita] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Cedula]          NVARCHAR(150)    NOT NULL,
    [Nombres]         NVARCHAR(150)    NOT NULL,
    [Apellido]        NVARCHAR(150)    NOT NULL,
    [FechaIngreso]    DATETIME       NOT NULL DEFAULT getdate(),
    [FechaNacimiento] NVARCHAR(150)    NOT NULL,
    [MatriculaCentro]            NVARCHAR(150)    NOT NULL,
    [NombreCentro]       NVARCHAR(150)    NOT NULL,
    [FechaCita]          NVARCHAR(150)    NOT NULL,
    [Horacita]          NVARCHAR(150)    NOT NULL,
    [Estado]          NVARCHAR(150)    NULL,
    [FaseVacunacion] INT    NOT NULL,
    PRIMARY KEY CLUSTERED ([Cedula] ASC)
)