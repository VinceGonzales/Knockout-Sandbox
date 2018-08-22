using System.ComponentModel.DataAnnotations;

namespace Xolartek.Core.Fortnite
{
    public class MaterialCost : Trait, ITrait
    {
    	[Required]
    	public int Cost { get; set; }
    	public int MaterialId { get; set; }
        public Material Material { get; set; }
    }
}