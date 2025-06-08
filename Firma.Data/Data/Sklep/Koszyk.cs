using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Firma.Data.Data.Sklep
{
    public class Koszyk
    {
        [Key]
        public int IdKoszyka { get; set; }

        [ForeignKey("Produkt")]
        public int IdProduktu { get; set; }
        public Produkt? Produkt { get; set; }


        [ForeignKey("Klient")]
        public int IdKlienta { get; set; }
        public Klient? Klient { get; set; }

        [Required(ErrorMessage = "Ilosc jest wymagana.")]
        [Display(Name = "Ilosc")]
        public int Ilosc { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        [Display(Name = "Uwagi")]
        public string? Uwagi { get; set; }

        [Required]
        [Display(Name = "Data dodania")]
        public DateTime DataDodania { get; set; } = DateTime.Now;

    }
}
