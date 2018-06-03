CREATE TABLE dbo.UserTokens
	(
	Id int NOT NULL IDENTITY (1, 1),
	Name nchar(10) NULL,
	Token nchar(10) NULL
	)  ON [PRIMARY]
GO

CREATE UNIQUE NONCLUSTERED INDEX UQ_UserTokens_Name
ON dbo.UserTokens(Name)

CREATE UNIQUE NONCLUSTERED INDEX UQ_UserTokens_Token
ON dbo.UserTokens(Token)

INSERT INTO [dbo].[UserTokens]
           ([Name]
           ,[Token])
     VALUES
           ('abc'
           ,NULL)
GO
-- Success

INSERT INTO [dbo].[UserTokens]
           ([Name]
           ,[Token])
     VALUES
           ('def'
           ,NULL)
GO
-- Error: Cannot insert duplicate key row in object 'dbo.UserTokens' with unique index 'UQ_UserTokens_Token'. The duplicate key value is (<NULL>).
-- The statement has been terminated.

DROP INDEX dbo.UserTokens.UQ_UserTokens_Token
GO

CREATE UNIQUE NONCLUSTERED INDEX UQ_UserTokens_Token_NullAllowed
ON dbo.UserTokens(Token)
WHERE Token IS NOT NULL;


INSERT INTO [dbo].[UserTokens]
           ([Name]
           ,[Token])
     VALUES
           ('def'
           ,NULL)
GO
-- Success