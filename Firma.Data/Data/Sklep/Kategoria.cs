using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Firma.Data.Data.Sklep
{
    public class Kategoria
    {
        [Key]
        public int IdKategorii { get; set; }

        [Required(ErrorMessage = "Nazwa jest wymagana.")]
        [MaxLength(100, ErrorMessage = "Nazwa może zawierać maksymalnie 100 znaków.")]
        [Display(Name = "Nazwa")]
        public required string Nazwa { get; set; }

        [Required(ErrorMessage = "Opis jest wymagany.")]
        [Column(TypeName = "nvarchar(MAX)")]
        [Display(Name = "Opis")]
        public required string Opis { get; set; }

        public ICollection<Produkt> Produkty { get; set; } = new List<Produkt>();
    }
}
