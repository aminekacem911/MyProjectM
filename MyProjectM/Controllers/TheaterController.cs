using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProjectM.Data;
using MyProjectM.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MyProjectM.Controllers
{
    public class TheaterController : Controller
    {
        private readonly AuthContext _context;
        public TheaterController(AuthContext context)
        {
            _context = context;
        }
        
        [HttpGet("/Admin/Theater")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.theater.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var theater = await _context.theater
                .FirstOrDefaultAsync(m => m.TheaterID == id);
            if (theater == null)
            {
                return NotFound();
            }

            return View(theater);
        }

        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Place,Capacity")] Theater theater)
        {
            if (ModelState.IsValid)
            {
                _context.Add(theater);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(theater);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var theater = await _context.theater.FindAsync(id);
            if (theater == null)
            {
                return NotFound();
            }
            return View(theater);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Place,Capacity")] Theater theater)
        {
            if (id != theater.TheaterID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(theater);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TheaterExists(theater.TheaterID))
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
            return View(theater);
        }

        private bool TheaterExists(int id)
        {
            return _context.theater.Any(e => e.TheaterID == id);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var theater = await _context.theater
                .FirstOrDefaultAsync(m => m.TheaterID == id);
            if (theater == null)
            {
                return NotFound();
            }

            return View(theater);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var theater = await _context.theater.FindAsync(id);
            _context.theater.Remove(theater);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
