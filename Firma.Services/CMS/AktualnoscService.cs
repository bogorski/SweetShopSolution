using Firma.Data.Data;
using Firma.Data.Data.CMS;
using Firma.Interfaces.CMS;
using Firma.Services.Abstrakcja;
using Microsoft.EntityFrameworkCore;

namespace Firma.Services.CMS
{
    public class AktualnoscService : BaseService, IAktualnoscService
    {
        public AktualnoscService(FirmaContext context) 
            : base(context)
        {
        }
        public async Task<IList<Aktualnosc>> GetAktualnoscByPozycjaTake(int ilePobrac)
        {
            var aklualnosci = await _context.Aktualnosc
                .OrderByDescending(a => a.Pozycja)
                .Take(ilePobrac)
                .ToListAsync();

            return aklualnosci;
        }
        public async Task<Aktualnosc?> GetAktualnosc(int idAktualnosci)
        {
            var aktualnosc = await _context.Aktualnosc.FirstOrDefaultAsync(a => a.IdAktualnosci == idAktualnosci);
            return aktualnosc;
        }
    }
}
