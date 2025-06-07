﻿using Firma.Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Firma.PortalWWW.Controllers
{
    public class FooterComponent : ViewComponent
    {
        private readonly FirmaContext _context;

        public FooterComponent(FirmaContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("FooterComponent", await _context.Kategoria.ToListAsync());
        }
    }
}