CREATE PROCEDURE [dbo].[spUser_Update]
	@Id int,
	@FName nvarchar(50),
	@LName nvarchar(50),
	@Age int NULL
AS
BEGIN
	UPDATE [User] 
	SET FirstName = @FName, LastName = @LName, Age = @Age 
	WHERE Id=@Id;
END
