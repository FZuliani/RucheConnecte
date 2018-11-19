USE BeeGestion
GO


/*Creation procedure insert*/

CREATE Procedure PR_InsertUser
@Login VARCHAR(75),
@Name VARCHAR(75),
@Email varchar(50),
@Passwd varchar(64),
@Active bit,
@Active_BK bit
As
Begin
	insert into [User]([Login], Name, Email, [Password], Active, Active_BeeKeeper) values (@Login, @Name, @Email, HASHBYTES('SHA2_512', @Passwd), @Active, @Active_BK);
End

GO

GO
CREATE Procedure PR_InsertTypeA
@Description varchar(MAX)
As
Begin
	insert into Type_Alert([Description]) values (@Description)
END

GO

CREATE Procedure PR_InsertWeight
@TimeStamp datetime,
@Weigth int,
@hive_id int
As
BEGIN
	insert into [Weight]([TimeStamp], [Weight], Hive_id) values (@TimeStamp, @Weigth, @hive_id)
END

GO

CREATE Procedure PR_InsertTest
@Result bit,
@User_id int,
@Image_id int
AS
BEGIN
	insert into Test(Result, [User_Id], [Image_Id]) values (@Result, @User_id, @Image_id)
END

GO

CREATE Procedure PR_InsertStat
@Timestamp datetime,
@Temperature int,
@Humidity int,
@Air_Quality int,
@Hive_id int
AS
BEGIN
	insert into Statistic([TimeStamp], Temperature, Humidity, Air_Quality, Hive_id) values (@Timestamp, @Temperature, @Humidity, @Air_Quality, @Hive_id)
END

GO

CREATE Procedure PR_InsertLocation
@TimeStamp int,
@Latitude int,
@Longitude int,
@Hive_id int
AS
BEGIN
	insert into Location([TimeStamp], Latitude, Longitude, Hive_id) values (@TimeStamp, @Latitude, @Longitude, @Hive_id)
END


GO

CREATE Procedure PR_InsertImage
@Result bit,
@TimeStamp datetime,
@User_id int,
@Hive_id int
AS
BEGIN
	insert into [Image] (Result, [TimeStamp], [User_Id],Hive_Id) values (@Result, @TimeStamp, @User_id, @Hive_id)
END

GO

CREATE Procedure PR_InsertHive
@Name varchar(50),
@Description varchar(MAX),
@Initial_Wieght int,
@Active bit,
@User_id int
AS
BEGIN
	insert into Hive (Name, [Description], Initial_Weight, Active, [User_Id]) values (@Name, @Description, @Initial_Wieght, @Active, @User_id)
END

GO

CREATE Procedure PR_InsertAlert
@TimeStamp datetime,
@Alert_Active bit,
@Type_Alert int,
@Hive_id int
AS
BEGIN
	insert into Alert([TimeStamp], Alert_Active, Type_Alert_Id, Hive_Id) values (@TimeStamp, @Alert_Active, @Type_Alert, @Hive_id)
END

GO

-- à exécuté

CREATE Procedure PR_InsertFlower
@FlowerT varchar(50)
AS
BEGIN

	insert into FlowerType(Flower_Type) values (@FlowerT)

END

GO


/*Création procedure Delete*/

CREATE Procedure PR_DelWeight
@id int
AS 
BEGIN
	DELETE FROM [Weight] WHERE Id = @id
END

GO
CREATE Procedure PR_DelUser
@id int
AS 
BEGIN
	DELETE FROM [User] WHERE Id = @id
END

GO

CREATE Procedure PR_DelTypeAlert
@id int
AS 
BEGIN
	DELETE FROM Type_Alert WHERE Id = @id
END

GO
CREATE Procedure PR_DelTest
@id int
AS 
BEGIN
	DELETE FROM Test WHERE Id = @id
END

GO
CREATE Procedure PR_DelStat
@id int
AS 
BEGIN
	DELETE FROM Statistic WHERE Id = @id
END

GO


CREATE Procedure PR_DelFlower
@id int
AS
BEGIN

	DELETE FROM FlowerType WHERE id = @id

END

GO
CREATE Procedure PR_DelLocation
@id int
AS 
BEGIN
	DELETE FROM Location WHERE Id = @id
END

GO

CREATE Procedure PR_DelImage
@id int
AS 
BEGIN
	DELETE FROM [Image] WHERE Id = @id
END

GO

CREATE Procedure PR_DelHive
@id int
AS 
BEGIN
	DELETE FROM [Hive] WHERE Id = @id
END

GO

CREATE Procedure PR_DelAlert
@id int
AS 
BEGIN
	DELETE FROM Alert WHERE Id = @id
END

GO


/*Create procedure Update*/


