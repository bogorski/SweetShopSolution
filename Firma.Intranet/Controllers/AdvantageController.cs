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
    public class AdvantageController : Controller
    {
        private readonly FirmaContext _context;

        public AdvantageController(FirmaContext context)
        {
            _context = context;
        }

        // GET: Advantage
        public async Task<IActionResult> Index()
        {
            var advantage = await _context.Advantage
                .OrderBy(a => a.DisplayOrder)
                .ToListAsync();

            return View(advantage);
        }

        // GET: Advantage/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advantage = await _context.Advantage
                .FirstOrDefaultAsync(m => m.IdAdvantage == id);
            if (advantage == null)
            {
                return NotFound();
            }

            return View(advantage);
        }

        // GET: Advantage/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Advantage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAdvantage,Icon,Header,Contents,DisplayOrder,IsActive,CreatedAt,UpdatedAt")] Advantage advantage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(advantage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(advantage);
        }

        // GET: Advantage/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advantage = await _context.Advantage.FindAsync(id);
            if (advantage == null)
            {
                return NotFound();
            }
            return View(advantage);
        }

        // POST: Advantage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAdvantage,Icon,Header,Contents,DisplayOrder,IsActive,CreatedAt,UpdatedAt")] Advantage advantage)
        {
            if (id != advantage.IdAdvantage)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(advantage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdvantageExists(advantage.IdAdvantage))
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
            return View(advantage);
        }

        // GET: Advantage/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advantage = await _context.Advantage
                .FirstOrDefaultAsync(m => m.IdAdvantage == id);
            if (advantage == null)
            {
                return NotFound();
            }

            return View(advantage);
        }

        // POST: Advantage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var advantage = await _context.Advantage.FindAsync(id);
            if (advantage != null)
            {
                _context.Advantage.Remove(advantage);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdvantageExists(int id)
        {
            return _context.Advantage.Any(e => e.IdAdvantage == id);
        }
    }
}
