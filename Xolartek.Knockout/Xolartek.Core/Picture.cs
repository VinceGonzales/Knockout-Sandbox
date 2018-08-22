using System.ComponentModel.DataAnnotations;

namespace Xolartek.Core
{
    public class Picture : IPicture
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Source { get; set; }
        public string CSSClass { get; set; }
        public string Alternate { get; set; }
    }
}
