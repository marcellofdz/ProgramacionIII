CREATE TABLE [dbo].[tblOrden] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [OrderID]          NVARCHAR (150) NOT NULL,
    [OrderDescription] NVARCHAR (150) NOT NULL,
    [CustomerID]       NVARCHAR (150) NOT NULL,
    [CustomerName]     NVARCHAR (150) NOT NULL,
    [OrderAmount]      NVARCHAR (150) NOT NULL,
    [FechaIngreso]     NVARCHAR (150) DEFAULT (getdate()) NOT NULL,
    [Estado]           NCHAR (100)    NULL,
    PRIMARY KEY CLUSTERED ([OrderID] ASC)
);