using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Firma.Data.Data.Sklep
{
    public class Zamowienie
    {
        [Key]
        public int IdZamowienia { get; set; }

        [Required(ErrorMessage = "Numer zamówienia jest wymagany.")]
        [MaxLength(50, ErrorMessage = "Numer zamówienia może zawierać maksymalnie 50 znaków.")]
        [Display(Name = "Numer zamówienia")]
        public required string Numer { get; set; }

        [Required(ErrorMessage = "Kwota jest wymagana.")]
        [Column(TypeName = "money")]
        [Display(Name = "Kwota")]
        public decimal Kwota { get; set; }

        [Required(ErrorMessage = "Status zamówienia jest wymagany.")]
        [MaxLength(50, ErrorMessage = "Status może zawierać maksymalnie 50 znaków.")]
        [Display(Name = "Status")]
        public required string Status { get; set; }

        [Required(ErrorMessage = "Data zamówienia jest wymagana.")]
        [Display(Name = "Data zamówienia")]
        public DateTime DataZamowienia { get; set; }

        [Required(ErrorMessage = "Data odbioru jest wymagana.")]
        [Display(Name = "Data odbioru")]
        public DateTime DataOdbioru { get; set; }

        [Required(ErrorMessage = "Uwagi są wymagane.")]
        [MaxLength(300, ErrorMessage = "Uwagi mogą zawierać maksymalnie 300 znaków.")]
        [Display(Name = "Uwagi")]
        public string? Uwagi { get; set; }

        [ForeignKey("Klient")]
        public int IdKlienta { get; set; }
        public  Klient? Klient { get; set; }
    }
}
