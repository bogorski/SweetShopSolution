using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Firma.Data.Data.Sklep
{ 
    public class Cukiernia
    {
        [Key]
        public int IdCukierni { get; set; }

        [Required(ErrorMessage = "Nazwa jest wymagana.")]
        [MaxLength(100, ErrorMessage = "Nazwa może zawierać maksymalnie 100 znaków.")]
        [Display(Name = "Nazwa")]
        public required string Nazwa { get; set; }

        [Required(ErrorMessage = "Adres jest wymagany.")]
        [MaxLength(200, ErrorMessage = "Adres może zawierać maksymalnie 200 znaków.")]
        [Display(Name = "Adres")]
        public required string Adres { get; set; }

        [Required(ErrorMessage = "Telefon jest wymagany.")]
        [Phone(ErrorMessage = "Wprowadź poprawny numer telefonu.")]
        [MaxLength(20, ErrorMessage = "Telefon może zawierać maksymalnie 20 znaków.")]
        [Display(Name = "Telefon")]
        public required string Telefon { get; set; }

        [Required(ErrorMessage = "E-mail jest wymagany.")]
        [EmailAddress(ErrorMessage = "Wprowadź poprawny adres e-mail.")]
        [MaxLength(100, ErrorMessage = "E-mail może zawierać maksymalnie 100 znaków.")]
        [Display(Name = "E-mail")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Opis jest wymagany.")]
        [MaxLength(300, ErrorMessage = "Opis może zawierać maksymalnie 300 znaków.")]
        [Display(Name = "Opis")]
        public required string Opis { get; set; }

        [Required(ErrorMessage = "Godziny otwarcia są wymagane.")]
        [Column(TypeName = "nvarchar(MAX)")]
        [Display(Name = "Godziny otwarcia")]
        public required string GodzinyOtwarcia { get; set; }

        [Required(ErrorMessage = "Zdjęcie jest wymagane.")]
        [MaxLength(200, ErrorMessage = "Adres zdjęcia może zawierać maksymalnie 200 znaków.")]
        [Column(TypeName = "nvarchar(200)")]
        [Display(Name = "Zdjęcie")]
        public string AdresURL { get; set; }

        [Required(ErrorMessage = "IFrame Google Map jest wymagane.")]
        [MaxLength(500, ErrorMessage = "IFrame Google Map może zawierać maksymalnie 500 znaków.")]
        [Column(TypeName = "nvarchar(500)")]
        [Display(Name = "Google Map")]
        public string IFrameGoogleMap { get; set; }
    }

}
