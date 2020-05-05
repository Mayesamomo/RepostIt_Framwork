using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepostIt.Models
{
    public interface IPostRepository
    {
        IEnumerable<Post> AllPosts { get; }
        Post GetPost(int id);
    }
}
