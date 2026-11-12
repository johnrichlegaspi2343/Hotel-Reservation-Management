CREATE TABLE [dbo].[Rooms] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [RoomNumber] NVARCHAR (450) NOT NULL,
    [RoomTypeId] INT            NOT NULL,
    [Status]     NVARCHAR (MAX) NOT NULL,
    [IsActive]   BIT            NOT NULL,
    CONSTRAINT [PK_Rooms] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Rooms_RoomTypes_RoomTypeId] FOREIGN KEY ([RoomTypeId]) REFERENCES [dbo].[RoomTypes] ([Id]) ON DELETE CASCADE
);
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Rooms_RoomNumber] ON [dbo].[Rooms]([RoomNumber] ASC);