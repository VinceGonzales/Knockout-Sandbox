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
        int HealthRegen { get; set; }
        int ShieldDelay { get; set; }
        decimal AbilityDamage { get; set; }
        decimal HealingModifier { get; set; }
        int RunSpeed { get; set; }
        int SprintSpeed { get; set; }

        ICollection<ISubClass> SubClassAbilities { get; set; }

        int RarityId { get; set; }
        ITrait Rarity { get; set; }
        int? PictureId { get; set; }
        IPicture Picture { get; set; }
    }
}
