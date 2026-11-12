CREATE TABLE [dbo].[Payments] (
    [Id]            INT             IDENTITY (1, 1) NOT NULL,
    [ReservationId] INT             NOT NULL,
    [Amount]        DECIMAL (10, 2) NOT NULL,
    [PaymentMethod] NVARCHAR (MAX)  NOT NULL,
    [PaymentDate]   DATETIME2 (7)   NOT NULL,
    [ProcessedBy]   NVARCHAR (MAX)  NOT NULL,
    CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Payments_Reservations_ReservationId] FOREIGN KEY ([ReservationId]) REFERENCES [dbo].[Reservations] ([Id]) ON DELETE CASCADE
);
GO
CREATE NONCLUSTERED INDEX [IX_Payments_ReservationId] ON [dbo].[Payments]([ReservationId] ASC);