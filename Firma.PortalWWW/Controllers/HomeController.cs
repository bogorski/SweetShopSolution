using System.Diagnostics;
using Firma.Data.Data;
using Firma.PortalWWW.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Firma.PortalWWW.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FirmaContext _context;
        public HomeController(ILogger<HomeController> logger, FirmaContext firmaContext)
        {
            _logger = logger;
            _context = firmaContext;
        }

        public async Task<IActionResult> Index(int? id)
        {
            ViewBag.ModelStrony = await _context.Strona
                .OrderBy(s => s.Pozycja)
                .ToListAsync();

            ViewBag.ModelAktualnosci = await _context.Aktualnosc
                .OrderByDescending(a => a.Pozycja)
                .ToListAsync();

            ViewBag.ModelGaleria = await _context.ZdjecieGaleria
                .OrderByDescending(z => z.Pozycja)
                .Take(6)
                .ToListAsync();

            ViewBag.ModelCukiernia = await _context.Cukiernia
                .OrderByDescending(c => c.IdCukierni)
                .ToListAsync();

            if (id == null)
            {
                id = 1;
            }
            var item = await _context.Strona.FindAsync(id);

            return View(item);
        }

        public async Task<IActionResult> Cukiernie()
        {
            var cukiernie = await _context.Cukiernia.ToListAsync();
            return View(cukiernie);
        }

        public async Task<IActionResult> Skladniki()
        {
            var skladniki = await _context.Skladnik.ToListAsync();
            return View(skladniki);
        }

        public IActionResult Kontakt()
        {
            return View();
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
