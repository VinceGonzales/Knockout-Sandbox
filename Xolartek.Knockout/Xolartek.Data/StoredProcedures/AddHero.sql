USE [XolartekDb]
GO
CREATE PROCEDURE InsertHero
 @name nvarchar(100)
,@stars int
,@level int
,@description nvarchar(max)
,@imgsource nvarchar(max)
,@rarityid int
AS
DECLARE @pictureid int, @datecreated datetime, @heroid int
SET @datecreated = GETDATE()

IF EXISTS( SELECT * FROM [dbo].[Heroes] WHERE [Name] LIKE @name )
	BEGIN
		SELECT 0
	END
ELSE
	BEGIN
		INSERT INTO [dbo].[Pictures] ([Source],[CSSClass],[Alternate]) VALUES (@imgsource, 'img-fluid', @description)
		SET @pictureid = (SELECT IDENT_CURRENT('Pictures'))

		INSERT INTO [dbo].[Heroes] ([Name],[Stars],[Level],[Description],[RarityId],[PictureId],[DateCreated])
		VALUES (@name,@stars,@level,@description,@rarityid,@pictureid,@datecreated)

		SELECT IDENT_CURRENT('Heroes')
	END