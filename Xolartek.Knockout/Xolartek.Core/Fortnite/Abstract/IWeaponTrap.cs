using System;

namespace Xolartek.Core.Fortnite
{
    public interface IWeaponTrap : ISchematic
    {
        decimal ReloadTime { get; set; }
    }
}
