USE [XolartekDb]
GO
CREATE PROCEDURE InsertTraitImpact
@Impact NVARCHAR(MAX),
@TraitId INT,
@SchematicId INT
AS
INSERT INTO [dbo].[TraitImpacts]
([Impact]
,[TraitId]
,[SchematicId])
VALUES
(@Impact
,@TraitId
,@SchematicId)
GO
