﻿using System.Linq;
using Xolartek.Core;
using Xolartek.Core.Fortnite;

namespace Xolartek.ORM
{
    public interface IXolarDB
    {
        IQueryable<Material> Materials { get; }
        IQueryable<MaterialCost> MaterialCosts { get; }
        IQueryable<Rarity> Rarities { get; }
        IQueryable<Picture> Pictures { get; }
        IQueryable<Schematic> Schematics { get; }
        IQueryable<Trait> Traits { get; }
        IQueryable<TraitImpact> TraitImpacts { get; }
        IQueryable<WeaponEdition> WeaponEditions { get; }
        IQueryable<WeaponType> WeaponTypes { get; }
        IQueryable<Hero> Heroes { get; }
    }
}