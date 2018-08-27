using System;
using System.Collections.Generic;

namespace Xolartek.Web.Models
{
    public class HeroVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Rarity { get; set; }
        public string ImgUrl { get; set; }
        public int Stars { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }
        public List<SkillVM> Skills { get; set; }
    }
}