using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Xolartek.Core.Fortnite;

namespace Xolartek.ORM
{
    public class WeaponTypeEFConfig : EntityTypeConfiguration<WeaponType>
    {
        public WeaponTypeEFConfig()
        {
            ToTable("WeaponTypes");
            HasKey<int>(t => t.Id)
                .Property(s => s.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            HasMany<Schematic>(t => t.Schematics)
                .WithRequired(s => s.WeaponType)
                .HasForeignKey(s => s.WeaponTypeId)
                .WillCascadeOnDelete(false);
        }
    }
}
