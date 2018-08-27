using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Xolartek.Core.Fortnite
{
    public class Skill : ISkill
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public bool IsSupport { get; set; }
        public bool IsTactical { get; set; }

        public ICollection<SubClass> SubClasses { get; set; }
    }
}
