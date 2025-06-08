using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Firma.Data.Data.Sklep;
using Firma.Data.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Firma.PortalWWW.Controllers
{
    [Authorize]
    public class KoszykController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly FirmaContext _context;

        public KoszykController(UserManager<IdentityUser> userManager, FirmaContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var userEmail = User.Identity.Name;

            var klient = await _context.Klient
                .Include(k => k.Koszyki)
                .ThenInclude(kz => kz.Produkt)
                .FirstOrDefaultAsync(k => k.Email == userEmail);

            if (klient == null)
                return RedirectToAction("Login", "Account");

            var koszyk = klient.Koszyki;

            return View(koszyk);
        }


        // POST: /Koszyk/Dodaj
        [HttpPost]
        public async Task<IActionResult> Dodaj(int produktId, int ilosc = 1)
        {
            if (ilosc < 1) ilosc = 1;

            var klient = await GetKlientAsync();
            if (klient == null)
                return RedirectToAction("Login", "Account");

            var produkt = await _context.Produkt.FindAsync(produktId);
            if (produkt == null)
                return NotFound();

            var pozycja = await _context.Koszyk
                .FirstOrDefaultAsync(k => k.IdKlienta == klient.IdKlienta && k.IdProduktu == produktId);

            if (pozycja != null)
            {
                pozycja.Ilosc += ilosc;
                _context.Koszyk.Update(pozycja);
            }
            else
            {
                pozycja = new Koszyk
                {
                    IdKlienta = klient.IdKlienta,
                    IdProduktu = produktId,
                    Ilosc = ilosc,
                    DataDodania = DateTime.Now
                };
                _context.Koszyk.Add(pozycja);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // POST: /Koszyk/Usun/5
        [HttpPost]
        public async Task<IActionResult> Usun(int id)
        {
            var klient = await GetKlientAsync();
            if (klient == null)
                return RedirectToAction("Login", "Account");

            var pozycja = await _context.Koszyk
                .FirstOrDefaultAsync(k => k.IdKoszyka == id && k.IdKlienta == klient.IdKlienta);

            if (pozycja != null)
            {
                _context.Koszyk.Remove(pozycja);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<Klient?> GetKlientAsync()
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            if (string.IsNullOrEmpty(userEmail))
                return null;

            var klient = await _context.Klient.FirstOrDefaultAsync(k => k.Email == userEmail);
            return klient;
        }

        [HttpPost]
        public async Task<IActionResult> ZmienIlosc(int id, int ilosc)
        {
            var klient = await GetKlientAsync();

            var pozycja = await _context.Koszyk.FirstOrDefaultAsync(k => k.IdKoszyka == id && k.IdKlienta == klient.IdKlienta);
            if (pozycja != null && ilosc > 0)
            {
                pozycja.Ilosc = ilosc;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> ZlozZamowienie()
        {
            var klient = await GetKlientAsync();
            var koszyk = await _context.Koszyk
                .Include(k => k.Produkt)
                .Where(k => k.IdKlienta == klient.IdKlienta)
                .ToListAsync();

            if (!koszyk.Any())
            {
                TempData["Komunikat"] = "Koszyk jest pusty.";
                return RedirectToAction(nameof(Index));
            }

            var dataOdbioru = DateTime.Now.AddDays(1);
            if (dataOdbioru.DayOfWeek == DayOfWeek.Saturday)
                dataOdbioru = dataOdbioru.AddDays(2);
            else if (dataOdbioru.DayOfWeek == DayOfWeek.Sunday)
                dataOdbioru = dataOdbioru.AddDays(1);
            var kwota = koszyk.Sum(p => p.Ilosc * p.Produkt.Cena);

            var zamowienie = new Zamowienie
            {
                IdKlienta = klient.IdKlienta,
                Numer = $"ZAM-{DateTime.Now:yyyyMMddHHmmss}",
                DataZamowienia = DateTime.Now,
                DataOdbioru = dataOdbioru,
                Status = "Nowe",
                Kwota = kwota,
                Uwagi = "",
                ZamowieniePozycja = koszyk.Select(p => new ZamowieniePozycja
                {
                    IdProduktu = p.IdProduktu,
                    Ilosc = p.Ilosc,
                    Cena = p.Produkt.Cena
                }).ToList()
            };

            _context.Zamowienie.Add(zamowienie);
            _context.Koszyk.RemoveRange(koszyk);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Podsumowanie), new { id = zamowienie.IdZamowienia });
        }

        public async Task<IActionResult> Podsumowanie(int id)
        {
            var zamowienie = await _context.Zamowienie
                .Include(z => z.ZamowieniePozycja)
                .ThenInclude(p => p.Produkt)
                .Include(z => z.Klient)
                .FirstOrDefaultAsync(z => z.IdZamowienia == id);

            if (zamowienie == null)
                return NotFound();

            return View("Podsumowanie", zamowienie);
        }
    }
}