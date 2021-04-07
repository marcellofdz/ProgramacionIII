CREATE PROCEDURE [dbo].[ppGetVacunasByCodigo]
	@CodigoBarras nvarchar(50)

AS
	SELECT * FROM tblUnidadesVacuna where CodigoBarras = @CodigoBarras

RETURN 0
