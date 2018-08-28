USE [XolartekDb]
GO
--ALTER TABLE dbo.[Heroes] ADD [Health] INT NULL, [HealthRegenRate] INT NULL, [Shield] INT NULL
--GO
--ALTER TABLE dbo.[Heroes] ADD [ShieldRegenDelay] INT NULL, [RunSpeed] INT NULL, [SprintSpeed] INT NULL
--GO
--ALTER TABLE dbo.[Heroes] ADD [HeroAbilityDmg] NUMERIC(9,3) NULL, [HeroHealingMod] NUMERIC(9,3) NULL, [ShieldRegenRate] INT NULL
--GO
UPDATE [dbo].[Heroes] SET [HeroClass] = 'Soldier',[Health] = 162930,[HealthRegenRate] = 3691,[Shield] = 59379,[ShieldRegenRate] = 14913,[ShieldRegenDelay] = 8,[RunSpeed] = 410,[SprintSpeed] = 550,[HeroAbilityDmg] = '13.0',[HeroHealingMod] = '10.65' WHERE LOWER([Name]) LIKE 'rescue trooper havoc'
GO
UPDATE [dbo].[Heroes] SET [HeroClass] = 'Outlander',[Health] = 130742,[HealthRegenRate] = 3248,[Shield] = 70171,[ShieldRegenRate] = 17463,[ShieldRegenDelay] = 8,[RunSpeed] = 410,[SprintSpeed] = 550,[HeroAbilityDmg] = '12.5',[HeroHealingMod] = '10.11' WHERE LOWER([Name]) LIKE 'ranger deadeye'
GO
UPDATE [dbo].[Heroes] SET [HeroClass] = 'Constructor',[Health] = 177148,[HealthRegenRate] = 4408,[Shield] = 61895,[ShieldRegenRate] = 15545,[ShieldRegenDelay] = 8,[RunSpeed] = 410,[SprintSpeed] = 550,[HeroAbilityDmg] = '9.8',[HeroHealingMod] = '7.45' WHERE LOWER([Name]) LIKE 'power base knox'
GO
UPDATE [dbo].[Heroes] SET [HeroClass] = 'Soldier',[Health] = 102909,[HealthRegenRate] = 2320,[Shield] = 37689,[ShieldRegenRate] = 9466,[ShieldRegenDelay] = 8,[RunSpeed] = 410,[SprintSpeed] = 550,[HeroAbilityDmg] = '8.2',[HeroHealingMod] = '5.88' WHERE LOWER([Name]) LIKE 'master grenadier ramirez'
GO
UPDATE [dbo].[Heroes] SET [HeroClass] = 'Constructor',[Health] = 127670,[HealthRegenRate] = 3185,[Shield] = 51570,[ShieldRegenRate] = 12952,[ShieldRegenDelay] = 8,[RunSpeed] = 410,[SprintSpeed] = 550,[HeroAbilityDmg] = '8.8',[HeroHealingMod] = '6.47' WHERE LOWER([Name]) LIKE 'heavy base kyle'
GO
UPDATE [dbo].[Heroes] SET [HeroClass] = 'Ninja',[Health] = 84018,[HealthRegenRate] = 2088,[Shield] = 40465,[ShieldRegenRate] = 10163,[ShieldRegenDelay] = 8,[RunSpeed] = 501,[SprintSpeed] = 671,[HeroAbilityDmg] = '8.5',[HeroHealingMod] = '6.17' WHERE LOWER([Name]) LIKE 'swordmaster ken'
GO
UPDATE [dbo].[Heroes] SET [HeroClass] = 'Constructor',[Health] = 109658,[HealthRegenRate] = 2721,[Shield] = 39077,[ShieldRegenRate] = 9814,[ShieldRegenDelay] = 8,[RunSpeed] = 410,[SprintSpeed] = 550,[HeroAbilityDmg] = '6.5',[HeroHealingMod] = '4.12' WHERE LOWER([Name]) LIKE 'steel wool syd'
GO
