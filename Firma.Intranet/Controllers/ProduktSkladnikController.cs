using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Data.Data;
using Firma.Data.Data.Sklep;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Firma.Intranet.Controllers
{
    public class ProduktSkladnikController : Controller
    {
        private readonly FirmaContext _context;

        public ProduktSkladnikController(FirmaContext context)
        {
            _context = context;
        }

        // GET: ProduktSkladnik
        public async Task<IActionResult> Index()
        {
            var firmaIntranetContext = _context.ProduktSkladnik.Include(p => p.Produkt).Include(p => p.Skladnik);
            return View(await firmaIntranetContext.ToListAsync());
        }

        // GET: ProduktSkladnik/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produktSkladnik = await _context.ProduktSkladnik
                .Include(p => p.Produkt)
                .Include(p => p.Skladnik)
                .FirstOrDefaultAsync(m => m.IdProduktSkladniki == id);
            if (produktSkladnik == null)
            {
                return NotFound();
            }

            return View(produktSkladnik);
        }

        // GET: ProduktSkladnik/Create
        public IActionResult Create()
        {
            ViewData["IdProduktu"] = new SelectList(_context.Produkt, "IdProduktu", "Nazwa");
            ViewData["IdSkladnika"] = new SelectList(_context.Skladnik, "IdSkladnika", "Jednostka");
            return View();
        }

        // POST: ProduktSkladnik/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProduktSkladniki,IloscWymagana,IdProduktu,IdSkladnika")] ProduktSkladnik produktSkladnik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produktSkladnik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProduktu"] = new SelectList(_context.Produkt, "IdProduktu", "Nazwa", produktSkladnik.IdProduktu);
            ViewData["IdSkladnika"] = new SelectList(_context.Skladnik, "IdSkladnika", "Jednostka", produktSkladnik.IdSkladnika);
            return View(produktSkladnik);
        }

        // GET: ProduktSkladnik/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produktSkladnik = await _context.ProduktSkladnik.FindAsync(id);
            if (produktSkladnik == null)
            {
                return NotFound();
            }
            ViewData["IdProduktu"] = new SelectList(_context.Produkt, "IdProduktu", "Nazwa", produktSkladnik.IdProduktu);
            ViewData["IdSkladnika"] = new SelectList(_context.Skladnik, "IdSkladnika", "Jednostka", produktSkladnik.IdSkladnika);
            return View(produktSkladnik);
        }

        // POST: ProduktSkladnik/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProduktSkladniki,IloscWymagana,IdProduktu,IdSkladnika")] ProduktSkladnik produktSkladnik)
        {
            if (id != produktSkladnik.IdProduktSkladniki)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produktSkladnik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProduktSkladnikExists(produktSkladnik.IdProduktSkladniki))
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
            ViewData["IdProduktu"] = new SelectList(_context.Produkt, "IdProduktu", "Nazwa", produktSkladnik.IdProduktu);
            ViewData["IdSkladnika"] = new SelectList(_context.Skladnik, "IdSkladnika", "Jednostka", produktSkladnik.IdSkladnika);
            return View(produktSkladnik);
        }

        // GET: ProduktSkladnik/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produktSkladnik = await _context.ProduktSkladnik
                .Include(p => p.Produkt)
                .Include(p => p.Skladnik)
                .FirstOrDefaultAsync(m => m.IdProduktSkladniki == id);
            if (produktSkladnik == null)
            {
                return NotFound();
            }

            return View(produktSkladnik);
        }

        // POST: ProduktSkladnik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produktSkladnik = await _context.ProduktSkladnik.FindAsync(id);
            if (produktSkladnik != null)
            {
                _context.ProduktSkladnik.Remove(produktSkladnik);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProduktSkladnikExists(int id)
        {
            return _context.ProduktSkladnik.Any(e => e.IdProduktSkladniki == id);
        }
    }
}
