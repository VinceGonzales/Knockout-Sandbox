using System;
using System.Collections.Generic;

namespace Xolartek.Core.Fortnite
{
    public interface IHero
    {
        int Id { get; set; }
        string Name { get; set; }
        int Stars { get; set; }
        int Level { get; set; }
        string Description { get; set; }
        string HeroClass { get; set; }

        ICollection<ISubClass> SubClassAbilities { get; set; }

        int RarityId { get; set; }
        ITrait Rarity { get; set; }
        int? PictureId { get; set; }
        IPicture Picture { get; set; }
    }
}
