using RepostIt.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepostIt.Models
{
    public class DislikeRepository :IDislikeRepository
    {

        private readonly ApplicationDbContext _appDbContext;

        public DislikeRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public int getDislikes(int id)
        {
            int count = 0;
            foreach (Dislike dislike in _appDbContext.dislikes)
            {

                if (dislike.postId == id)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
