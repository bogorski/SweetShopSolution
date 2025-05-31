using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Firma.Data.Data;
using Firma.Data.Data.Sklep;
using Firma.PortalWWW.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

public class AccountController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly FirmaContext _context;

    public AccountController(UserManager<IdentityUser> userManager,
                             SignInManager<IdentityUser> signInManager,
                             FirmaContext firmaContext)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _context = firmaContext;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(string email, string password, bool rememberMe)
    {
        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            ModelState.AddModelError(string.Empty, "Email i hasło są wymagane");
            return View();
        }

        var result = await _signInManager.PasswordSignInAsync(email, password, rememberMe, false);

        if (result.Succeeded)
            return RedirectToAction("Index", "Home");

        ModelState.AddModelError(string.Empty, "Niepoprawny login lub hasło");
        return View();
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View(new RegisterViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid || model.Password != model.ConfirmPassword)
        {
            if (model.Password != model.ConfirmPassword)
                ModelState.AddModelError(string.Empty, "Hasła muszą się zgadzać");

            return View(model);
        }

        if (model.Password.Length < 8)
        {
            ModelState.AddModelError(string.Empty, "Hasło musi mieć co najmniej 8 znaków");
            return View();
        }

        var user = new IdentityUser { UserName = model.Email, Email = model.Email };
        var result = await _userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            var klient = new Klient
            {
                IdentityUserId = user.Id,
                Imie = model.Imie,
                Nazwisko = model.Nazwisko,
                Adres = model.Adres,
                Telefon = model.Telefon,
                Email = model.Email,
                DataRejestracji = DateTime.Now
            };

            _context.Klient.Add(klient);
            await _context.SaveChangesAsync();
            await _signInManager.SignInAsync(user, false);
            return RedirectToAction("Index", "Home");
        }

        foreach (var error in result.Errors)
            ModelState.AddModelError(string.Empty, error.Description);

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login", "Account");
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> Edit()
    {
        var user = await _userManager.GetUserAsync(User);
        var klient = await _context.Klient.FirstOrDefaultAsync(k => k.IdentityUserId == user.Id);

        if (klient == null) return NotFound();

        var model = new AccountEditViewModel
        {
            Email = klient.Email,
            Imie = klient.Imie,
            Nazwisko = klient.Nazwisko,
            Adres = klient.Adres,
            Telefon = klient.Telefon
        };

        return View(model);
    }

    [Authorize]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(AccountEditViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var user = await _userManager.GetUserAsync(User);

        if (user == null)
            return NotFound();

        var klient = await _context.Klient.FirstOrDefaultAsync(k => k.IdentityUserId == user.Id);

        if (klient == null) 
            return NotFound();

        klient.Imie = model.Imie;
        klient.Nazwisko = model.Nazwisko;
        klient.Adres = model.Adres;
        klient.Telefon = model.Telefon;
        klient.Email = model.Email;
        user.Email = model.Email;
        user.UserName = model.Email;


        if (!string.IsNullOrEmpty(model.Password) || !string.IsNullOrEmpty(model.ConfirmPassword))
        {
            if (string.IsNullOrEmpty(model.CurrentPassword))
            {
                ModelState.AddModelError(nameof(model.CurrentPassword), "Podanie aktualnego hasła jest wymagane, aby zmienić hasło.");
                return View(model);
            }

            var changePasswordResult = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.Password);

            if (!changePasswordResult.Succeeded)
            {
                foreach (var error in changePasswordResult.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);

                return View(model);
            }
        }
        else if (!string.IsNullOrEmpty(model.CurrentPassword))
        {
            ModelState.AddModelError(nameof(model.Password), "Podaj nowe hasło.");
            return View(model);
        }

        _context.Update(klient);
        await _userManager.UpdateAsync(user);
        await _context.SaveChangesAsync();

        TempData["SuccessMessage"] = "Dane zostały poprawnie zmienione.";

        return RedirectToAction("Index", "Home");
    }
}
