using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepostIt.Models
{
    public class Post
    {
        public int id { get; set; }
        public string showTitle { get; set; }
        public Community community { get; set; }
        public int communityId { get; set; }

        public string url { get; set; }
        public string description { get; set; }
        public string name { get; set; }
    }
}
