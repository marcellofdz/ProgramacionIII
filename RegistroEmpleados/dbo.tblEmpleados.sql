CREATE TABLE [dbo].[tblEmpleados] (
    [Id]              INT            DEFAULT ((1)) NOT NULL IDENTITY,
    [MatriculaCentro] NVARCHAR (150) NOT NULL,
    [Cedula]          NVARCHAR (150) NOT NULL,
    [Nombres]         NVARCHAR (150) NOT NULL,
    [Apellidos]       NVARCHAR (150) NOT NULL,
    [Sexo]            NVARCHAR (150) NOT NULL,
    [FechaNacimiento] NVARCHAR (150) NOT NULL,
    [Puesto]          NVARCHAR (150) NOT NULL,
    [Sueldo]          NVARCHAR (150) NOT NULL,
    [FechaIngreso]    DATETIME       DEFAULT (getdate()) NOT NULL,
    [Estado]          NVARCHAR (150) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

