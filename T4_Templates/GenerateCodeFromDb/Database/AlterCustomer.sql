ALTER TABLE [dbo].[Customer] ADD
    StreetAndNumber nvarchar(100)  NULL
GO

ALTER TABLE [dbo].[Customer] ADD
    ZipCode nvarchar(10)  NULL
GO

ALTER TABLE [dbo].[Customer] ADD
    City nvarchar(100)  NULL
GO

ALTER TABLE [dbo].[Customer] ADD
    State nvarchar(100)  NULL
GO

ALTER TABLE [dbo].[Customer] ADD
    CountryCode nvarchar(2)  NULL
GO