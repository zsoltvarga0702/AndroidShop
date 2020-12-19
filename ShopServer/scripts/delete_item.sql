IF OBJECT_ID('delete_item') IS NULL
BEGIN	
	EXEC ('CREATE PROCEDURE delete_item AS PRINT ''empty''')
END
GO

ALTER PROCEDURE delete_item
	@id INT
AS
BEGIN
	IF EXISTS (SELECT 1 FROM Items WHERE id = @id)
	BEGIN
		DELETE FROM Items WHERE id = @id
	END
	ELSE
		return -1

END
GO