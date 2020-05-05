using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RepostIt.Models
{
    public class Comment
    {
        
        public int Id { get; set; }
        public string commentText { get; set; }
        public string name { get; set; }
        public int postId { get; set; }
    }
}
