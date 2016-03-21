using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using dannyallegrezzaBlog.Models.Account;
using Microsoft.AspNet.Identity;
using dannyallegrezzaBlog.Models.Identity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace dannyallegrezzaBlog.Controllers
{
    public class AccountController : Controller
    {
        // Properties 
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signinManager)
        {
            _userManager = userManager;
            _signInManager = signinManager;
        }

        // ------------------- Registration ----------------------- //
        // GET: /Account/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        // POST: /Account/Register
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registrationInfo)
        {
            // First, check to see if the user passed in valid info. If they did not, send them back to the View with their faulty info!
            if (!ModelState.IsValid)
            {
                return View(registrationInfo);
            }

            ApplicationUser newUser = new ApplicationUser
            {
                Email = registrationInfo.EmailAddress,
                UserName = registrationInfo.EmailAddress,
            };

            // Try to create the Member
            var result = await _userManager.CreateAsync(newUser, registrationInfo.Password);

            // If the registration failed, add an error message to the page and send user back to try again
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "There was an error creating your account. Please try again.");
                return View(registrationInfo);
            }

            return RedirectToAction("Login");
        }

        // ------------------- Login ----------------------- //

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel login, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View(login); // Send the user back with their bad info
            }

            // Attempt to validate the user
            var result = await _signInManager.PasswordSignInAsync(
                login.EmailAddress,     // username
                login.Password,         // password
                login.RememberMe,       // Saves Login info as a Cookie
                false);                 // Should the user be locked out if they fail auth attempts?

            if (!result.Succeeded)
            {
                return View(login);     // If they login attempt failed, send the user back to the Login page
            }

            if (string.IsNullOrWhiteSpace(returnUrl))
            {
                return RedirectToAction("Index", "Home");
            }

            return Redirect(returnUrl);
        }

        // ------------------- Logout ----------------------- //
        [HttpPost]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            // Sign the user out
            await _signInManager.SignOutAsync();

            // Check to see if there is a returnUrl to redirect the user to
            if (string.IsNullOrWhiteSpace(returnUrl))
            {
                return RedirectToAction("Index", "Home");
            }

            return Redirect(returnUrl);
        }

    }
}
