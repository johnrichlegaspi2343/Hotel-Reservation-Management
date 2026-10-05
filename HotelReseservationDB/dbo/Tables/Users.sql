CREATE TABLE [dbo].[Users] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Username] NVARCHAR (450) NOT NULL,
    [Password] NVARCHAR (MAX) NOT NULL,
    [Role]     NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users_Username]
    ON [dbo].[Users]([Username] ASC);

