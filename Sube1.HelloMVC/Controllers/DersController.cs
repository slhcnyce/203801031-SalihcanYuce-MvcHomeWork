using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sube1.HelloMVC.Models;
using Sube1.HelloMVC.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Sube1.HelloMVC.Controllers
{
    public class DersController : Controller
    {
        private readonly OkulDbContext _context;

        public DersController(OkulDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dersler = await _context.Dersler
                .Include(d => d.OgrenciDersler)
                .ThenInclude(od => od.Ogrenci)
                .ToListAsync();
            return View(dersler);
        }

        [HttpGet]
        public IActionResult AddDers()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddDers(Ders ders)
        {
            if (ders != null)
            {
                _context.Dersler.Add(ders);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ders);
        }

        [HttpGet]
        public async Task<IActionResult> EditDers(int id)
        {
            var ders = await _context.Dersler.FindAsync(id);
            if (ders == null)
            {
                return NotFound();
            }
            return View(ders);
        }

        [HttpPost]
        public async Task<IActionResult> EditDers(Ders ders)
        {
            if (ders != null)
            {
                _context.Update(ders);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ders);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteDers(int id)
        {
            var ders = await _context.Dersler.FindAsync(id);
            if (ders == null)
            {
                return NotFound();
            }
            _context.Dersler.Remove(ders);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var ders = await _context.Dersler
                .Include(d => d.OgrenciDersler)
                .ThenInclude(od => od.Ogrenci)
                .FirstOrDefaultAsync(m => m.Dersid == id);

            if (ders == null)
            {
                return NotFound();
            }

            return View(ders);
        }
    }
}
