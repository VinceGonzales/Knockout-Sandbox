USE [XolartekDb]
GO
CREATE PROCEDURE InsertSchematic
@Name NVARCHAR(100),
@Description NVARCHAR(MAX),
@Durability INT,
@WeaponLevel INT,
@Stars INT,
@Damage INT,
@CritChance DECIMAL(18,2),
@CritDamage DECIMAL(18,2),
@AttackRate DECIMAL(18,2),
@DurabilityPerUse DECIMAL(18,2),
@Impact INT,
@ReloadTime DECIMAL(18,2),
@MagazineSize INT,
@WeaponRange INT,
@AmmoCost INT,
@RarityId INT,
@PictureSource NVARCHAR(MAX),
@WeaponEdition NVARCHAR(100),
@WeaponType NVARCHAR(100)
AS
DECLARE @pictureid INT, @weapEditionId INT, @weapTypeId INT

INSERT INTO [dbo].[Pictures] ([Source],[CSSClass],[Alternate]) VALUES (@PictureSource,'img-fluid',@Name)

SET @pictureid = (SELECT IDENT_CURRENT('Pictures'))

IF EXISTS( SELECT * FROM [dbo].[WeaponEditions] WHERE [Description] LIKE @WeaponEdition )
	BEGIN
		SET @weapEditionId = (SELECT [Id] FROM [dbo].[WeaponEditions] WHERE [Description] LIKE @WeaponEdition)
	END
ELSE
	BEGIN
		INSERT INTO [dbo].[WeaponEditions] ([Description]) VALUES (@WeaponEdition)
		SET @weapEditionId = (SELECT IDENT_CURRENT('WeaponEditions'))
	END

IF EXISTS( SELECT * FROM [dbo].[WeaponTypes] WHERE [Description] LIKE @WeaponType )
	BEGIN
		SET @weapTypeId = (SELECT [Id] FROM [dbo].[WeaponTypes] WHERE [Description] LIKE @WeaponType)
	END
ELSE
	BEGIN
		INSERT INTO [dbo].[WeaponTypes] ([Description]) VALUES (@WeaponType)
		SET @weapTypeId = (SELECT IDENT_CURRENT('WeaponTypes'))
	END

INSERT INTO [dbo].[Schematics]
([Name],[Description],[Durability],[Level],[Stars],[Damage],[CritChance],[CritDamage],[AttackRate],[DurabilityPerUse],[Impact],[ReloadTime],[MagazineSize],[Range],[AmmoCost],[RarityId],[PictureId],[WeaponEditionId],[WeaponTypeId]) VALUES 
(@Name
,@Description
,@Durability
,@WeaponLevel
,@Stars
,@Damage
,@CritChance
,@CritDamage
,@AttackRate
,@DurabilityPerUse
,@Impact
,@ReloadTime
,@MagazineSize
,@WeaponRange
,@AmmoCost
,@RarityId
,@pictureid
,@weapEditionId
,@weapTypeId)
GO