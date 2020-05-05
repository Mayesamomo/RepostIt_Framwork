using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RepostIt.Data;
using RepostIt.Models;

namespace RepostIt.Controllers
{
    public class LikesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LikesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Likes
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.likes.ToListAsync());
        }

        // GET: Likes/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var like = await _context.likes
                .FirstOrDefaultAsync(m => m.id == id);
            if (like == null)
            {
                return NotFound();
            }

            return View(like);
        }


        [Authorize]
        public async Task<IActionResult> addLike(int id)
        {

            string username = User.Identity.Name;
            Like like2 = new Like(id,username);
            if (ModelState.IsValid)
            {
         // //      if(_context.likes.Where(s => s.username == username).Equals(""))
           //     {
                    _context.Add(like2);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Home");
            //    }

            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Likes/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var like = await _context.likes.FindAsync(id);
            if (like == null)
            {
                return NotFound();
            }
            return View(like);
        }

        // POST: Likes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,postId,username")] Like like)
        {
            if (id != like.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(like);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LikeExists(like.id))
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
            return View(like);
        }

        // GET: Likes/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var like = await _context.likes
                .FirstOrDefaultAsync(m => m.id == id);
            if (like == null)
            {
                return NotFound();
            }

            return View(like);
        }

        // POST: Likes/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var like = await _context.likes.FindAsync(id);
            _context.likes.Remove(like);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LikeExists(int id)
        {
            return _context.likes.Any(e => e.id == id);
        }
    }
}
