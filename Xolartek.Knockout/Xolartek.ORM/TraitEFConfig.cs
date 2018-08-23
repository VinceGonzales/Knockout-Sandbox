using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Xolartek.Core.Fortnite;

namespace Xolartek.ORM
{
    public class TraitEFConfig : EntityTypeConfiguration<Trait>
    {
        public TraitEFConfig()
        {
            ToTable("Traits");
            HasKey<int>(s => s.Id)
                .Property(s => s.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            HasMany<TraitImpact>(t => t.TraitImpacts)
                .WithRequired(ti => ti.Trait)
                .HasForeignKey(ti => ti.TraitId)
                .WillCascadeOnDelete(false);

        }
    }
}
