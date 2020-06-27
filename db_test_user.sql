-- Db name: db_test_user

CREATE TABLE UserType(
	Id INT PRIMARY KEY IDENTITY (1, 1),
	Description VARCHAR(60),
	Active BIT
);
GO

CREATE TABLE Profile(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	Description VARCHAR(60),
	Active BIT
)

CREATE TABLE Users(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	UserTypeId INT,
	ProfileId INT,
	FirstName VARCHAR(100),
	LastName VARCHAR(100),
	Email  VARCHAR(100),
	UserName  VARCHAR(100),
	Password  VARCHAR(500),
	Active BIT,
	Date DATETIME,
	
	CONSTRAINT fk_Users_UserType FOREIGN KEY(UserTypeId) REFERENCES UserType(Id),
	CONSTRAINT fk_Users_Profile FOREIGN KEY(ProfileId) REFERENCES Profile(Id)
)


