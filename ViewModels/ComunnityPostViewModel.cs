using RepostIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepostIt.ViewModels
{
    public class ComunnityPostViewModel
    {
       public IEnumerable<Community> communities { get; set; }
       public IEnumerable<Post> posts { get; set; }
    }
}
