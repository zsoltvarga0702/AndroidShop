IF OBJECT_ID('insert_item') IS NULL
BEGIN	
	EXEC ('CREATE PROCEDURE insert_item AS PRINT ''empty''')
END
GO

ALTER PROCEDURE insert_item
	@user_id INT,
	@address VARCHAR(100) ,
	@phone VARCHAR(20)  ,
	@description VARCHAR(1000) ,
	@title VARCHAR(30) ,
	@price VARCHAR(20) ,
	@img VARCHAR(max),
	@img1 VARCHAR(max),
	@img2 VARCHAR(max),
	@img3 VARCHAR(max),
	@img4 VARCHAR(max),
	@img5 VARCHAR(max)
AS
BEGIN
	IF NOT EXISTS (SELECT 1 FROM Users WHERE id = @user_id)
		RETURN -1
	
	INSERT INTO Items ([user_id], [address],phone,[description],title,price,img,img1,img2,img3,img4,img5) VALUES (@user_id,@address,@phone,@description,@title,@price,@img,@img1,@img2,@img3,@img4,@img5)
END
GO