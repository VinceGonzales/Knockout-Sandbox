using System.ComponentModel.DataAnnotations;

namespace Xolartek.Core.Fortnite
{
    public class TraitImpact : ITraitImpact
    {
        [Key]
        public int Id { get; set; }
        [Required]
    	public string Impact { get; set; }
    	public int TraitId { get; set; }
        public ITrait Trait { get; set; }
        public int SchematicId { get; set; }
        public ISchematic Schematic { get; set; }
    }
}