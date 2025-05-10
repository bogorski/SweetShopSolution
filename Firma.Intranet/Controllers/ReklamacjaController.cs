using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Firma.Data.Data;
using Firma.Data.Data.Sklep;

namespace Firma.Intranet.Controllers
{
    public class ReklamacjaController : Controller
    {
        private readonly FirmaContext _context;

        public ReklamacjaController(FirmaContext context)
        {
            _context = context;
        }

        // GET: Reklamacja
        public async Task<IActionResult> Index()
        {
            var firmaIntranetContext = _context.Reklamacja.Include(r => r.Zamowienie);
            return View(await firmaIntranetContext.ToListAsync());
        }

        // GET: Reklamacja/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reklamacja = await _context.Reklamacja
                .Include(r => r.Zamowienie)
                .FirstOrDefaultAsync(m => m.IdReklamacji == id);
            if (reklamacja == null)
            {
                return NotFound();
            }

            return View(reklamacja);
        }

        // GET: Reklamacja/Create
        public IActionResult Create()
        {
            ViewData["IdZamowienia"] = new SelectList(_context.Zamowienie, "IdZamowienia", "Numer");
            return View();
        }

        // POST: Reklamacja/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdReklamacji,Opis,DataZgloszenia,IdZamowienia")] Reklamacja reklamacja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reklamacja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdZamowienia"] = new SelectList(_context.Zamowienie, "IdZamowienia", "Numer", reklamacja.IdZamowienia);
            return View(reklamacja);
        }

        // GET: Reklamacja/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reklamacja = await _context.Reklamacja.FindAsync(id);
            if (reklamacja == null)
            {
                return NotFound();
            }
            ViewData["IdZamowienia"] = new SelectList(_context.Zamowienie, "IdZamowienia", "Numer", reklamacja.IdZamowienia);
            return View(reklamacja);
        }

        // POST: Reklamacja/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdReklamacji,Opis,DataZgloszenia,IdZamowienia")] Reklamacja reklamacja)
        {
            if (id != reklamacja.IdReklamacji)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reklamacja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReklamacjaExists(reklamacja.IdReklamacji))
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
            ViewData["IdZamowienia"] = new SelectList(_context.Zamowienie, "IdZamowienia", "Numer", reklamacja.IdZamowienia);
            return View(reklamacja);
        }

        // GET: Reklamacja/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reklamacja = await _context.Reklamacja
                .Include(r => r.Zamowienie)
                .FirstOrDefaultAsync(m => m.IdReklamacji == id);
            if (reklamacja == null)
            {
                return NotFound();
            }

            return View(reklamacja);
        }

        // POST: Reklamacja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reklamacja = await _context.Reklamacja.FindAsync(id);
            if (reklamacja != null)
            {
                _context.Reklamacja.Remove(reklamacja);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReklamacjaExists(int id)
        {
            return _context.Reklamacja.Any(e => e.IdReklamacji == id);
        }
    }
}
