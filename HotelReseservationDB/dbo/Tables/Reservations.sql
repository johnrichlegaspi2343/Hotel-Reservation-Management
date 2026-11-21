CREATE TABLE [dbo].[Reservations] (
    [Id]             INT             IDENTITY (1, 1) NOT NULL,
    [GuestId]        INT             NOT NULL,
    [RoomId]         INT             NOT NULL,
    [CheckInDate]    DATETIME2 (7)   NOT NULL,
    [CheckOutDate]   DATETIME2 (7)   NOT NULL,
    [RoomRate]       DECIMAL (10, 2) NOT NULL,
    [Status]         NVARCHAR (MAX)  NOT NULL,
    [ActualCheckIn]  DATETIME2 (7)   NULL,
    [ActualCheckOut] DATETIME2 (7)   NULL,
    CONSTRAINT [PK_Reservations] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Reservations_Guests_GuestId] FOREIGN KEY ([GuestId]) REFERENCES [dbo].[Guests] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Reservations_Rooms_RoomId] FOREIGN KEY ([RoomId]) REFERENCES [dbo].[Rooms] ([Id]) ON DELETE CASCADE
);
GO
CREATE NONCLUSTERED INDEX [IX_Reservations_GuestId] ON [dbo].[Reservations]([GuestId] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_Reservations_RoomId] ON [dbo].[Reservations]([RoomId] ASC);