CREATE PROCEDURE [dbo].[spUser_DeleteById]
	@id int = 0
AS
BEGIN
	DELETE
	FROM [User] 
	WHERE Id = @id;
END
