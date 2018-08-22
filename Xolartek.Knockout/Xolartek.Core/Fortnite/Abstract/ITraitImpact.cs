using System;

namespace Xolartek.Core.Fortnite
{
    public interface ITraitImpact
    {
        int Id { get; set; }
        string Impact { get; set; }
        int TraitId { get; set; }
        int SchematicId { get; set; }
        ITrait Trait { get; set; }
        ISchematic Schematic { get; set; }
    }
}
