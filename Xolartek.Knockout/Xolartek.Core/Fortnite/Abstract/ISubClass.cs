using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xolartek.Core.Fortnite
{
    public interface ISubClass
    {
        int Id { get; set; }
        string Name { get; set; }
        bool IsSupport { get; set; }
        bool IsTactical { get; set; }
        int SkillId { get; set; }
        ISkill Skill { get; set; }
        int HeroId { get; set; }
        IHero Hero { get; set; }
    }
}
