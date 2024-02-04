CREATE PROCEDURE [dbo].[spUser_Update]
	@Id int,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Age int NULL
AS
BEGIN
	UPDATE [User] 
	SET FirstName = @FirstName, LastName = @LastName, Age = @Age 
	WHERE Id=@Id;
END
