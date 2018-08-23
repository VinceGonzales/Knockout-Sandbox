using System;
using System.Collections.Generic;

namespace Xolartek.Core.Fortnite
{
    /// <summary>
    /// Indicates whether the schematic is melee, range, trap, etc.
    /// </summary>
    public class WeaponType : Trait, ITrait
    {
        public ICollection<Schematic> Schematics { get; set; }
    }
}