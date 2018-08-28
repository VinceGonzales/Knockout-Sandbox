using System;
using System.Collections.Generic;

namespace Xolartek.Core.Fortnite
{
    public interface IHero
    {
        int Id { get; set; }
        string Name { get; set; }
        int Stars { get; set; }
        int Level { get; set; }
        string Description { get; set; }
        string HeroClass { get; set; }

        int Health { get; set; }
        int HealthRegenRate { get; set; }
        int Shield { get; set; }
        int ShieldRegenRate { get; set; }
        int ShieldRegenDelay { get; set; }
        decimal HeroAbilityDmg { get; set; }
        decimal HeroHealingMod { get; set; }
        int RunSpeed { get; set; }
        int SprintSpeed { get; set; }

        ICollection<ISubClass> SubClassAbilities { get; set; }

        int RarityId { get; set; }
        ITrait Rarity { get; set; }
        int? PictureId { get; set; }
        IPicture Picture { get; set; }
    }
}
