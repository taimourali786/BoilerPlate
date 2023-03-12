CREATE TABLE [dbo].[User] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [FirstName] NVARCHAR (50)  NOT NULL,
    [LastName]  NVARCHAR (50)  NOT NULL,
    [Address]   NVARCHAR (200) NULL,
    [Phone]     NVARCHAR (20)  NULL,
    [Cnic]      NVARCHAR (20)  NULL,
    [AspNetId]  NVARCHAR (450) NOT NULL,
    [CityId]    INT            NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_User_AspNetUsers] FOREIGN KEY ([AspNetId]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_User_City] FOREIGN KEY ([CityId]) REFERENCES [dbo].[City] ([Id])
);

