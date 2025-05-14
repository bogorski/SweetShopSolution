using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Firma.Data.Data.Sklep
{
    public class Produkt
    {
        [Key]
        public int IdProduktu { get; set; }

        [Required(ErrorMessage = "Nazwa jest wymagana.")]
        [MaxLength(100, ErrorMessage = "Nazwa może zawierać maksymalnie 100 znaków.")]
        [Display(Name = "Nazwa")]
        public  required string Nazwa { get; set; }

        [Required(ErrorMessage = "Opis jest wymagany.")]
        [Column(TypeName = "nvarchar(MAX)")]
        [Display(Name = "Opis")]
        public required string Opis { get; set; }

        [Required(ErrorMessage = "Cena jest wymagana.")]
        [Column(TypeName = "money")]
        [Display(Name = "Cena")]
        public decimal Cena { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        [Display(Name = "Adres URL")]
        public string? AdresURL { get; set; }

        [Required(ErrorMessage = "Dostępność jest wymagana.")]
        [Display(Name = "Dostępność")]
        public bool Dostepnosc { get; set; }

        [ForeignKey("Kategoria")]
        public int IdKategorii { get; set; }
        public Kategoria? Kategoria { get; set; }
        public ICollection<ProduktSkladnik> ProduktSkladniki { get; set; } = new List<ProduktSkladnik>();
    }
}
