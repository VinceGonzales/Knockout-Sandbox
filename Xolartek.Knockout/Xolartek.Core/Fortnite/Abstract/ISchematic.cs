using System;
using System.Collections.Generic;

namespace Xolartek.Core.Fortnite
{
    public interface ISchematic
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        int Durability { get; set; }
        int Level { get; set; }
        int Stars { get; set; }
        int Damage { get; set; }
        decimal CritChance { get; set; }
        decimal CritDamage { get; set; }
        decimal AttackRate { get; set; }
        decimal DurabilityPerUse { get; set; }
        int Impact { get; set; }
        ICollection<ITraitImpact> Traits { get; set; }
        ICollection<IMaterialCost> Materials { get; set; }
        int RarityId { get; set; }
        ITrait Rarity { get; set; }
        int? PictureId { get; set; }
        IPicture Picture { get; set; }
        int WeaponTypeId { get; set; }
        ITrait WeaponType { get; set; }
        int? WeaponEditionId { get; set; }
        ITrait WeaponEdition { get; set; }
    }
}
