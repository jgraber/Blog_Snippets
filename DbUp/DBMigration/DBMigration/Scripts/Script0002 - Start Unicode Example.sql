CREATE TABLE UnicodeExample
(
	Id	    INT IDENTITY(1,1),
	German	NVARCHAR(255),
	French	NVARCHAR(255),
	Spanish	NVARCHAR(255),
	CONSTRAINT pk_UnicodeExample_Id PRIMARY KEY (Id),
);