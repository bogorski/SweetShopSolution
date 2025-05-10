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
    public class CukierniaController : Controller
    {
        private readonly FirmaContext _context;

        public CukierniaController(FirmaContext context)
        {
            _context = context;
        }

        // GET: Cukiernia
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cukiernia.ToListAsync());
        }

        // GET: Cukiernia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cukiernia = await _context.Cukiernia
                .FirstOrDefaultAsync(m => m.IdCukierni == id);
            if (cukiernia == null)
            {
                return NotFound();
            }

            return View(cukiernia);
        }

        // GET: Cukiernia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cukiernia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCukierni,Nazwa,Adres,Telefon,Email,Opis,GodzinyOtwarcia,FotoUrl")] Cukiernia cukiernia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cukiernia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cukiernia);
        }

        // GET: Cukiernia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cukiernia = await _context.Cukiernia.FindAsync(id);
            if (cukiernia == null)
            {
                return NotFound();
            }
            return View(cukiernia);
        }

        // POST: Cukiernia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCukierni,Nazwa,Adres,Telefon,Email,Opis,GodzinyOtwarcia,FotoUrl")] Cukiernia cukiernia)
        {
            if (id != cukiernia.IdCukierni)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cukiernia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CukierniaExists(cukiernia.IdCukierni))
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
            return View(cukiernia);
        }

        // GET: Cukiernia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cukiernia = await _context.Cukiernia
                .FirstOrDefaultAsync(m => m.IdCukierni == id);
            if (cukiernia == null)
            {
                return NotFound();
            }

            return View(cukiernia);
        }

        // POST: Cukiernia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cukiernia = await _context.Cukiernia.FindAsync(id);
            if (cukiernia != null)
            {
                _context.Cukiernia.Remove(cukiernia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CukierniaExists(int id)
        {
            return _context.Cukiernia.Any(e => e.IdCukierni == id);
        }
    }
}
