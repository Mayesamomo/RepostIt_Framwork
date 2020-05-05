using RepostIt.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepostIt.Models
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public PostRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Post> AllPosts
        {
            get
            {
                return _appDbContext.posts;
            }
        }



        public Post GetPost(int Id)
        {
            return _appDbContext.posts.FirstOrDefault(m => m.id == Id);
        }
    }
}

