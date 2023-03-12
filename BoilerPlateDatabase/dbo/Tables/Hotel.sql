CREATE TABLE [dbo].[Hotel] (
    [Id]      INT            IDENTITY (1, 1) NOT NULL,
    [Name]    NVARCHAR (50)  NOT NULL,
    [Address] NVARCHAR (200) NOT NULL,
    [Rating]  FLOAT (53)     NULL,
    [CityId]  INT            NOT NULL,
    CONSTRAINT [PK_Hotel] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Hotel_City] FOREIGN KEY ([CityId]) REFERENCES [dbo].[City] ([Id])
);

