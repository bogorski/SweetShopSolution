using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Data.Data.CMS
{
    public class Contact
    {
        [Key] 
        public int IdContact { get; set; }

        [Required(ErrorMessage = "Numer telefonu jest wymagany.")]
        [MaxLength(20, ErrorMessage = "Telefon może zawierac max 20 znaków.")]
        [Display(Name = "Telefon")] 
        public string Phone { get; set; }

        [Required(ErrorMessage = "Godziny kontaktu są wymagane.")]
        [MaxLength(200, ErrorMessage = "Godziny kontaktu może zawierac max 200 znaków.")]
        [Display(Name = "Godziny kontaktu")]
        public string ContactHours { get; set; }

        [Required(ErrorMessage = "Email jest wymagany.")]
        [MaxLength(100, ErrorMessage = "Email może zawierac max 100 znaków.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informacja o odpowiedzi jest wymagana.")]
        [MaxLength(200, ErrorMessage = "Informacja o odpowiedzi może zawierac max 200 znaków.")]
        [Display(Name = "Informacja o odpowiedzi")]
        public string ResponseInfo { get; set; }

        [Required(ErrorMessage = "Adres jest wymagany.")]
        [MaxLength(300, ErrorMessage = "Adres może zawierac max 300 znaków.")]
        [Display(Name = "Adres")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Godziny otwarcia są wymagane.")]
        [MaxLength(300, ErrorMessage = "Godziny otwarcia możą zawierac max 300 znaków.")]
        [Display(Name = "Godziny otwarcia")]
        public string OpeningHours { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }
    }
}
