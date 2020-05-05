using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepostIt.Models
{
    public interface IDislikeRepository 
    {
        public int getDislikes(int id);
    }
}
