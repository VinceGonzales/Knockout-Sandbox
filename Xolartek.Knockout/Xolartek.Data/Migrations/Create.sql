-- Declare variables for database name, username and password
DECLARE @dbName nvarchar(max),
      @dbUser nvarchar(max),
      @dbPwd nvarchar(max),
	  @sql nvarchar(max);

-- Set variables for database name, username and password
SET @dbName = 'XolartekDb';
SET @dbUser = 'artdiarrhea';
SET @dbPwd = 'password';
SET @sql = 'USE MASTER';

EXEC (@sql)

IF (NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE ('[' + name + ']' = @dbName OR name = @dbName)))
BEGIN
	print 'database not exist';
	SELECT @sql = 'CREATE DATABASE '+ quotename(@DBNAME)
	EXEC (@sql)
END

DECLARE @cmd nvarchar(max)

-- Create login
IF( SUSER_SID(@dbUser) is null )
BEGIN
    print '-- Creating login '
    SET @cmd = N'CREATE LOGIN ' + quotename(@dbUser) + N' WITH PASSWORD ='''+ replace(@dbPwd, '''', '''''') + N''''
    EXEC(@cmd)
END

-- Create database user and map to login
-- and add user to the datareader, datawriter, ddladmin and securityadmin roles
--
SET @cmd = N'USE ' + quotename(@DBName) + N';
IF( NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = ''' + replace(@dbUser, '''', '''''') + N'''))
BEGIN
    print ''-- Creating user'';
    CREATE USER ' + quotename(@dbUser) + N' FOR LOGIN ' + quotename(@dbUser) + N';
    print ''-- Adding user'';
    EXEC sp_addrolemember ''db_owner'', ''' + replace(@dbUser, '''', '''''') + N''';
END'
EXEC(@cmd)
GO
