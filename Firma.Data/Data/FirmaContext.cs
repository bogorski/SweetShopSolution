using Firma.Data.Data.CMS;
using Firma.Data.Data.Sklep;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Firma.Data.Data
{
    public class FirmaContext : IdentityDbContext
    {
        public FirmaContext(DbContextOptions<FirmaContext> options)
            : base(options)
        {
        }

        public DbSet<Strona> Strona { get; set; } = default!;
        public DbSet<Aktualnosc> Aktualnosc { get; set; } = default!;
        public DbSet<ZdjecieGaleria> ZdjecieGaleria { get; set; } = default!;
        public DbSet<Cukiernia> Cukiernia { get; set; } = default!;
        public DbSet<Kategoria> Kategoria { get; set; } = default!;
        public DbSet<Zamowienie> Zamowienie { get; set; } = default!;
        public DbSet<Klient> Klient { get; set; } = default!;
        public DbSet<Produkt> Produkt { get; set; } = default!;
        public DbSet<ProduktSkladnik> ProduktSkladnik { get; set; } = default!;
        public DbSet<Skladnik> Skladnik { get; set; } = default!;
        public DbSet<Reklamacja> Reklamacja { get; set; } = default!;
    }
}
