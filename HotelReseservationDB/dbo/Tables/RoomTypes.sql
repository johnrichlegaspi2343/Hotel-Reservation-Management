CREATE TABLE [dbo].[RoomTypes] (
    [Id]   INT             IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX)  NOT NULL,
    [Rate] DECIMAL (10, 2) NOT NULL,
    CONSTRAINT [PK_RoomTypes] PRIMARY KEY CLUSTERED ([Id] ASC)
);