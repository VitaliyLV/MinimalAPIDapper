if not exists (select 1 from dbo.[User])
begin
	insert into dbo.[User] (FirstName, LastName, Age) 
	values ('Tom', 'Dou', 5),
	('Jerry', 'Dou', 2),
	('Jane', 'Smith', 20),
	('Joe', 'Black', 24)
end