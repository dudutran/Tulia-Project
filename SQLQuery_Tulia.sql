

Create Table Users (
	Id int Primary Key IDENTITY(1,1),
	FirstName varchar(50) not null,
	LastName varchar(50) not null,
    Username varchar(50) not null,
	Password varchar(100) not null,
    Role varchar(50) not null,
    NumberGroups int 
);
Create Table Posts (
	Id int Primary Key IDENTITY(1,1),
	UserId int FOREIGN KEY REFERENCES Users(Id) on DELETE CASCADE not null,
    Title VARCHAR(100) not null,
    Body VARCHAR(max) not null,
    CreatedTime DATETIME not null,
);
Create Table Comments (
    Id int Primary Key IDENTITY(1,1),
    UserId int FOREIGN KEY REFERENCES Users(Id) on DELETE CASCADE not null,
    PostId int FOREIGN KEY REFERENCES Posts(Id) on DELETE NO ACTION not null,
    Content VARCHAR(500)not null,
    Time DATETIME not null
);
Create Table Groups (
    Id int Primary Key IDENTITY(1,1),
    UserId int FOREIGN KEY REFERENCES Users(Id) on DELETE CASCADE not null,
    NumberMember int,
    GroupTitle VARCHAR(100) not null,
    Description VARCHAR(max) not null
);
Create Table Membership (
    Id int Primary Key IDENTITY(1,1),
    UserId int FOREIGN KEY REFERENCES Users(Id) on DELETE CASCADE not null,
    GroupId int FOREIGN Key REFERENCES Groups(Id) on DELETE NO ACTION not null
);
CREATE Table Reports(
    Id int Primary Key IDENTITY(1,1),
    UserId int FOREIGN KEY REFERENCES Users(Id) on DELETE CASCADE not null,
    PostId int FOREIGN KEY REFERENCES Posts(Id) on DELETE NO ACTION not null,
    Type VARCHAR(100) not null,
    ReportContent VARCHAR(max) not null
);

SELECT * FROM Users;
SELECT * FROM Posts;
SELECT * FROM Comments;
SELECT * FROM Groups; 
SELECT * FROM Membership;
SELECT * FROM Reports;

Alter TABLE Posts
Add GroupId int FOREIGN KEY REFERENCES Groups(Id) on DELETE No ACTION not null;

