select * from tblPaciente
select * from tblVacuna

delete from tblPaciente
delete from tblVacuna

CREATE TABLE [dbo].[tblPaciente] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Cedula]          NVARCHAR(150)    NOT NULL,
    [Nombres]   NVARCHAR(150)    NOT NULL,
    [Apellido] NVARCHAR(150)    NOT NULL,
    [FechaIngreso]    DATETIME       NOT NULL DEFAULT getdate(),
    [FechaNacimiento] NVARCHAR(150)    NOT NULL,
    [Estado]          NVARCHAR(150)    NULL,
    PRIMARY KEY CLUSTERED ([Cedula] ASC)
)

CREATE TABLE [dbo].[tblPaciente] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Cedula]          NVARCHAR (150) NOT NULL,
    [Nombres]         NVARCHAR (150) NOT NULL,
    [Apellido]        NVARCHAR (150) NOT NULL,
    [TipoVacuna]      NVARCHAR (150) NOT NULL,
    [FechaIngreso]    DATETIME       DEFAULT (getdate()) NOT NULL,
    [FechaNacimiento] NVARCHAR (150) NOT NULL,
    [Estado]          NVARCHAR (150) NULL,
    PRIMARY KEY CLUSTERED ([Cedula] ASC)
);
 