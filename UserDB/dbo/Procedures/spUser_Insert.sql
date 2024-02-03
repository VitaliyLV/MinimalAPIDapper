CREATE PROCEDURE [dbo].[spUser_Insert]
	@FName nvarchar(50),
	@LName nvarchar(50),
	@Age int NULL
AS
BEGIN
	INSERT INTO [User] (FirstName, LastName, Age) 
	VALUES (@FName, @LName, @Age);
END
