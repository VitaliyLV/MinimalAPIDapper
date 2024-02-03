CREATE PROCEDURE [dbo].[spUser_Insert]
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Age int NULL
AS
BEGIN
	INSERT INTO [User] (FirstName, LastName, Age) 
	VALUES (@FirstName, @LastName, @Age);
END
