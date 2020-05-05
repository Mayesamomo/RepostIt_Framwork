using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepostIt.Data;

namespace RepostIt.Models
{
    public class commentRepository: ICommentRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public commentRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


         public IEnumerable<Comment> allComment => _appDbContext.comments;

    }
}
