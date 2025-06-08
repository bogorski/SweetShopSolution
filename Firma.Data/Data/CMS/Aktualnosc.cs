using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Firma.Data.Data.CMS
{
    public class Aktualnosc
    {
        [Key]
        public int IdAktualnosci { get; set; }

        [Required(ErrorMessage = "Tytuł aktualności jest wymagany.")]
        [MaxLength(50, ErrorMessage = "Tytuł może zawierac max 50 znaków.")]
        [Display(Name = "Tytuł aktualności")]
        public required string Tytul { get; set; }

        [Display(Name = "Treść")]
        [Column(TypeName = "nvarchar(MAX)")]
        public required string Tresc { get; set; }

        [Required(ErrorMessage = "Wpisz pozycję wyświetlania.")]
        [Display(Name = "Pozycja wyświetlania")]
        public int Pozycja { get; set; }

        [Required(ErrorMessage = "Adres URL zdjęcia jest wymagany.")]
        [Column(TypeName = "nvarchar(200)")]
        [Display(Name = "Adres URL")]
        public string? AdresURL { get; set; }
    }
}
