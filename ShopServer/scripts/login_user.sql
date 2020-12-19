IF OBJECT_ID('login_user') IS NULL
BEGIN	
	EXEC ('CREATE PROCEDURE login_user AS PRINT ''empty''')
END
GO

ALTER PROCEDURE login_user
	@email VARCHAR(30),
	@password VARCHAR(100)
AS
BEGIN
	IF NOT EXISTS (SELECT 1 FROM Users WHERE email = @email AND [password] = @password)
		RETURN -1
END
GO