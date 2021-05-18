using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsTK.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using NewsTK.Identity;
using Microsoft.AspNetCore.Identity;

namespace NewsTK.Controllers
{
    public class UserController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;

        public UserController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user == null)
                {
                    TempData["UserNotFound"] = "This user does not exist!";
                    return View(model);
                }

                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password,false,false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                TempData["PasswordIncorrect"] = "You entered an incorrect password!";
                return View();
            }
        }

        [HttpGet]
        public IActionResult userRegister()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<ActionResult> userRegister(RegisterModel model)
        {
            
            var user = new User()
            {
                UserName = model.UserName,
                Email = model.Email,
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            System.Diagnostics.Debug.WriteLine("resultt: " + result);
            await _userManager.AddToRoleAsync(user, model.RoleName);
            if (result.Succeeded)
            {
                return RedirectToAction("Login","User");
            }
            
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
