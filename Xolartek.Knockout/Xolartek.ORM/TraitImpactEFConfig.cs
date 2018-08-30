using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Xolartek.Core.Fortnite;

namespace Xolartek.ORM
{
    public class TraitImpactEFConfig : EntityTypeConfiguration<TraitImpact>
    {
        public TraitImpactEFConfig()
        {
            ToTable("TraitImpacts");
            HasKey<int>(t => t.Id)
                .Property(s => s.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();
            Property(s => s.WeaponClass).IsOptional();
        }
    }
}
