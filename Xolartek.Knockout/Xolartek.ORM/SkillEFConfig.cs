using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Xolartek.Core.Fortnite;

namespace Xolartek.ORM
{
    public class SkillEFConfig : EntityTypeConfiguration<Skill>
    {
        public SkillEFConfig()
        {
            ToTable("Skills");
            HasKey<int>(s => s.Id)
                .Property(s => s.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            HasMany<SubClass>(s => s.SubClasses)
                .WithRequired(x => x.Skill)
                .HasForeignKey(x => x.SkillId)
                .WillCascadeOnDelete(false);
        }
    }
}
