using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace RepostIt.Controllers
{
    public class LoginRegisterController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IToastNotification _toastNotification;
        public LoginRegisterController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IToastNotification toastNotification)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _toastNotification = toastNotification;
        }



        public IActionResult Login()
        {


            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user != null)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(user, password, false, false);

                if (signInResult.Succeeded)
                {
                    _toastNotification.AddSuccessToastMessage("Welcome Back!" + " " + @User.Identity.Name);
                    return RedirectToAction("Index", "Home");
                }
            }

            return RedirectToAction("Login");
        }
        [HttpPost]
        public async Task<IActionResult> Register(string password, string email, string username)
        {
            var user = new IdentityUser
            {

                UserName = username,
                Email = email
             

            };

            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(user, password, false, false);

                if (signInResult.Succeeded)
                {
                    _toastNotification.AddSuccessToastMessage("registered successfully!");
                    return RedirectToAction("Index", "Home");
                }
            }

            return RedirectToAction("Register");
        }
        public IActionResult Register()
        {
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            _toastNotification.AddSuccessToastMessage("logout Sucessfully!");
            return RedirectToAction("Login");
        }
    }
}