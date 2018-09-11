using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using Xolartek.Core;
using Xolartek.Core.Fortnite;
using Xolartek.ORM;

namespace Xolartek.Web.Models
{
    public class Repository : IDisposable
    {
        private IXolarDB db;

        public Repository(IXolarDB ctx)
        {
            db = ctx;
        }

        #region GET
        public List<Xolartek.Core.Fortnite.Material> GetMaterials()
        {
            return db.Materials.ToList();
        }
        public List<Xolartek.Core.Fortnite.Rarity> GetRarities()
        {
            return db.Rarities.ToList();
        }
        public List<Xolartek.Core.Fortnite.Trait> GetTraits()
        {
            return db.Traits.ToList();
        }
        public List<Xolartek.Core.Fortnite.WeaponEdition> GetEditions()
        {
            return db.WeaponEditions.ToList();
        }
        public List<Xolartek.Core.Fortnite.WeaponType> GetWeaponTypes()
        {
            return db.WeaponTypes.ToList();
        }
        public List<Xolartek.Core.Fortnite.Skill> GetSkills()
        {
            return db.Skills.ToList();
        }
        public List<Xolartek.Core.Fortnite.SubClass> GetSubClass(int id)
        {
            return db.SubClasses
                .Where(c => c.HeroId.Equals(id))
                .Include(c => c.Skill)
                .ToList();
        }
        public List<Xolartek.Core.Fortnite.Schematic> GetSchematics()
        {
            return db.Schematics
                .Include(s => s.Materials)
                .Include(s => s.Traits)
                .Include(s => s.Picture)
                .ToList();
        }
        public List<Xolartek.Core.Fortnite.Hero> GetHeroes()
        {
            return db.Heroes
                .Include(h => h.Picture)
                .ToList();
        }
        public Xolartek.Core.Fortnite.Hero GetHero(int id)
        {
            return db.Heroes
                .Include(h => h.Picture)
                .Include(h => h.Rarity)
                .Include(h => h.SubClassAbilities)
                .FirstOrDefault(h => h.Id.Equals(id));
        }
        public List<Xolartek.Core.Fortnite.TraitImpact> GetTraitImpacts(int id)
        {
            return db.TraitImpacts
                .Include(t => t.Trait)
                .Include(s => s.Schematic)
                .Where(t => t.SchematicId.Equals(id))
                .ToList();
        }
        #endregion

        #region POST
        public void PostHero(HeroVM hero)
        {
            Rareness rarity = (Rareness)Enum.Parse(typeof(Rareness), hero.Rarity);
            var result = ((XolarDatabase)db).Database.ExecuteSqlCommand("dbo.InsertHero @name, @stars, @level, @description, @imgsource, @rarityid",
                new SqlParameter("@name", hero.Name), 
                new SqlParameter("@stars", hero.Stars), 
                new SqlParameter("@level", hero.Level), 
                new SqlParameter("@description", hero.Description), 
                new SqlParameter("@imgsource", hero.ImgUrl), 
                new SqlParameter("@rarityid", rarity)
                );
        }
        public void PostSkill(SkillVM skill)
        {
            var result = ((XolarDatabase)db).Database.ExecuteSqlCommand("dbo.InsertSkill @name, @description, @heroname, @classname, @support, @tactical",
                new SqlParameter("@name", skill.name.Trim()),
                new SqlParameter("@description", skill.description.Trim()),
                new SqlParameter("@heroname", skill.heroname),
                new SqlParameter("@classname", skill.classname),
                new SqlParameter("@support", skill.issupport),
                new SqlParameter("@tactical", skill.istactical)
                );
        }
        public void PostSchematicA(SchematicVM schemat)
        {
            int pictId = 1;
            if(!string.IsNullOrEmpty(schemat.imgurl))
            {
                Picture pict = new Picture();
                pict.Source = schemat.imgurl;
                pict.CSSClass = "img-fluid";
                pict.Alternate = schemat.description;
                db.InsertPicture(pict);
                db.SaveDbChanges();
                pictId = pict.Id;
            }

            string weapTypName = "";
            string[] desc = schemat.description.Split('_');
            switch(desc[1].ToLower())
            {
                case "assault":
                    weapTypName = "Assault";
                    break;
                case "pistol":
                    weapTypName = "Pistol";
                    break;
                case "shotgun":
                    weapTypName = "Shotgun";
                    break;
                case "sniper":
                    weapTypName = "Sniper";
                    break;
                case "launcher":
                case "explosive":
                    weapTypName = "Explosive";
                    break;
                case "wall":
                case "floor":
                case "ceiling":
                    weapTypName = "Trap";
                    break;
                case "blunt":
                    weapTypName = "Blunt";
                    break;
                case "edged":
                case "piercing":
                    weapTypName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(desc[2].ToLower());
                    break;
                default:
                    weapTypName = "Unknown";
                    break;
            }

            WeaponType weaponType = db.WeaponTypes.FirstOrDefault(wt => wt.Description.Equals(weapTypName));
            if (weaponType == null)
            {
                weaponType = new WeaponType();
                weaponType.Description = weapTypName;
                db.InsertWeaponType(weaponType);
                db.SaveDbChanges();
            }

            Schematic weaponSchematic = new Schematic();
            weaponSchematic.Name = schemat.name;
            weaponSchematic.Level = schemat.level;
            weaponSchematic.Stars = schemat.stars;
            weaponSchematic.Description = schemat.description;
            weaponSchematic.PictureId = pictId;
            weaponSchematic.WeaponTypeId = weaponType.Id;
            weaponSchematic.Rarity = db.Rarities.FirstOrDefault(r => r.Description.Equals("Legendary"));

            foreach (var stat in schemat.stat)
            {
                string descr = stat.name.Trim();
                Trait trait = db.Traits.FirstOrDefault(t => t.Description.Equals(descr));
                if (trait == null)
                {
                    trait = new Trait();
                    trait.Description = descr;
                    db.InsertTrait(trait);
                    db.SaveDbChanges();
                }
                stat.id = trait.Id;
            }

            db.InsertSchematic(weaponSchematic);
            db.SaveDbChanges();

            schemat.stat.ForEach(s => {
                AddTraitImpact(s.value.Trim(), weaponSchematic.Id, s.id);
            });
        }
        #endregion

        private void AddTraitImpact(string value, int schemaId, int traitId)
        {
            var result = ((XolarDatabase)db).Database.ExecuteSqlCommand("dbo.InsertTraitImpact @Impact, @TraitId, @SchematicId",
                new SqlParameter("@Impact", value),
                new SqlParameter("@TraitId", traitId),
                new SqlParameter("@SchematicId", schemaId)
                );
        }

        #region PUT
        //
        #endregion

        #region IDisposable
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    (db as DbContext).Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
    public enum Rareness
    {
        common = 1, epic, legendary, mythic, rare
    }
}