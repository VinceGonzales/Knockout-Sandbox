using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Xolartek.Core.Fortnite
{
    /// <summary>
    /// Indicates whether the schematic is a vacuum, hydraulic, neon, etc.
    /// </summary>
    public class WeaponEdition : ITrait
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        public ICollection<Schematic> Schematics { get; set; }
    }
}
