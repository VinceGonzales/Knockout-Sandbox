USE [XolartekDb]
GO
CREATE PROCEDURE InsertSkill
@Name NVARCHAR(MAX),
@Description NVARCHAR(MAX),
@HeroName NVARCHAR(100),
@ClassName NVARCHAR(MAX),
@Support bit,
@Tactical bit
AS
DECLARE @skillId INT, @heroId INT

IF EXISTS( SELECT * FROM [dbo].[Heroes] WHERE LOWER([Name]) LIKE LOWER(@HeroName) )
BEGIN
	SET @heroId = (SELECT [Id] FROM [dbo].[Heroes] WHERE LOWER([Name]) LIKE LOWER(@HeroName))
	IF EXISTS( SELECT * FROM [dbo].[Skills] WHERE LOWER([Name]) LIKE LOWER(@Name) )
		BEGIN
			SET @skillId = (SELECT [Id] FROM [dbo].[Skills] WHERE LOWER([Name]) LIKE LOWER(@Name))
		END
	ELSE
		BEGIN
			INSERT INTO [dbo].[Skills] ([Name],[Description]) VALUES (@Name,@Description)
			SET @skillId = (SELECT IDENT_CURRENT('Skills'))
		END
	INSERT INTO [dbo].[SubClasses] ([Name],[SkillId],[HeroId],[IsSupport],[IsTactical]) VALUES (@ClassName,@skillId,@heroId,@Support,@Tactical)
END
GO
