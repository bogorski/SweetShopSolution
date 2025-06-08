using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Firma.Data.Data.CMS
{
    public class CompanyHistory
    {
        [Key]
        public int IdCompanyHistory { get; set; }

        [Required(ErrorMessage = "Nagłówek jest wymagany.")]
        [MaxLength(150, ErrorMessage = "Nagłówek może zawierac max 150 znaków.")]
        [Display(Name = "Nagłówek")]
        public string Header { get; set; }

        [Required(ErrorMessage = "Treść jest wymagana.")]
        [Display(Name = "Treść")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Contents { get; set; }

        [Required(ErrorMessage = "Adres URL zdjęcia jest wymagany.")]
        [Column(TypeName = "nvarchar(200)")]
        [Display(Name = "Adres URL")]
        public string? AdresURL { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }
    }
}
