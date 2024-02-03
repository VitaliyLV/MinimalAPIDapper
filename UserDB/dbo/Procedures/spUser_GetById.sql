CREATE PROCEDURE [dbo].[spUser_GetById]
	@id int = 0
AS
BEGIN
	SELECT Id, FirstName, LastName, Age 
	FROM [User] 
	WHERE Id = @id;
END
