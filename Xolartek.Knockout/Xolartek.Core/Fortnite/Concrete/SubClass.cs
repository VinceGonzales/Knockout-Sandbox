using System.ComponentModel.DataAnnotations;

namespace Xolartek.Core.Fortnite
{
    public class SubClass : ISubClass
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsSupport { get; set; }
        public bool IsTactical { get; set; }

        public int SkillId { get; set; }
        private ISkill _skill { get; set; }
        public Skill Skill
        {
            get
            {
                return (Skill)_skill;
            }
            set
            {
                _skill = value;
            }
        }
        ISkill ISubClass.Skill
        {
            get
            {
                return _skill;
            }
            set
            {
                _skill = value;
            }
        }

        public int HeroId { get; set; }
        private IHero _hero { get; set; }
        public Hero Hero
        {
            get
            {
                return (Hero)_hero;
            }
            set
            {
                _hero = value;
            }
        }
        IHero ISubClass.Hero
        {
            get
            {
                return _hero;
            }
            set
            {
                _hero = value;
            }
        }
    }
}
