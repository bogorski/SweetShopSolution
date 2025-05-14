using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Firma.Data.Data.Sklep
{
    public class Skladnik
    {
        [Key]
        public int IdSkladnika { get; set; }

        [Required(ErrorMessage = "Nazwa jest wymagana.")]
        [MaxLength(100, ErrorMessage = "Nazwa może zawierać maksymalnie 100 znaków.")]
        [Display(Name = "Nazwa")]
        public required string Nazwa { get; set; }

        [Required(ErrorMessage = "Jednostka jest wymagana.")]
        [MaxLength(20, ErrorMessage = "Jednostka może zawierać maksymalnie 20 znaków.")]
        [Display(Name = "Jednostka")]
        public required string Jednostka { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        [Display(Name = "Adres URL")]
        public string? AdresURL { get; set; }

        public ICollection<ProduktSkladnik>? ProduktSkladniki { get; set; } = new List<ProduktSkladnik>();
    }
}
