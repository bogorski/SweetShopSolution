using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Data.Data.CMS
{
    public class ZdjecieGaleria
    {
        [Key]
        public int IdZdjecia { get; set; }

        [Required(ErrorMessage = "Nazwa zdjęcia jest wymagana.")]
        [MaxLength(20, ErrorMessage = "Nazwa zdjęcia może zawierac max 20 znaków.")]
        [Display(Name = "Nazwa zdjęcia")]
        public required string Nazwa { get; set; }

        [Required(ErrorMessage = "Wpisz pozycję wyświetlania.")]
        [Display(Name = "Pozycja wyświetlania")]
        public int Pozycja { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        [Display(Name = "Adres URL")]
        public string? AdresURL { get; set; }
    }
}
