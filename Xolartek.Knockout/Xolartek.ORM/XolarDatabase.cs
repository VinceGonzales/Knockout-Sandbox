using System.Data.Entity;
using System.Linq;
using Xolartek.Core;
using Xolartek.Core.Fortnite;

namespace Xolartek.ORM
{
    public class XolarDatabase : DbContext, IXolarDB
    {
        public XolarDatabase() : base("DefaultConnectionString")
        { }

        #region DbSets
        public DbSet<Material> Materials { get; set; }
        public DbSet<MaterialCost> MaterialCosts { get; set; }
        public DbSet<Rarity> Rarities { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Schematic> Schematics { get; set; }
        public DbSet<Trait> Traits { get; set; }
        public DbSet<TraitImpact> TraitImpacts { get; set; }
        public DbSet<WeaponEdition> WeaponEditions { get; set; }
        public DbSet<WeaponType> WeaponTypes { get; set; }
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SubClass> SubClasses { get; set; }
        #endregion

        #region Queryables
        IQueryable<Material> IXolarDB.Materials
        {
            get { return Materials; }
        }

        IQueryable<MaterialCost> IXolarDB.MaterialCosts
        {
            get { return MaterialCosts; }
        }

        IQueryable<Rarity> IXolarDB.Rarities
        {
            get { return Rarities; }
        }

        IQueryable<Picture> IXolarDB.Pictures
        {
            get { return Pictures; }
        }

        IQueryable<Schematic> IXolarDB.Schematics
        {
            get { return Schematics; }
        }

        IQueryable<Trait> IXolarDB.Traits
        {
            get { return Traits; }
        }

        IQueryable<TraitImpact> IXolarDB.TraitImpacts
        {
            get { return TraitImpacts; }
        }

        IQueryable<WeaponEdition> IXolarDB.WeaponEditions
        {
            get { return WeaponEditions; }
        }

        IQueryable<WeaponType> IXolarDB.WeaponTypes
        {
            get { return WeaponTypes; }
        }

        IQueryable<Hero> IXolarDB.Heroes
        {
            get { return Heroes; }
        }

        IQueryable<Skill> IXolarDB.Skills
        {
            get { return Skills; }
        }

        IQueryable<SubClass> IXolarDB.SubClasses
        {
            get { return SubClasses; }
        }
        #endregion

        #region Inserts
        public void InsertPicture(Picture pix)
        {
            Pictures.Add(pix);
            SaveChanges();
        }
        public void InsertWeaponType(WeaponType weapType)
        {
            WeaponTypes.Add(weapType);
            SaveChanges();
        }
        public void InsertSchematic(Schematic schematic)
        {
            Schematics.Add(schematic);
            SaveChanges();
        }
        public void InsertTrait(Trait trait)
        {
            Traits.Add(trait);
            SaveChanges();
        }
        public void InsertTraitImpact(TraitImpact impact)
        {
            TraitImpacts.Add(impact);
            SaveChanges();
        }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new MaterialEFConfig());
            modelBuilder.Configurations.Add(new TraitEFConfig());
            modelBuilder.Configurations.Add(new SchematicEFConfig());
            modelBuilder.Configurations.Add(new RarityEFConfig());
            modelBuilder.Configurations.Add(new WeaponEditionEFConfig());
            modelBuilder.Configurations.Add(new WeaponTypeEFConfig());
            modelBuilder.Configurations.Add(new HeroEFConfig());
            modelBuilder.Configurations.Add(new PictureEFConfig());
            modelBuilder.Configurations.Add(new TraitImpactEFConfig());
            modelBuilder.Configurations.Add(new MaterialCostEFConfig());
            modelBuilder.Configurations.Add(new SkillEFConfig());
            modelBuilder.Configurations.Add(new SubClassEFConfig());
        }
    }
}
