using RepostIt.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepostIt.Models
{
    public class CommunityRepository : ICommunityRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public CommunityRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Community> AllCommunities => _appDbContext.community;


    }
}
