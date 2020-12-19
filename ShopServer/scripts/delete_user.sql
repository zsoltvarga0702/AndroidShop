IF OBJECT_ID('delete_user') IS NULL
BEGIN	
	EXEC ('CREATE PROCEDURE delete_user AS PRINT ''empty''')
END
GO

ALTER PROCEDURE delete_user
	@id INT
AS
BEGIN
	IF EXISTS (SELECT 1 FROM Users WHERE id = @id)
	BEGIN
		DELETE FROM Items WHERE [user_id] = @id        -- Delete all treatments of deleted patient first, because of the foreign key constraint on patient_id
		DELETE FROM Users WHERE id = @id
	END
	ELSE
		return -1

END
GO