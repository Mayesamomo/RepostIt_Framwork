using RepostIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepostIt.ViewModels
{
    public class commentViewModel
    {
        public string commentText { get; set; }
        public string name { get; set; }
        public int postId { get; set; }
        public int Id { get; set; }
        public IEnumerable<Comment> comments { get; set; }
        public IEnumerable<Post> post { get; set; }
        public IEnumerable<Community> community { get; set; }
        public Like like { get; set; }
        public ILikeRespository likeRespositories { get; set; }
        public IDislikeRepository dislikeRepositories { get; set; }

    }
}
