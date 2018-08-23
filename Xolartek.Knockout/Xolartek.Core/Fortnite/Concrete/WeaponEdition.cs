using System;
using System.Collections.Generic;

namespace Xolartek.Core.Fortnite
{
    /// <summary>
    /// Indicates whether the schematic is a vacuum, hydraulic, neon, etc.
    /// </summary>
    public class WeaponEdition : Trait, ITrait
    {
        public ICollection<Schematic> Schematics { get; set; }
    }
}
