using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepostIt.Models
{
    public class Dislike
    {
        public int id { get; set; }
        public int postId { get; set; }
        public string username { get; set; }

        public Dislike(int id, string name)
        {
            postId = id;
            username = name;
        }
        public Dislike()
        {

        }

    }
}
