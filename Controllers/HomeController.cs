using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RepostIt.Data;
using RepostIt.Models;

namespace RepostIt.Controllers
{
    public class HomeController : Controller
    {
      //  private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly ILikeRespository _likeRespository;
        private readonly IDislikeRepository _dislikeRespository;

        public HomeController(ApplicationDbContext context , ILikeRespository likeRespository , IDislikeRepository dislikeRepository )
        {
            _context = context;
            _likeRespository = likeRespository;
            _dislikeRespository = dislikeRepository;
        }
        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

 
        public async Task<IActionResult> Index()
        {






            dynamic mymodel = new ExpandoObject();

            mymodel.community = await _context.community.ToListAsync();
            mymodel.posts = await _context.posts.ToListAsync();
            mymodel.likes = _likeRespository;
            mymodel.dislike = _dislikeRespository;
            return View(mymodel);
        }


        public async Task<IActionResult> profile()
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.posts = await _context.posts.ToListAsync();
            mymodel.community = await _context.community.ToListAsync();
            mymodel.comments = await _context.comments.ToListAsync();
            return View(mymodel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
