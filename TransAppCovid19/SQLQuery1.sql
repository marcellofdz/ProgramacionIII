CREATE PROCEDURE [dbo].[registrar_vacuna]
	@CodigoBarra nvarchar(150),
	@Descripcion nvarchar(150),
	@Lote nvarchar(150),
	@Secuencia nvarchar(150),
	@Estado nvarchar(150),
	@CantidadGramos nvarchar(150),
	@Cedula nvarchar(150)
AS

if not exists (select 1 from tblUnidadesVacuna where CodigoBarras = @CodigoBarra)
	insert into
		tblUnidadesVacuna(CodigoBarras,Descripcion,Lote,Secuencia,Estado,CantidadGramos,Usuario)
		values (@CodigoBarra, @Descripcion, @Lote, @Secuencia,@Estado,@CantidadGramos,@Cedula)
else
	update tblVacunas set CantidadExistencia = CantidadExistencia + 1 where CodigoBarras = @CodigoBarra


RETURN 0


CREATE PROCEDURE [dbo].[unidad_vacuna]
	@CodigoBarra nvarchar(150),
	@Marca nvarchar(150),
	@Localidad nvarchar(150),
	@CantidadExistencia nvarchar(150),
	@CantidadReorden nvarchar(150),
	@Estado nvarchar(150)
AS

if not exists (select 1 from tblVacunas where CodigoBarras = @CodigoBarra)
	insert into
		tblVacunas (CodigoBarras, Marcas, Localidad, Estado)
		values (@CodigoBarra, @Marca, @Localidad, @Estado)
RETURN 0


select * from CovidDB.tblUnidadesVacuna