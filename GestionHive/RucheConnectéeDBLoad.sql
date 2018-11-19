--CREATE DATABASE HiveGestion
GO

USE HiveGestion

GO

--DROP TABLE Statistic
--DROP TABLE Location
--DROP TABLE FlowerType
--DROP TABLE [Weight]
--DROP TABLE Test
--DROP TABLE [Image]
--DROP TABLE Alert
--DROP TABLE Type_Alert
--DROP TABLE Hive
--DROP TABLE [User]

CREATE TABLE [User](
Id int IDENTITY (1,1),
[Login] varchar(50) UNIQUE NOT NULL,
Password varchar(max) NOT NULL,
Name varchar(50) NOT NULL,
Num_Tel int UNIQUE ,
Email varchar(50) UNIQUE NOT NULL ,
Active Bit NOT NULL,
Active_BeeKeeper Bit NOT NULL,
CONSTRAINT PK_User PRIMARY KEY (Id) 
)

CREATE TABLE Hive(
Id int IDENTITY (1,1),
Name varchar(50) NOT NULL,
[Description] varchar(max) NOT NULL,
Initial_Weight int NOT NULL,
Active bit NOT NULL,
Initial_Hive_Date DATETIME default GETDATE(), 
User_Id int,
CONSTRAINT FK_User_Id FOREIGN KEY (User_Id)
	REFERENCES [User](Id), 
CONSTRAINT PK_Hive PRIMARY KEY (Id)
)

CREATE TABLE Type_Alert (
Id int IDENTITY (1,1),
Description varchar(max),
CONSTRAINT PK_Type_Alert PRIMARY KEY (Id)
)

CREATE TABLE Alert(
Id int IDENTITY (1,1),
TimeStamp DATETIME DEFAULT GETDATE(),
Alert_Active bit NOT NULL,
Type_Alert_Id int,
Hive_Id int,
CONSTRAINT FK_Hive_Id FOREIGN KEY (Hive_Id)
	REFERENCES Hive(Id),
CONSTRAINT FK_Type_Alert_Id FOREIGN KEY (Type_Alert_Id)
	REFERENCES Type_Alert (Id),
CONSTRAINT PK_Alert PRIMARY KEY (Id)
)

CREATE TABLE [Image](
Id int IDENTITY (1,1),
Result bit NOT NULL,
TimeStamp DATETIME DEFAULT GETDATE(),
User_Id int , 
Hive_Id int,
CONSTRAINT FK_User_Image FOREIGN KEY(User_Id)
	REFERENCES [User](Id),
CONSTRAINT FK_Hive_Image FOREIGN KEY (Hive_Id)
	REFERENCES Hive(Id),
CONSTRAINT PK_Image PRIMARY KEY (Id)   
)

CREATE TABLE Test (
Id int IDENTITY (1,1),
Result bit NOT NULL,
User_Id int, 
Image_Id int, 
CONSTRAINT FK_User_Test FOREIGN KEY (User_Id)
	REFERENCES [User](Id),
CONSTRAINT FK_Image_Test FOREIGN KEY (Image_Id)
	REFERENCES Image (Id),
CONSTRAINT PK_Test PRIMARY KEY (Id)
)

CREATE TABLE [Weight] (
Id int IDENTITY (1,1) PRIMARY KEY,
TimeStamp DATETIME DEFAULT GETDATE(),
Weight int NOT NULL,
Hive_id int,
CONSTRAINT FK_Hive_Weight FOREIGN KEY (Hive_Id)
	REFERENCES Hive(Id)
)

CREATE TABLE FlowerType(
Id int IDENTITY (1,1) PRIMARY KEY,
Flower_Type varchar(50) NOT NULL,
)

CREATE TABLE Location (
Id int IDENTITY (1,1) PRIMARY KEY,
TimeStamp DATETIME DEFAULT GETDATE(),
Latitude int NOT NULL , 
Longitude int NOT NULL,
Orientation varchar(5),
Nectar_Type varchar(20),
Zone_Name varchar(50),
Hive_id int,
FlowerType_Id int,
CONSTRAINT FK_FlowerType_Location FOREIGN KEY (FlowerType_Id)
	REFERENCES FlowerType (Id),
CONSTRAINT FK_Hive_Location FOREIGN KEY (Hive_Id)
	REFERENCES Hive(Id)
)

CREATE TABLE Statistic (
Id int IDENTITY (1,1) PRIMARY KEY,
TimeStamp DATETIME DEFAULT GETDATE(),
Temperature int NOT NULL,
Humidity int NOT NULL,
Air_Quality int NOT NULL,
Hive_id int,
CONSTRAINT FK_Hive_Stat FOREIGN KEY (Hive_Id)
	REFERENCES Hive(Id)
)