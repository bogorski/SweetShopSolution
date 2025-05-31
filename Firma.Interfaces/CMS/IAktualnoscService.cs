using System.Collections;
using Firma.Data.Data.CMS;

namespace Firma.Interfaces.CMS
{
    public interface IAktualnoscService
    {
        Task<IList<Aktualnosc>> GetAktualnoscByPozycjaTake(int ilePobrac);
        Task<Aktualnosc?> GetAktualnosc(int idAktualnosci);
    }
}
