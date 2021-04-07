CREATE PROCEDURE [dbo].[ppGetVacunasByCodigo]
	@CodigoBarras nvarchar(50)

AS
	SELECT * FROM tblVacunas where CodigoBarras = 001

RETURN 0