using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Data.Data;
using Firma.Data.Data.CMS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Firma.Intranet.Controllers
{
    public class PomocController : Controller
    {
        private readonly FirmaContext _context;

        public PomocController(FirmaContext context)
        {
            _context = context;
        }

        // GET: Pomoc
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pomoc.ToListAsync());
        }

        // GET: Pomoc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pomoc = await _context.Pomoc
                .FirstOrDefaultAsync(m => m.IdPomocy == id);
            if (pomoc == null)
            {
                return NotFound();
            }

            return View(pomoc);
        }

        // GET: Pomoc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pomoc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPomocy,LinkTytul,Tytul,Tresc,Pozycja")] Pomoc pomoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pomoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pomoc);
        }

        // GET: Pomoc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pomoc = await _context.Pomoc.FindAsync(id);
            if (pomoc == null)
            {
                return NotFound();
            }
            return View(pomoc);
        }

        // POST: Pomoc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPomocy,LinkTytul,Tytul,Tresc,Pozycja")] Pomoc pomoc)
        {
            if (id != pomoc.IdPomocy)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pomoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PomocExists(pomoc.IdPomocy))
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
            return View(pomoc);
        }

        // GET: Pomoc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pomoc = await _context.Pomoc
                .FirstOrDefaultAsync(m => m.IdPomocy == id);
            if (pomoc == null)
            {
                return NotFound();
            }

            return View(pomoc);
        }

        // POST: Pomoc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pomoc = await _context.Pomoc.FindAsync(id);
            if (pomoc != null)
            {
                _context.Pomoc.Remove(pomoc);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PomocExists(int id)
        {
            return _context.Pomoc.Any(e => e.IdPomocy == id);
        }
    }
}
