using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepostIt.Models
{
    public interface ICommunityRepository
    {
        IEnumerable<Community> AllCommunities { get; }
    }
}
