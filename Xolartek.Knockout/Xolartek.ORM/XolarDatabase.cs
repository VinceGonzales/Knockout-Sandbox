using System.Data.Entity;
using Xolartek.Core;
using Xolartek.Core.Fortnite;

namespace Xolartek.ORM
{
    public class XolarDatabase : DbContext
    {
        public XolarDatabase() : base("DefaultConnectionString")
        { }

        public DbSet<Material> Materials { get; set; }
        public DbSet<MaterialCost> MaterialCosts { get; set; }
        public DbSet<Rarity> Rarities { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Schematic> Schematics { get; set; }
        public DbSet<Trait> Traits { get; set; }
        public DbSet<TraitImpact> TraitImpacts { get; set; }
        public DbSet<WeaponEdition> WeaponEditions { get; set; }
        public DbSet<WeaponType> WeaponTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new MaterialEFConfig());
            modelBuilder.Configurations.Add(new TraitEFConfig());
            modelBuilder.Configurations.Add(new SchematicEFConfig());
            modelBuilder.Configurations.Add(new RarityEFConfig());
            modelBuilder.Configurations.Add(new WeaponEditionEFConfig());
            modelBuilder.Configurations.Add(new WeaponTypeEFConfig());
        }
    }
}
