using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Xolartek.Core.Fortnite
{
    /// <summary>
    /// Indicates whether the schematic is melee, range, trap, etc.
    /// </summary>
    public class WeaponType : ITrait
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        public ICollection<Schematic> Schematics { get; set; }
    }
}