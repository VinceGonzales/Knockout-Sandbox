using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Xolartek.Core.Fortnite;

namespace Xolartek.ORM
{
    public class SubClassEFConfig : EntityTypeConfiguration<SubClass>
    {
        public SubClassEFConfig()
        {
            ToTable("SubClasses");
            HasKey<int>(t => t.Id)
                .Property(s => s.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();
        }
    }
}
