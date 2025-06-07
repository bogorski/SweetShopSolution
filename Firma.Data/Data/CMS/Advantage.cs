using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Firma.Data.Data.CMS
{
    public class Advantage
    {
        [Key]
        public int IdAdvantage { get; set; }

        [MaxLength(50)]
        public string? Icon { get; set; }

        [Required(ErrorMessage = "Nagłówek jest wymagany.")]
        [MaxLength(50, ErrorMessage = "Nagłówek może zawierac max 50 znaków.")]
        [Display(Name = "Nagłówek")]
        public string Header { get; set; }

        [Required(ErrorMessage = "Treść jest wymagana.")]
        [Display(Name = "Treść")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Contents { get; set; }

        [Required(ErrorMessage = "Wpisz pozycję wyświetlania.")]
        [Display(Name = "Pozycja wyświetlania")]
        public int DisplayOrder { get; set; }

        public bool IsActive { get; set; } = true;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }
    }
}
