using System;

namespace Xolartek.Core.Fortnite
{
    public interface IWeaponRange : ISchematic
    {
        int MagazineSize { get; set; }
        int Range { get; set; }
        decimal ReloadTime { get; set; }
        int AmmoCost { get; set; }
    }
}
