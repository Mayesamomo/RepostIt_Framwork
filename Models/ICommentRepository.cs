using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepostIt.Models
{
    public interface ICommentRepository
    {
        //  IEnumerable<Comment> AllCommentsByPost(int id);
        public IEnumerable<Comment> allComment { get; }
    }
}
