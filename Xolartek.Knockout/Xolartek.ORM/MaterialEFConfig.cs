using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Xolartek.Core.Fortnite;

namespace Xolartek.ORM
{
    public class MaterialEFConfig : EntityTypeConfiguration<Material>
    {
        public MaterialEFConfig()
        {
            ToTable("Materials");
            HasKey<int>(s => s.Id)
                .Property(s => s.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            HasMany<MaterialCost>(m => m.MaterialCosts)
                .WithRequired(mc => mc.Material)
                .HasForeignKey(mc => mc.MaterialId)
                .WillCascadeOnDelete(true);

            HasOptional(m => m.Picture);
        }
    }
}
