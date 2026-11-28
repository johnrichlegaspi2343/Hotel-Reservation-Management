CREATE TABLE [dbo].[Charges] (
    [Id]            INT             IDENTITY (1, 1) NOT NULL,
    [ReservationId] INT             NOT NULL,
    [Description]   NVARCHAR (MAX)  NOT NULL,
    [Amount]        DECIMAL (10, 2) NOT NULL,
    [DateAdded]     DATETIME2 (7)   NOT NULL,
    [AddedBy]       NVARCHAR (MAX)  NOT NULL,
    CONSTRAINT [PK_Charges] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Charges_Reservations_ReservationId] FOREIGN KEY ([ReservationId]) REFERENCES [dbo].[Reservations] ([Id]) ON DELETE CASCADE
);
GO
CREATE NONCLUSTERED INDEX [IX_Charges_ReservationId] ON [dbo].[Charges]([ReservationId] ASC);