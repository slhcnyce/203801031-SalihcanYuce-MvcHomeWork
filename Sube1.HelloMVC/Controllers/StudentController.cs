using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sube1.HelloMVC.Models;
using Sube1.HelloMVC.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Sube1.HelloMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly OkulDbContext _context;

        public StudentController(OkulDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var students = await _context.Ogrenciler
                .Include(o => o.OgrenciDersler)
                .ThenInclude(od => od.Ders)
                .ToListAsync();
            return View(students);
        }

        [HttpGet]
        public IActionResult AddOgrenci()
        {
            var viewModel = new OgrenciViewModel
            {
                Ogrenci = new Ogrenci(),
                Dersler = _context.Dersler.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddOgrenci(OgrenciViewModel viewModel)
        {
            if (viewModel != null)
            {
                var ogrenci = new Ogrenci
                {
                    Ad = viewModel.Ogrenci.Ad,
                    Soyad = viewModel.Ogrenci.Soyad,
                    Numara = viewModel.Ogrenci.Numara,
                    OgrenciDersler = viewModel.SelectedDersler.Select(dersId => new OgrenciDers { Dersid = dersId }).ToList()
                };

                _context.Ogrenciler.Add(ogrenci);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            viewModel.Dersler = await _context.Dersler.ToListAsync();
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> EditStudent(int id)
        {
            var ogrenci = await _context.Ogrenciler
                .Include(o => o.OgrenciDersler)
                .ThenInclude(od => od.Ders)
                .FirstOrDefaultAsync(o => o.Ogrenciid == id);

            if (ogrenci == null)
            {
                return NotFound();
            }

            var selectedDersler = ogrenci.OgrenciDersler.Select(od => od.Dersid).ToList();

            var viewModel = new OgrenciViewModel
            {
                Ogrenci = ogrenci,
                SelectedDersler = selectedDersler,
                Dersler = await _context.Dersler.ToListAsync()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditStudent(OgrenciViewModel viewModel)
        {
            if (viewModel != null)
            {
                var existingOgrenci = await _context.Ogrenciler
                    .Include(o => o.OgrenciDersler)
                    .FirstOrDefaultAsync(o => o.Ogrenciid == viewModel.Ogrenci.Ogrenciid);

                if (existingOgrenci == null)
                {
                    return NotFound();
                }

                existingOgrenci.Ad = viewModel.Ogrenci.Ad;
                existingOgrenci.Soyad = viewModel.Ogrenci.Soyad;
                existingOgrenci.Numara = viewModel.Ogrenci.Numara;

                existingOgrenci.OgrenciDersler.Clear();

                if (viewModel.SelectedDersler != null)
                {
                    foreach (var dersId in viewModel.SelectedDersler)
                    {
                        existingOgrenci.OgrenciDersler.Add(new OgrenciDers { Ogrenciid = viewModel.Ogrenci.Ogrenciid, Dersid = dersId });
                    }
                }

                _context.Update(existingOgrenci);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            viewModel.Dersler = await _context.Dersler.ToListAsync();
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var ogrenci = await _context.Ogrenciler.FindAsync(id);
            if (ogrenci != null)
            {
                _context.Ogrenciler.Remove(ogrenci);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
