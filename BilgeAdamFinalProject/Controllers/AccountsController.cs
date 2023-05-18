using ApplicationCore.Entities.Concrete;
using ApplicationCore.Entities.DTO_s.AccountDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace BilgeAdamFinalProject.Controllers
{
    public class AccountsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;

        public AccountsController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IPasswordHasher<ApplicationUser> passwordHasher)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _passwordHasher = passwordHasher;
        }


        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken, AllowAnonymous]
        public async Task<IActionResult> Register(RegisterDTO model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                };
                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    TempData["Success"] = "Kayıt başarılı giriş yapabilirsiniz";
                    return RedirectToAction("LogIn");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        TempData["Error"] = "Kayıt yapılamadı";
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            TempData["Error"] = "Kayıt yapılamadı";
            return View(model);
        }


        [AllowAnonymous]
        public IActionResult LogIn() => View();

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInDTO model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await _userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    SignInResult result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, false, false);
                    if (result.Succeeded)
                    {
                        TempData["Success"] = "Hoş geldiniz" + user.UserName;
                        return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError("", "Yanlış Giriş");
                }
                TempData["Error"] = "Kullanıcı adı veya şifre yanlış";
            }
            return View(model);
        }

        public async Task<IActionResult> EditUser(int id)
        {
            ApplicationUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user != null)
            {
                var model = new UserUpdateDTO(user);
                return View(model); 
            }
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(UserUpdateDTO model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.UserName = model.UserName;
                if (model.Password != null)
                {
                    user.PasswordHash = _passwordHasher.HashPassword(user, model.Password);
                }
                user.Email = model.Email;
                IdentityResult result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    TempData["Success"] = "Profil bilgileriniz güncellendi";
                }
                else
                {
                    TempData["Error"] = "Profiliniz güncellendi"; 
                }
            }
            return View(model);
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            TempData["Success"] = "Çıkış yapıldı";
            return RedirectToAction("LogIn");
        }

    }
}
