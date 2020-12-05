using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LanchesMac.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace LanchesMac.Controllers
{
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

    }
}
