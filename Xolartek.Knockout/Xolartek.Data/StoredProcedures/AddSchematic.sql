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
@PictureSource NVARCHAR(MAX),
@WeaponEdition NVARCHAR(100),
@WeaponType NVARCHAR(100),
@Rarity NVARCHAR(100)
AS
DECLARE @pictId INT, @weapEditionId INT, @weapTypeId INT, @rareId INT

INSERT INTO [dbo].[Pictures] ([Source],[CSSClass],[Alternate]) VALUES (@PictureSource,'img-fluid',@Name)

SET @pictId = (SELECT IDENT_CURRENT('Pictures'))

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

IF EXISTS( SELECT * FROM [dbo].[Rarities] WHERE [Description] LIKE @Rarity )
	BEGIN
		SET @rareId = (SELECT [Id] FROM [dbo].[Rarities] WHERE [Description] LIKE @Rarity)
	END
ELSE
	BEGIN
		INSERT INTO [dbo].[Rarities] ([Description]) VALUES (@Rarity)
		SET @rareId = (SELECT IDENT_CURRENT('Rarities'))
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
,<RarityId, int,>
,<PictureId, int,>
,<WeaponEditionId, int,>
,<WeaponTypeId, int,>)
GO
