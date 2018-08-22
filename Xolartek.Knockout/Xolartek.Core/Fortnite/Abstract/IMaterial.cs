using System;

namespace Xolartek.Core.Fortnite
{
    public interface IMaterial : ITrait
    {
        int? PictureId { get; set; }
        IPicture Picture { get; set; }
    }
}
