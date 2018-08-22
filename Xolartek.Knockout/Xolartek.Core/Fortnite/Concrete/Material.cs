using System;

namespace Xolartek.Core.Fortnite
{
    public class Material : Trait, IMaterial
    {
        public int? PictureId { get; set; }
        public IPicture Picture { get; set; }
    }
}
