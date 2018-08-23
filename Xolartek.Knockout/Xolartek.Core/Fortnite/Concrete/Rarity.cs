using System;
using System.Collections.Generic;

namespace Xolartek.Core.Fortnite
{
    /// <summary>
    /// Indicates whether the schematic is legendary, epic, rare, etc.
    /// </summary>
    public class Rarity : Trait, ITrait
    {
        public ICollection<Schematic> Schematics { get; set; }
    }
}
