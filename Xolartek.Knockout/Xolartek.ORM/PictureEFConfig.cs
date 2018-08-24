using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Xolartek.Core;

namespace Xolartek.ORM
{
    public class PictureEFConfig : EntityTypeConfiguration<Picture>
    {
        public PictureEFConfig()
        {
            ToTable("Pictures");
            HasKey<int>(s => s.Id)
                .Property(s => s.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();
        }
    }
}
