using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Firma.Data.Data.Sklep
{
    public class Reklamacja
    {
        [Key]
        public int IdReklamacji { get; set; }

        [Required(ErrorMessage = "Opis jest wymagany.")]
        [MaxLength(500, ErrorMessage = "Opis może zawierać maksymalnie 500 znaków.")]
        [Display(Name = "Opis")]
        public required string Opis { get; set; }

        [Required(ErrorMessage = "Data zgłoszenia jest wymagana.")]
        [Display(Name = "Data zgłoszenia")]
        public DateTime DataZgloszenia { get; set; }

        [ForeignKey("Zamowienie")]
        public int IdZamowienia { get; set; }
        public Zamowienie? Zamowienie { get; set; }
    }
}
