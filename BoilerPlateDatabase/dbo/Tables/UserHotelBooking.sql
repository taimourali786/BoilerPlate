CREATE TABLE [dbo].[UserHotelBooking] (
    [Id]        INT      IDENTITY (1, 1) NOT NULL,
    [UserId]    INT      NOT NULL,
    [HotelId]   INT      NOT NULL,
    [StartTime] DATETIME NOT NULL,
    [EndTime]   DATETIME NOT NULL,
    CONSTRAINT [PK_UserHotelBooking] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserHotelBooking_Hotel] FOREIGN KEY ([HotelId]) REFERENCES [dbo].[Hotel] ([Id]),
    CONSTRAINT [FK_UserHotelBooking_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

