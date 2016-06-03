
ALTER DATABASE YOUR_DB_NAME 
SET RECOVERY SIMPLE;
GO
-- Shrink the truncated log file to 1 MB.
-- File's name, not name property of file
DBCC SHRINKFILE (YOUR_DB_NAME_log, 1);
GO
-- Reset the database recovery model.
ALTER DATABASE YOUR_DB_NAME
SET RECOVERY FULL;
GO
