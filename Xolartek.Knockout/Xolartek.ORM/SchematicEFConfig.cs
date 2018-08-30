using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Xolartek.Core.Fortnite;

namespace Xolartek.ORM
{
    public class SchematicEFConfig : EntityTypeConfiguration<Schematic>
    {
        public SchematicEFConfig()
        {
            ToTable("Schematics");
            HasKey<int>(s => s.Id)
                .Property(s => s.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();
            Property(s => s.Name).HasMaxLength(100);
            Property(s => s.Durability).IsOptional();
            Property(s => s.Damage).IsOptional();
            Property(s => s.CritChance).IsOptional();
            Property(s => s.CritDamage).IsOptional();
            Property(s => s.AttackRate).IsOptional();
            Property(s => s.DurabilityPerUse).IsOptional();
            Property(s => s.Impact).IsOptional();
            Property(s => s.ReloadTime).IsOptional();
            Property(s => s.MagazineSize).IsOptional();
            Property(s => s.Range).IsOptional();
            Property(s => s.AmmoCost).IsOptional();

            HasMany<TraitImpact>(s => s.Traits)
                .WithRequired(ti => ti.Schematic)
                .HasForeignKey(ti => ti.SchematicId)
                .WillCascadeOnDelete(false);

            HasMany<MaterialCost>(s => s.Materials)
                .WithRequired(mc => mc.Schematic)
                .HasForeignKey(mc => mc.SchematicId)
                .WillCascadeOnDelete(false);
        }
    }
}
