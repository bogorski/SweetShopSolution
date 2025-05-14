using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Firma.Data.Data.Sklep
{
    public class ProduktSkladnik
    {
        [Key]
        public int IdProduktSkladniki { get; set; }

        [Required(ErrorMessage = "Ilość jest wymagana.")]
        [Display(Name = "Ilość wymagana")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal IloscWymagana { get; set; }

        [ForeignKey("Produkt")]
        public int IdProduktu { get; set; }
        public  Produkt? Produkt { get; set; }

        [ForeignKey("Skladnik")]
        public int IdSkladnika { get; set; }
        public  Skladnik? Skladnik { get; set; }
    }

}
