using System;

namespace Xolartek.Web.Models
{
    public class SkillVM
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string heroname { get; set; }
        public string classname { get; set; }
        public bool issupport { get; set; }
        public bool istactical { get; set; }
    }
}