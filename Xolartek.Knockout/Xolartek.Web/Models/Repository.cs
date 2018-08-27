using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
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
        public IList<Xolartek.Core.Fortnite.Material> GetMaterials()
        {
            return db.Materials.ToList();
        }
        public IList<Xolartek.Core.Fortnite.Rarity> GetRarities()
        {
            return db.Rarities.ToList();
        }
        public IList<Xolartek.Core.Fortnite.Trait> GetTraits()
        {
            return db.Traits.ToList();
        }
        public IList<Xolartek.Core.Fortnite.WeaponEdition> GetEditions()
        {
            return db.WeaponEditions.ToList();
        }
        public IList<Xolartek.Core.Fortnite.WeaponType> GetWeaponTypes()
        {
            return db.WeaponTypes.ToList();
        }
        public IList<Xolartek.Core.Fortnite.Skill> GetSkills()
        {
            return db.Skills.ToList();
        }
        public IList<Xolartek.Core.Fortnite.SubClass> GetSubClass(int id)
        {
            return db.SubClasses
                .Where(c => c.HeroId.Equals(id))
                .Include(c => c.Skill)
                .ToList();
        }
        public IList<Xolartek.Core.Fortnite.Schematic> GetSchematics()
        {
            return db.Schematics
                .Include(s => s.Materials)
                .Include(s => s.Traits)
                .Include(s => s.Picture)
                .ToList();
        }
        public IList<Xolartek.Core.Fortnite.Hero> GetHeroes()
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