using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Xolartek.Core.Fortnite;

namespace Xolartek.ORM
{
    public class MaterialCostEFConfig : EntityTypeConfiguration<MaterialCost>
    {
        public MaterialCostEFConfig()
        {
            ToTable("MaterialCosts");
            HasKey<int>(t => t.Id)
                .Property(s => s.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();
        }
    }
}
