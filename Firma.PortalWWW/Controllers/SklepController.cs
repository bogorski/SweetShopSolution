using Firma.Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Firma.PortalWWW.Controllers
{
    public class SklepController : Controller
    {
        private readonly FirmaContext _context;
        public SklepController(FirmaContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int? id)
        {
            //ViewBag.ModelKategorie = await _context.Kategoria.ToListAsync();

            if (id == null)
            {
                return View(await _context.Produkt.ToListAsync());
            }
            
            var produktyDanejKategorii = await _context.Produkt.Where(p => p.IdKategorii == id).ToListAsync();
            
            return View(produktyDanejKategorii);
        }
        public async Task<IActionResult> Szczegoly(int id)
        {
            //ViewBag.ModelKategorie = await _context.Kategoria.ToListAsync();

            return View(await _context.Produkt.Where(p => p.IdProduktu == id).FirstOrDefaultAsync());
        }

    }
}