CREATE Procedure PR_UpdateWieght
@Id int,
@Column varchar(max),
@var_modif varchar(max)
AS
BEGIN

	IF (@Column IN ('Wieght', 'Hive_id'))
		BEGIN
		
			SET @var_modif = CONVERT(int, @var_modif)
		END
	IF(@Column LIKE 'Wieght')
		BEGIN

		UPDATE [Weight]
		SET [Weight] = @var_modif
		WHERE Id = @Id

		END
	IF(@Column LIKE 'Hive_id')
		BEGIN

		UPDATE [Weight]
		SET Hive_id = @var_modif
		WHERE Id = @Id

		END
	IF(@Column LIKE 'TimeStamp')
		BEGIN

		UPDATE [Weight]
		SET [TimeStamp] = @var_modif
		WHERE Id = @Id

		END
	ELSE
	BEGIN
		RAISERROR ('Les paramètres de la procédure sont incorrecte', 16, 1)
		ROLLBACK TRANSACTION 
	END
END

Go

CREATE Procedure PR_UpdateUser
@Id int,
@Column varchar(max),
@var_modif varchar(max)
AS
BEGIN

	IF(@Column LIKE ('Num_Tel'))
	BEGIN
		SET @var_modif = CONVERT(int, @var_modif)
	END
	IF (@Column IN ('Active', 'Active_BeeKeeper'))
	BEGIN
		SET @var_modif = CONVERT (bit, @var_modif)
	END

	IF(@Column LIKE 'Login')
	BEGIN
		
		UPDATE [User]
		SET [login] = @var_modif
		WHERE Id = @Id

	END

	IF(@Column LIKE 'Password')
	BEGIN
		
		UPDATE [User]
		SET [Password] = @var_modif
		WHERE Id = @Id

	END
	
	IF(@Column LIKE 'Name')
	BEGIN
		
		UPDATE [User]
		SET Name = @var_modif
		WHERE Id = @Id

	END

	IF(@Column LIKE 'Num_Tel')
	BEGIN
		
		UPDATE [User]
		SET Num_Tel = @var_modif
		WHERE Id = @Id

	END

	IF(@Column LIKE 'Email')
	BEGIN
		
		UPDATE [User]
		SET Email = @var_modif
		WHERE Id = @Id

	END

	IF(@Column LIKE 'Active')
	BEGIN
		
		UPDATE [User]
		SET Active = @var_modif
		WHERE Id = @Id

	END

	IF(@Column LIKE 'Active_BeeKeeper')
	BEGIN
		
		UPDATE [User]
		SET Active_BeeKeeper = @var_modif
		WHERE Id = @Id

	END

	ELSE
	BEGIN

		RAISERROR ('Les paramètres ne sont pas correcte', 16, 1)
		ROLLBACK TRANSACTION

	END

END


GO


CREATE Procedure PR_UpdateTypeA
@Id int,
@var_modif varchar(max)
AS
BEGIN

	UPDATE Type_Alert
	SET [Description] = @var_modif
	WHERE Id = @Id

END

GO

CREATE Procedure PR_UpdateTest
@Id int,
@Column varchar(max),
@var_modif varchar(max)
AS
BEGIN

	IF (@Column LIKE 'Result')
	BEGIN
		SET @var_modif = CONVERT (bit, @var_modif)
	END

	IF (@Column IN ('User_Id', 'Image_Id'))
	BEGIN
		set @var_modif = CONVERT (int, @var_modif)
	END

	IF (@Column LIKE 'Result')
	BEGIN

		UPDATE Test
		SET Result = @var_modif
		WHERE Id = @Id
		
	END

	IF (@Column LIKE 'User_Id')
	BEGIN
		
		UPDATE Test
		SET [User_Id] = @var_modif
		WHERE Id = @Id

	END

	IF (@Column LIKE 'Image_Id')
	BEGIN

		UPDATE Test
		SET Image_Id = @var_modif
		WHERE Id = @Id

	END

	ELSE
	BEGIN

		RAISERROR ('Les paramètres ne sont pas correcte', 16, 1)
		ROLLBACK TRANSACTION

	END


END

GO

CREATE Procedure PR_UpdateStat
@Id int,
@Column varchar(max),
@var_modif varchar(max)
AS
BEGIN

	IF (@Column IN ('Air_Quality', 'Humidity', 'Temperature', 'Hive_id'))
	BEGIN
		set @var_modif = CONVERT (int, @var_modif)
	END

	IF (@Column LIKE 'TimeStamp')
	BEGIN

		UPDATE Statistic
		SET [TimeStamp] = @var_modif
		WHERE Id = @Id

	END

	IF (@Column LIKE 'Temperature')
	BEGIN

		UPDATE Statistic
		SET Temperature = @var_modif
		WHERE Id = @Id

	END

	IF (@Column LIKE 'Humidity')
	BEGIN

		UPDATE Statistic
		SET Humidity = @var_modif
		WHERE Id = @Id

	END

	IF (@Column LIKE 'Air_Quality')
	BEGIN

		UPDATE Statistic
		SET Air_Quality = @var_modif
		WHERE Id = @Id

	END

	IF (@Column LIKE 'Hive_id')
	BEGIN

		UPDATE Statistic
		SET Hive_id = @var_modif
		WHERE Id = @Id

	END

	
	ELSE
	BEGIN

		RAISERROR ('Les paramètres ne sont pas correcte', 16, 1)
		ROLLBACK TRANSACTION

	END


END

/*à exécuter*/
GO

