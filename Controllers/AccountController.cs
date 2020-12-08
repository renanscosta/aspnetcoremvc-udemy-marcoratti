using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LanchesMac.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace LanchesMac.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly UserManager<IdentityUser> _userManger;
        private readonly SignInManager<IdentityUser> _signInManager;


        public AccountController(ILogger<AccountController> logger, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _logger = logger;
            _userManger = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login(string redirectUrl)
        {
            return View(new LoginViewModel()
            {
                UrlRedirect = redirectUrl
            });
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (!ModelState.IsValid)
                return View(loginVM);

            var user = await _userManger.FindByNameAsync(loginVM.UserName);

            if (user != null)
            {
                var resultLogin = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);

                if (resultLogin.Succeeded)
                {
                    if (String.IsNullOrWhiteSpace(loginVM.UrlRedirect))
                        return RedirectToAction("Index", "Home");

                    return RedirectToAction(loginVM.UrlRedirect);
                }
            }

            ModelState.AddModelError("", "Usuário/Senha inválidos ou não localizados");
            return View(loginVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(LoginViewModel loginVM)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser(loginVM.UserName);
                var result = await _userManger.CreateAsync(user, loginVM.Password);

                if (result.Succeeded)
                    return RedirectToAction("Index", "Home");
            }

            return View(loginVM);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
