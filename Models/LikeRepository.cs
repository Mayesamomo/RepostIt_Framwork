using RepostIt.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepostIt.Models
{
    public class LikeRepository : ILikeRespository
    {

        private readonly ApplicationDbContext _appDbContext;

        public LikeRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public int getLikes(int id)
        {
            int count = 0;
            foreach(Like like in  _appDbContext.likes){
                
                if(like.postId == id)
                {
                    count++;
                }
            }
            return count;
        }

    }
}
