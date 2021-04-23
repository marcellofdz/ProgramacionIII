CREATE PROCEDURE [dbo].[guardarOrden]
   @OrderID          NVARCHAR (50),
   @OrderDescription NVARCHAR (50),
   @CustomerID       NVARCHAR (50),
   @CustomerName     NVARCHAR (50),
   @OrderAmount      NVARCHAR (50)
As
	insert into
	tblOrden(OrderID, OrderDescription, CustomerID, CustomerName, OrderAmount)
	values (@OrderID, @OrderDescription, @CustomerID, @CustomerName, @OrderAmount)
RETURN 0


select * from tblOrden