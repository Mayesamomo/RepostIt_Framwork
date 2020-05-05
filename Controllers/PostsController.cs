using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NToastNotify;
using RepostIt.Data;
using RepostIt.Models;
using RepostIt.ViewModels;

namespace RepostIt.Controllers
{
    public class PostsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILikeRespository _likeRespository;
        private readonly IDislikeRepository _dislikeRespository;
        private readonly IToastNotification _toastNotification;
        public PostsController(ApplicationDbContext context, ILikeRespository likeRespository, IDislikeRepository dislikeRepository, IToastNotification toastNotification)
        {
            _context = context;
            _likeRespository = likeRespository;
            _dislikeRespository = dislikeRepository;
            _toastNotification = toastNotification;
        }

        // GET: Posts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.posts.Include(p => p.community);
            return View(await applicationDbContext.ToListAsync());
        }


        // GET: Posts/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            int count = 0;
            dynamic mymodel = new ExpandoObject();
            if (id == null)
            {
                return NotFound();
            }

            mymodel.posts = await _context.posts.ToListAsync();
            if (mymodel == null)
            {
                return NotFound();
            }


            commentViewModel model = new commentViewModel()
            {
                comments = _context.comments,
                community = _context.community,
                like = new Like(),
                likeRespositories = _likeRespository,
                dislikeRepositories = _dislikeRespository,
                post = _context.posts,
                Id = id

            };
            //mymodel.comments = await _context.comments.ToListAsync();
            //mymodel.id = id;
            //mymodel.community = await _context.community.ToListAsync();
            //mymodel.likes = new Like();
            //mymodel.likes = _likeRespository;
            //mymodel.dislike = _dislikeRespository;
            //mymodel.text = commentText;
            //mymodel.name = name;
            //mymodel.id = postId;



        ViewData["postid"] =id;
            ViewData["Likes"] = count;
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> addLike([Bind("postId,username")] Like like)
        {
            _context.Add(like);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Posts/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["communityId"] = new SelectList(_context.community, "Id", "communityType");
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,showTitle,communityId,url,description,name")] Post post)
        {
            if (ModelState.IsValid)
            {
                _context.Add(post);
                await _context.SaveChangesAsync();
                _toastNotification.AddSuccessToastMessage("Post Created Successfully!");
                return RedirectToAction(nameof(Index));
            }
            ViewData["communityId"] = new SelectList(_context.community, "Id", "Id", post.communityId);
            return View(post);
        }

        // GET: Posts/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            ViewData["communityId"] = new SelectList(_context.community, "Id", "Id", post.communityId);
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,showTitle,communityId,url,description,name")] Post post)
        {
            if (id != post.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["communityId"] = new SelectList(_context.community, "Id", "Id", post.communityId);
            return View(post);
        }

        // GET: Posts/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.posts
                .Include(p => p.community)
                .FirstOrDefaultAsync(m => m.id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Posts/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var post = await _context.posts.FindAsync(id);
            _context.posts.Remove(post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
            return _context.posts.Any(e => e.id == id);
        }
    }
}
