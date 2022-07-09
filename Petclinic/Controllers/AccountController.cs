﻿using Microsoft.AspNetCore.Mvc;
using Petclinic.Models;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using Petclinic.Entities;

namespace Petclinic.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityAppUser> _userManager;
        private readonly SignInManager<IdentityAppUser> _signInManager;
        private readonly IOptions<IdentityOptions> _identityOptions;
        private readonly IEmailSender _emailSender;

        public AccountController(
            UserManager<IdentityAppUser> userManager,
            SignInManager<IdentityAppUser> signInManager,
            IOptions<IdentityOptions> identityOptions,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _identityOptions = identityOptions;
            _emailSender = emailSender;
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

            if (!ModelState.IsValid) return View();

            var user = await _userManager.FindByNameAsync(model.Email);
            if (user != null)
            {
                await _userManager.AddClaimAsync(user, new Claim("firstName", user.FirstName));
            }

            var result = await _signInManager.PasswordSignInAsync(model.Email,
                model.Password, model.RememberMe, true);

            if (result.Succeeded) return LocalRedirect(returnUrl);
            if (result.IsLockedOut)
            {
                ReturnTempMessage("warning", $"Too many failed attempts to login. " +
                                             $"Try to login again in " +
                                             $"{_identityOptions.Value.Lockout.DefaultLockoutTimeSpan.Minutes} minutes.");
                return View();
            }

            ReturnTempMessage("danger", "Something went wrong! We could not sign you in :(");
            return View();
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
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var callbackUrl = Url.Action(
                    "ConfirmEmail",
                    "Account",
                    new { userId = user.Id, code = code },
                    protocol: HttpContext.Request.Scheme
                );
                await _emailSender.SendEmailAsync(model.Email, "Confirm Your Password - Petclinic",
                    $"Please confirm your password by clicking: <a href=\"{callbackUrl}\">here</a>");
                ReturnTempMessage("success", "You have successfully registered. Now you can log in!");
                return RedirectToAction("Login", "Account");
            }

            AddErrors(result);
            return View(model);
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return View("Error");
            }
            var result = await _userManager.ConfirmEmailAsync(user, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user =await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var callbackUrl = Url.Action(
                        "RecoverPassword",
                        "Account",
                        new { userId = user.Id, code = code },
                        protocol: HttpContext.Request.Scheme
                    );
                    await _emailSender.SendEmailAsync(model.Email, "Reset Password - Petclinic",
                        $"Please reset your password by clicking: <a href=\"{callbackUrl}\">here</a>");
                }
            }
            ReturnTempMessage("warning", "PLEASE CHECK YOUR EMAIL TO RESET YOUR PASSWORD AND LOGIN");
            return RedirectToAction("Login", "Account");
        }

        public IActionResult RecoverPassword(string code = null, string userId = null)
        {
            return (code == null || userId == null) ? View("Error") : View(new RecoverPasswordViewModel
            {
                Code = code,
                Id = userId
            });
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RecoverPassword(RecoverPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.Id);

                if (user == null)
                {
                    ReturnTempMessage("danger", "Something went wrong :( We could not reset your password.");
                    return RedirectToAction("Login", "Account");
                }

                var result = 
                    await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
                if (!result.Succeeded)
                {
                    AddErrors(result);
                    ReturnTempMessage("danger", "Something went wrong :( We could not reset your password.");
                }
                else
                {
                    ReturnTempMessage("success", "Your password has been changed. You can login now.");
                }

                return RedirectToAction("Login", "Account");
            }

            ReturnTempMessage("danger", "Something went wrong :( We could not reset your password.");
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ExternalLogin(string provider, string returnUrl = null)
        {
            var redirectUrl = Url.Action("ExternalLoginCallback", "Account",
                new { ReturnUrl = returnUrl });
            var properties = _signInManager
                .ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return Challenge(properties, provider);
        }

        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null,
            string remoteError = null)
        {

            ViewData["returnUrl"] = returnUrl;
            returnUrl ??= Url.Content("~/");

            if (remoteError != null)
            {
                ModelState.AddModelError(string.Empty, $"Error from external provider: {remoteError}");
                ReturnTempMessage("danger", "Sorry we could not log you in with external provide. PLease try later");
                return View(nameof(Login));
            }

            var info = await _signInManager.GetExternalLoginInfoAsync();

            if (info != null)
            {
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                var user = await _userManager.FindByNameAsync(email);

                if (user == null)
                {
                    var newUser = new IdentityAppUser
                    {
                        Email = email,
                        UserName = email,
                        FirstName = info.Principal.FindFirstValue(ClaimTypes.GivenName),
                        LastName = info.Principal.FindFirstValue(ClaimTypes.Surname)
                    };
                    var result = await _userManager.CreateAsync(newUser);
                    if (!result.Succeeded)
                    {
                        ReturnTempMessage("danger", "Something went wrong! We could not sign you in :(");
                        return View("Login");
                    }

                    user = newUser;
                }

                await _userManager.AddClaimAsync(user, new Claim("firstName", user.FirstName));
                await _signInManager.SignInAsync(user, true);
                return LocalRedirect(returnUrl);
                
            }

            ReturnTempMessage("danger", "Something went wrong! We could not sign you in :(");
            return View("Login");


            //var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider,
            //    info.ProviderKey, isPersistent: false);
            //if (result.Succeeded)
            //{
            //    await _signInManager.UpdateExternalAuthenticationTokensAsync(info);
            //    return LocalRedirect(returnUrl);
            //}
            //else
            //{
            //    ViewData["ReturnUrl"] = returnUrl;
            //    ViewData["ProviderName"] = info.ProviderDisplayName;
            //    //var email = info.Principal.FindFirstValue(ClaimTypes.Email);
            //    return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel
            //    {
            //        Email = email,
            //    });
            //}
        }

        public async Task<IActionResult> EnableAuthenticator()
        {
            var user = await _userManager.GetUserAsync(User);
            await _userManager.ResetAuthenticatorKeyAsync(user);
            var token = await _userManager.GetAuthenticatorKeyAsync(user);
            var model = new TwoFactorAuthenticationViewModel()
            {
                Token = token,
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EnableAuthenticator(TwoFactorAuthenticationViewModel model)
        {
            if (!ModelState.IsValid) return RedirectToAction("AuthenticatorConfirmation");

            var user = await _userManager.GetUserAsync(User);
            var succeeded = await _userManager
                .VerifyTwoFactorTokenAsync(user, _userManager.Options.Tokens.AuthenticatorTokenProvider,
                    model.Code);
            if (succeeded)
            {
                await _userManager.SetTwoFactorEnabledAsync(user, true);
            }
            else
            {
                ModelState.AddModelError("Verify", "Your two factor auth code could not be validated");
                return View(model);
            }

            return RedirectToAction("AuthenticatorConfirmation");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = 
            true)]
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

        private void ReturnTempMessage(string type, string message)
        {
            TempData["Message"] = message;
            TempData["Type"] = type;
        }
    }
}