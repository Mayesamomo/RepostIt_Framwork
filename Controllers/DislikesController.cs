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
    public class DislikesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DislikesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Dislikes
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.dislikes.ToListAsync());
        }

        // GET: Dislikes/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dislike = await _context.dislikes
                .FirstOrDefaultAsync(m => m.id == id);
            if (dislike == null)
            {
                return NotFound();
            }

            return View(dislike);
        }

        // GET: Dislikes/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dislikes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,postId,username")] Dislike dislike)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dislike);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dislike);
        }

        // GET: Dislikes/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dislike = await _context.dislikes.FindAsync(id);
            if (dislike == null)
            {
                return NotFound();
            }
            return View(dislike);
        }
        [Authorize]
        public async Task<IActionResult> addDislike(int id)
        {

            string username = User.Identity.Name;
            Dislike dislike = new Dislike(id, username);
            if (ModelState.IsValid)
            {
                // //      if(_context.likes.Where(s => s.username == username).Equals(""))
                //     {
                _context.Add(dislike);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
                //    }

            }
            return RedirectToAction("Index", "Home");
        }

        // POST: Dislikes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,postId,username")] Dislike dislike)
        {
            if (id != dislike.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dislike);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DislikeExists(dislike.id))
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
            return View(dislike);
        }

        // GET: Dislikes/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dislike = await _context.dislikes
                .FirstOrDefaultAsync(m => m.id == id);
            if (dislike == null)
            {
                return NotFound();
            }

            return View(dislike);
        }

        // POST: Dislikes/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dislike = await _context.dislikes.FindAsync(id);
            _context.dislikes.Remove(dislike);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DislikeExists(int id)
        {
            return _context.dislikes.Any(e => e.id == id);
        }
    }
}
