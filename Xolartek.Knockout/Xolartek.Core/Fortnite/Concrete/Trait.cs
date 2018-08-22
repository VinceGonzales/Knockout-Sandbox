using System.ComponentModel.DataAnnotations;

namespace Xolartek.Core.Fortnite
{
    /// <summary>
    /// Indicates whether the trait influences critical rate, critical damage, etc.
    /// </summary>
    public class Trait : ITrait
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
