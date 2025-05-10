using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Firma.Data.Data.CMS
{
    public class Aktualnosc
    {
        [Key]
        public int IdAktualnosci { get; set; }

        [Required(ErrorMessage = "Tytuł odnośnika jest wymagany.")]
        [MaxLength(10, ErrorMessage = "Link może zawierac max 10 znaków.")]
        [Display(Name = "Tytuł odnośnika")]
        public required string LinkTytul { get; set; }

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
    }
}