CREATE Procedure PR_UpdateFlower
@id int,
@var_modif varchar(50)
AS
BEGIN

	UPDATE Flower
	SET Flower_Type = @var_modif
	WHERE Id = @Id

END

GO

CREATE Procedure PR_UpdateLocation
@Id int,
@Column varchar(max),
@var_modif varchar(max)
AS
BEGIN

	IF(@Column IN('Latitude', 'Longitude', 'Hive_id'))
	BEGIN
		SET @var_modif = CONVERT(int, @var_modif)
	END

	IF (@Column LIKE 'TimeStamp')
	BEGIN

		UPDATE Location
		SET TimeStamp = @var_modif
		WHERE Id = @Id

	END

	IF (@Column LIKE 'Latitude')
	BEGIN

		UPDATE Location
		SET Latitude = @var_modif
		WHERE Id = @Id

	END

	IF (@Column LIKE 'Longitude')
	BEGIN

		UPDATE Location
		SET Longitude = @var_modif
		WHERE Id = @Id

	END

	IF (@Column LIKE 'Hive_id')
	BEGIN

		UPDATE Location
		SET Hive_id = @var_modif
		WHERE Id = @Id

	END
	
	ELSE
	BEGIN

		RAISERROR ('Les paramètres ne sont pas correcte', 16, 1)
		ROLLBACK TRANSACTION

	END

END

Go

CREATE Procedure PR_UpdateImage
@Id int,
@Column varchar(max),
@var_modif varchar(max)
AS
BEGIN

	IF(@Column IN ('User_Id', 'Hive_Id'))
	BEGIN
		SET @var_modif = CONVERT (int, @var_modif)
	END

	IF (@Column LIKE 'Result')
	BEGIN

		UPDATE [Image]
		SET Result = @var_modif
		WHERE Id = @Id

	END

	IF (@Column LIKE 'TimeStamp')
	BEGIN

		UPDATE [Image]
		SET [TimeStamp] = @var_modif
		WHERE Id = @Id

	END

	IF (@Column LIKE 'User_Id')
	BEGIN

		UPDATE [Image]
		SET [User_Id] = @var_modif
		WHERE Id = @Id

	END

	IF (@Column LIKE 'Hive_Id')
	BEGIN

		UPDATE [Image]
		SET Hive_Id = @var_modif
		WHERE Id = @Id

	END

	ELSE
	BEGIN

		RAISERROR ('Les paramètres ne sont pas correcte', 16, 1)
		ROLLBACK TRANSACTION

	END

END



Go

CREATE Procedure PR_UpdateHive
@Id int,
@Column varchar(max),
@var_modif varchar(max)
AS
BEGIN

	IF(@Column IN ('Initial_Weight', 'User_Id'))
	BEGIN
		SET @var_modif = CONVERT (int, @var_modif)
	END

	IF(@Column IN ('Active'))
	BEGIN
		SET @var_modif = CONVERT (bit, @var_modif)
	END


	IF (@Column LIKE 'Name')
	BEGIN

		UPDATE Hive
		SET Name = @var_modif
		WHERE Id = @Id

	END

	IF (@Column LIKE 'Description')
	BEGIN

		UPDATE Hive
		SET [Description] = @var_modif
		WHERE Id = @Id

	END


	IF (@Column LIKE 'Initial_Weight')
	BEGIN

		UPDATE Hive
		SET Initial_Weight = @var_modif
		WHERE Id = @Id

	END

	IF (@Column LIKE 'Active')
	BEGIN

		UPDATE Hive
		SET Active = @var_modif
		WHERE Id = @Id

	END

	ELSE
	BEGIN

		RAISERROR ('Les paramètres ne sont pas correcte', 16, 1)
		ROLLBACK TRANSACTION

	END

END


GO


CREATE Procedure PR_UpdateAlert
@Id int,
@Column varchar(max),
@var_modif varchar(max)
AS
BEGIN

	IF(@Column IN ('Alert_Active'))
	BEGIN
		SET @var_modif = CONVERT (bit, @var_modif)
	END

	IF(@Column IN ('Type_Alert_Id', 'Hive_Id'))
	BEGIN
		SET @var_modif = CONVERT (int, @var_modif)
	END

	IF (@Column LIKE 'TimeStamp')
	BEGIN

		UPDATE Alert
		SET [TimeStamp] = @var_modif
		WHERE Id = @Id

	END

	IF (@Column LIKE 'Alert_Active')
	BEGIN

		UPDATE Alert
		SET [Alert_Active] = @var_modif
		WHERE Id = @Id

	END

	IF (@Column LIKE 'Type_Alert_Id')
	BEGIN

		UPDATE Alert
		SET Type_Alert_Id = @var_modif
		WHERE Id = @Id

	END

	IF (@Column LIKE 'Hive_Id')
	BEGIN

		UPDATE Alert
		SET Hive_Id = @var_modif
		WHERE Id = @Id

	END
	
	ELSE
	BEGIN

		RAISERROR ('Les paramètres ne sont pas correcte', 16, 1)
		ROLLBACK TRANSACTION

	END

END
