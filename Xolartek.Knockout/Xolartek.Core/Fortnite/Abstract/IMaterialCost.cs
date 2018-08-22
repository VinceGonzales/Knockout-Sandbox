using System;

namespace Xolartek.Core.Fortnite
{
    public interface IMaterialCost
    {
        int Id { get; set; }
        int Cost { get; set; }
        int MaterialId { get; set; }
        IMaterial Material { get; set; }
        int SchematicId { get; set; }
        ISchematic Schematic { get; set; }
    }
}
