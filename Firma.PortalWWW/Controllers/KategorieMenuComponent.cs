using Firma.Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Firma.PortalWWW.Controllers
{
    public class KategorieMenuComponent : ViewComponent
    {
        private readonly FirmaContext _context;

        public KategorieMenuComponent(FirmaContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("KategorieMenuComponent", await _context.Kategoria.ToListAsync());
        }
    }
}
