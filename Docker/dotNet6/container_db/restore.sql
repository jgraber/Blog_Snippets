USE [master]
GO

CREATE DATABASE [AdventureWorks2019]
GO

RESTORE DATABASE [AdventureWorks2019] 
FROM  DISK = N'/var/opt/mssql/data/AdventureWorks2019.bak' 
WITH   
MOVE N'AdventureWorks2017' TO N'/var/opt/mssql/data/AdventureWorks2019.mdf',  
MOVE N'AdventureWorks2017_log' TO N'/var/opt/mssql/data/AdventureWorks2019_log.ldf',  
NOUNLOAD,  REPLACE,  STATS = 5

GO

