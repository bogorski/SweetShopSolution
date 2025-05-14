using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Firma.Data.Data;
using Firma.Data.Data.CMS;

namespace Firma.Intranet.Controllers
{
    public class ZdjecieGaleriaController : Controller
    {
        private readonly FirmaContext _context;

        public ZdjecieGaleriaController(FirmaContext context)
        {
            _context = context;
        }

        // GET: ZdjecieGaleria
        public async Task<IActionResult> Index()
        {
            return View(await _context.ZdjecieGaleria.ToListAsync());
        }

        // GET: ZdjecieGaleria/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zdjecieGaleria = await _context.ZdjecieGaleria
                .FirstOrDefaultAsync(m => m.IdZdjecia == id);
            if (zdjecieGaleria == null)
            {
                return NotFound();
            }

            return View(zdjecieGaleria);
        }

        // GET: ZdjecieGaleria/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ZdjecieGaleria/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdZdjecia,Nazwa,Pozycja,AdresURL")] ZdjecieGaleria zdjecieGaleria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zdjecieGaleria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zdjecieGaleria);
        }

        // GET: ZdjecieGaleria/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zdjecieGaleria = await _context.ZdjecieGaleria.FindAsync(id);
            if (zdjecieGaleria == null)
            {
                return NotFound();
            }
            return View(zdjecieGaleria);
        }

        // POST: ZdjecieGaleria/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdZdjecia,Nazwa,Pozycja,AdresURL")] ZdjecieGaleria zdjecieGaleria)
        {
            if (id != zdjecieGaleria.IdZdjecia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zdjecieGaleria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZdjecieGaleriaExists(zdjecieGaleria.IdZdjecia))
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
            return View(zdjecieGaleria);
        }

        // GET: ZdjecieGaleria/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zdjecieGaleria = await _context.ZdjecieGaleria
                .FirstOrDefaultAsync(m => m.IdZdjecia == id);
            if (zdjecieGaleria == null)
            {
                return NotFound();
            }

            return View(zdjecieGaleria);
        }

        // POST: ZdjecieGaleria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zdjecieGaleria = await _context.ZdjecieGaleria.FindAsync(id);
            if (zdjecieGaleria != null)
            {
                _context.ZdjecieGaleria.Remove(zdjecieGaleria);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZdjecieGaleriaExists(int id)
        {
            return _context.ZdjecieGaleria.Any(e => e.IdZdjecia == id);
        }
    }
}
