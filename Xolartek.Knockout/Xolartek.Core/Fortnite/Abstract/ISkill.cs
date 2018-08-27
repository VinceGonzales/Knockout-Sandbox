using System.Collections.Generic;

namespace Xolartek.Core.Fortnite
{
    public interface ISkill
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        ICollection<SubClass> SubClasses { get; set; }
    }
}
