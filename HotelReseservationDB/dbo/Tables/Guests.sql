CREATE TABLE [dbo].[Guests] (
    [Id]                     INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]              NVARCHAR (MAX) NOT NULL,
    [LastName]               NVARCHAR (MAX) NOT NULL,
    [Gender]                 NVARCHAR (MAX) NOT NULL,
    [DateOfBirth]            DATETIME2 (7)  NOT NULL,
    [ContactNumber]          NVARCHAR (MAX) NOT NULL,
    [Email]                  NVARCHAR (MAX) NOT NULL,
    [Address]                NVARCHAR (MAX) NOT NULL,
    [EmergencyContactName]   NVARCHAR (MAX) NOT NULL,
    [EmergencyContactNumber] NVARCHAR (MAX) NOT NULL,
    [IsActive]               BIT            NOT NULL,
    CONSTRAINT [PK_Guests] PRIMARY KEY CLUSTERED ([Id] ASC)
);