using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Xolartek.Core.Fortnite;

namespace Xolartek.ORM
{
    public class WeaponEditionEFConfig : EntityTypeConfiguration<WeaponEdition>
    {
        public WeaponEditionEFConfig()
        {
            ToTable("WeaponEditions");
            HasKey<int>(t => t.Id)
                .Property(s => s.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            HasMany<Schematic>(t => t.Schematics)
                .WithOptional(s => s.WeaponEdition)
                .HasForeignKey(s => s.WeaponEditionId)
                .WillCascadeOnDelete(false);
        }
    }
}
