IF OBJECT_ID('update_user') IS NULL
BEGIN	
	EXEC ('CREATE PROCEDURE update_user AS PRINT ''empty''')
END
GO

ALTER PROCEDURE update_user
	@id INT,
	@name VARCHAR(300),
	@email VARCHAR(30),
	@password VARCHAR(100)
AS
BEGIN
	IF NOT EXISTS (SELECT 1 FROM Users WHERE id = @id)
		RETURN -1
	IF EXISTS (SELECT 1 FROM Users WHERE email = @email AND id <> @id)
		RETURN -2
	ELSE
		UPDATE Users SET [name] = @name, email = @email,[password] = @password WHERE id = @id

END
GO