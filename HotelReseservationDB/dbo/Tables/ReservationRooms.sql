CREATE TABLE [dbo].[ReservationRooms] (
    [Id]            INT             IDENTITY (1, 1) NOT NULL,
    [ReservationId] INT             NOT NULL,
    [RoomId]        INT             NOT NULL,
    [RoomRate]      DECIMAL (10, 2) NOT NULL,
    CONSTRAINT [PK_ReservationRooms] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ReservationRooms_Reservations_ReservationId] FOREIGN KEY ([ReservationId]) REFERENCES [dbo].[Reservations] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ReservationRooms_Rooms_RoomId] FOREIGN KEY ([RoomId]) REFERENCES [dbo].[Rooms] ([Id])
);
GO
CREATE NONCLUSTERED INDEX [IX_ReservationRooms_ReservationId] ON [dbo].[ReservationRooms]([ReservationId] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_ReservationRooms_RoomId] ON [dbo].[ReservationRooms]([RoomId] ASC);