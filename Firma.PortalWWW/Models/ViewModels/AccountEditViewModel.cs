using System.ComponentModel.DataAnnotations;

namespace Firma.PortalWWW.Models.ViewModels
{
    public class AccountEditViewModel
    {
        [Required(ErrorMessage = "Adres e-mail jest wymagany.")]
        [EmailAddress(ErrorMessage = "Nieprawidłowy format adresu e-mail.")]
        [Display(Name = "Adres e-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Imię jest wymagane.")]
        [MaxLength(50)]
        [Display(Name = "Imię")]
        public string Imie { get; set; }

        [Required(ErrorMessage = "Nazwisko jest wymagane.")]
        [MaxLength(50)]
        [Display(Name = "Nazwisko")]
        public string Nazwisko { get; set; }

        [Required(ErrorMessage = "Adres jest wymagany.")]
        [MaxLength(100)]
        [Display(Name = "Adres")]
        public string Adres { get; set; }

        [Required(ErrorMessage = "Numer telefonu jest wymagany.")]
        [Phone(ErrorMessage = "Nieprawidłowy format numeru telefonu.")]
        [Display(Name = "Telefon")]
        public string Telefon { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Aktualne hasło")]
        public string? CurrentPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Nowe hasło")]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Nowe hasło i potwierdzenie muszą się zgadzać.")]
        [Display(Name = "Potwierdź nowe hasło")]
        public string? ConfirmPassword { get; set; }
    }

}
