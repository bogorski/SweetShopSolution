using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Firma.Data.Data.Sklep
{
    public class Klient
    {
        [Key]
        public int IdKlienta { get; set; }

        [ForeignKey("Uzytkownik")]
        public string IdentityUserId { get; set; } = null!;
        public IdentityUser? Uzytkownik { get; set; }

        [Required(ErrorMessage = "Imię jest wymagane.")]
        [MaxLength(50, ErrorMessage = "Imię może zawierać maksymalnie 50 znaków.")]
        [Display(Name = "Imię")]
        public required string Imie { get; set; }

        [Required(ErrorMessage = "Nazwisko jest wymagane.")]
        [MaxLength(50, ErrorMessage = "Nazwisko może zawierać maksymalnie 50 znaków.")]
        [Display(Name = "Nazwisko")]
        public required string Nazwisko { get; set; }

        [Required(ErrorMessage = "Adres jest wymagany.")]
        [MaxLength(100, ErrorMessage = "Adres może zawierać maksymalnie 100 znaków.")]
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

        [Required(ErrorMessage = "Data rejestracji jest wymagana.")]
        [Display(Name = "Data rejestracji")]
        public DateTime DataRejestracji { get; set; }

        public ICollection<Zamowienie> Zamowienia { get; set; } = new List<Zamowienie>();
        public ICollection<Koszyk> Koszyki { get; set; } = new List<Koszyk>();

        [NotMapped]
        public string ImieINazwisko
        {
            get => $"{Imie} {Nazwisko}";
        }
    }
}
