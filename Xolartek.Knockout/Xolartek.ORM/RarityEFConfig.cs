using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Xolartek.Core.Fortnite;

namespace Xolartek.ORM
{
    public class RarityEFConfig : EntityTypeConfiguration<Rarity>
    {
        public RarityEFConfig()
        {
            ToTable("Rarities");
            HasKey<int>(t => t.Id)
                .Property(s => s.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            HasMany<Schematic>(t => t.Schematics)
                .WithRequired(s => s.Rarity)
                .HasForeignKey(s => s.RarityId)
                .WillCascadeOnDelete(false);

            HasMany<Hero>(t => t.Heroes)
                .WithRequired(s => s.Rarity)
                .HasForeignKey(s => s.RarityId)
                .WillCascadeOnDelete(false);
        }
    }
}
