using System.Collections.Generic;

namespace Xolartek.Web.Models
{
    public class SchematicVM
    {
        public int id { get; set; }
        public string name { get; set; }
        public string imgurl { get; set; }
        public int level { get; set; }
        public int stars { get; set; }
        public string description { get; set; }
        public List<stat> stat { get; set; }
    }
    public class stat
    {
        public string name { get; set; }
        public string value { get; set; }
    }
}