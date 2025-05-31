using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firma.Data.Data;

namespace Firma.Services.Abstrakcja
{
    public abstract class BaseService
    {
        protected readonly FirmaContext _context;
        public BaseService(FirmaContext context)
        {
            _context = context;
        }
    }
}
