using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Xolartek.Core.Fortnite;

namespace Xolartek.ORM
{
    public class HeroEFConfig : EntityTypeConfiguration<Hero>
    {
        public HeroEFConfig()
        {
            ToTable("Heroes");
            HasKey<int>(s => s.Id)
                .Property(s => s.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(s => s.Name).HasMaxLength(100);
            Property(s => s.HeroClass).IsOptional().HasMaxLength(100);
            Property(s => s.Health).IsOptional();
            Property(s => s.HealthRegenRate).IsOptional();
            Property(s => s.Shield).IsOptional();
            Property(s => s.ShieldRegenRate).IsOptional();
            Property(s => s.ShieldRegenDelay).IsOptional();
            Property(s => s.HeroAbilityDmg).IsOptional();
            Property(s => s.HeroHealingMod).IsOptional();
            Property(s => s.RunSpeed).IsOptional();
            Property(s => s.SprintSpeed).IsOptional();

            HasMany<SubClass>(c => c.SubClassAbilities)
                .WithRequired(s => s.Hero)
                .HasForeignKey(s => s.HeroId)
                .WillCascadeOnDelete(false);

            HasOptional(m => m.Picture);
        }
    }
}
