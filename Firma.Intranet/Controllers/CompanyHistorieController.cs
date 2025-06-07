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
    public class CompanyHistorieController : Controller
    {
        private readonly FirmaContext _context;

        public CompanyHistorieController(FirmaContext context)
        {
            _context = context;
        }

        // GET: CompanyHistorie
        public async Task<IActionResult> Index()
        {
            return View(await _context.CompanyHistory.ToListAsync());
        }

        // GET: CompanyHistorie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyHistory = await _context.CompanyHistory
                .FirstOrDefaultAsync(m => m.IdCompanyHistory == id);
            if (companyHistory == null)
            {
                return NotFound();
            }

            return View(companyHistory);
        }

        // GET: CompanyHistorie/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CompanyHistorie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCompanyHistory,Header,Contents,AdresURL,CreatedAt,UpdatedAt")] CompanyHistory companyHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(companyHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(companyHistory);
        }

        // GET: CompanyHistorie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyHistory = await _context.CompanyHistory.FindAsync(id);
            if (companyHistory == null)
            {
                return NotFound();
            }
            return View(companyHistory);
        }

        // POST: CompanyHistorie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCompanyHistory,Header,Contents,AdresURL,CreatedAt,UpdatedAt")] CompanyHistory companyHistory)
        {
            if (id != companyHistory.IdCompanyHistory)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(companyHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyHistoryExists(companyHistory.IdCompanyHistory))
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
            return View(companyHistory);
        }

        // GET: CompanyHistorie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyHistory = await _context.CompanyHistory
                .FirstOrDefaultAsync(m => m.IdCompanyHistory == id);
            if (companyHistory == null)
            {
                return NotFound();
            }

            return View(companyHistory);
        }

        // POST: CompanyHistorie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var companyHistory = await _context.CompanyHistory.FindAsync(id);
            if (companyHistory != null)
            {
                _context.CompanyHistory.Remove(companyHistory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyHistoryExists(int id)
        {
            return _context.CompanyHistory.Any(e => e.IdCompanyHistory == id);
        }
    }
}
