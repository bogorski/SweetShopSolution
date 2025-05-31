using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Firma.Data.Data.Sklep
{
    public class ZamowieniePozycja
    {
        [Key]
        public int IdZamowieniePozycja { get; set; }

        [ForeignKey("Zamowienie")]
        public int IdZamowienia { get; set; }
        public Zamowienie? Zamowienie { get; set; }

        [ForeignKey("Produkt")]
        public int IdProduktu { get; set; }
        public Produkt? Produkt { get; set; }

        [Required(ErrorMessage = "Ilość jest wymagana.")]
        [Display(Name = "Ilosc")]
        public int Ilosc { get; set; }

        [Required(ErrorMessage = "Cena jest wymagana.")]
        [Display(Name = "Cena")]
        [Column(TypeName = "money")]
        public decimal Cena { get; set; }
    }
}
