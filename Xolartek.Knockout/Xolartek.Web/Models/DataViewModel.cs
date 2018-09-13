using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Xolartek.Web.Models
{
    public class DataViewModel
    {
        public List<SkillVM> Data { get; set; }
        public int Total { get; set; }
        public string AggregateResults { get; set; }
        public string Errors { get; set; }
    }
}