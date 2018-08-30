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
                case "edged":
                case "blunt":
                case "piercing":
                    weapTypName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(desc[2].ToLower());
                    break;
                default:
                    weapTypName = "Unknown";
                    break;
            }
            WeaponType weaponType = new WeaponType();
            weaponType.Description = weapTypName;
            db.InsertWeaponType(weaponType);

            Schematic weaponSchematic = new Schematic();
            weaponSchematic.Name = schemat.name;
            weaponSchematic.Level = schemat.level;
            weaponSchematic.Stars = schemat.stars;
            weaponSchematic.Description = schemat.description;
            weaponSchematic.PictureId = pictId;
            weaponSchematic.WeaponTypeId = weaponType.Id;
            weaponSchematic.Rarity = db.Rarities.FirstOrDefault(r => r.Description.Equals("Legendary"));
            weaponSchematic.Traits = new List<TraitImpact>();

            foreach (var stat in schemat.stat)
            {
                string descr = stat.name.Trim();
                string effect = stat.value.Trim();
                Trait trait = db.Traits.FirstOrDefault(t => t.Description.Equals(descr));
                if (trait == null)
                {
                    trait = new Trait();
                    trait.Description = descr;
                    db.InsertTrait(trait);
                }
                TraitImpact impact = new TraitImpact();
                impact.Impact = effect;
                impact.SchematicId = weaponSchematic.Id;
                impact.TraitId = trait.Id;
                weaponSchematic.Traits.Add(impact);
                //db.InsertTraitImpact(impact);
            }

            db.InsertSchematic(weaponSchematic);
        }
        #endregion

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