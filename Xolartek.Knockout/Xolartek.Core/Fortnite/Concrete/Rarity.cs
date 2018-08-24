using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Xolartek.Core.Fortnite
{
    /// <summary>
    /// Indicates whether the schematic is legendary, epic, rare, etc.
    /// </summary>
    public class Rarity : ITrait
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        public ICollection<Schematic> Schematics { get; set; }
        public ICollection<Hero> Heroes { get; set; }
    }
}
