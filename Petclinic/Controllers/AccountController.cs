using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Petclinic.Models;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Petclinic.Entities;

namespace Petclinic.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityAppUser> _userManager;
        private readonly SignInManager<IdentityAppUser> _signInManager;

        public AccountController(ILogger<HomeController> logger, 
            UserManager<IdentityAppUser> userManager, SignInManager<IdentityAppUser> signInManager)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["returnUrl"] = returnUrl;   
            returnUrl ??= Url.Content("~/");

            if (!ModelState.IsValid) return View(model);

            var user = await _userManager.FindByNameAsync(model.Email);
            await _userManager.AddClaimAsync(user, new Claim("firstName", user.FirstName));

            var result = await _signInManager.PasswordSignInAsync(model.Email,
                model.Password, model.RememberMe, false);

            if (result.Succeeded) return LocalRedirect(returnUrl);

            TempData["Message"] = "Something went wrong! We could not sign you in :(";
            TempData["Type"] = "danger";
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            var model = new RegisterViewModel();
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var user = new IdentityAppUser
            {
                UserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                TempData["Message"] = "You have successfully registered. Now you can log in!";
                TempData["Type"] = "success";
                return RedirectToAction("Login", "Account");
            }
            AddErrors(result);
            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
}
