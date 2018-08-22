using System;

namespace Xolartek.Core
{
    public interface IPicture
    {
        int Id { get; set; }
        string Source { get; set; }
        string CSSClass { get; set; }
        string Alternate { get; set; }
    }
}
