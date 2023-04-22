using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using login2.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace login2.Controllers
{
    public class SikayetlerController : Controller
    {
        private readonly IdentityContext _context;

        public SikayetlerController(IdentityContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
              return _context.sikayetler != null ? 
                          View(await _context.sikayetler.ToListAsync()) :
                          Problem("Entity set 'IdentityContext.sikayetler'  is null.");
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.sikayetler == null)
            {
                return NotFound();
            }

            var sikayet = await _context.sikayetler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sikayet == null)
            {
                return NotFound();
            }

            return View(sikayet);
        }

        // GET: Sikayetler/Create
        public IActionResult Create()
        {
            var model = new Sikayet();
            model.SikayetEdenId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Console.WriteLine(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Konu,SikayetEdenId,SikayetText")] Sikayet sikayet)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine(User.FindFirstValue(ClaimTypes.NameIdentifier));
                sikayet.SikayetEdenId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                _context.Add(sikayet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sikayet);
        }

        // GET: Sikayetler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.sikayetler == null)
            {
                return NotFound();
            }

            var sikayet = await _context.sikayetler.FindAsync(id);
            if (sikayet == null)
            {
                return NotFound();
            }
            return View(sikayet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Konu,SikayetEdilenId,SikayetEdenId,SikayetText")] Sikayet sikayet)
        {
            if (id != sikayet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {   
                    _context.Update(sikayet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SikayetExists(sikayet.Id))
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
            return View(sikayet);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.sikayetler == null)
            {
                return NotFound();
            }

            var sikayet = await _context.sikayetler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sikayet == null)
            {
                return NotFound();
            }

            return View(sikayet);
        }

        // POST: Sikayetler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.sikayetler == null)
            {
                return Problem("Entity set 'IdentityContext.sikayetler'  is null.");
            }
            var sikayet = await _context.sikayetler.FindAsync(id);
            if (sikayet != null)
            {
                _context.sikayetler.Remove(sikayet);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SikayetExists(int id)
        {
          return (_context.sikayetler?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
