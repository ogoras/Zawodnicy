using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Zawodnicy.WebApp.Models;

namespace Zawodnicy.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Login()
        {
            return View();
        }

        //Logowanie POST
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {

            if (!ModelState.IsValid)    //blad logowania - nie bledne haslo jako niezgodne z walidacja
                return View(loginVM);

            //zwraca name usera do zalogowania
            var user = await _userManager.FindByNameAsync(loginVM.Username);

            if (user != null)
            {
                //logowanie
                var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);


                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Niepoprawna nazwa użytkownika lub hasło...");


            return View(loginVM);
        }

        public IActionResult Register()
        {
            return View(new LoginVM());
        }

        //Rejestracja POST
        //Nie wymagająca podania ConfirmPassword 
        [HttpPost]
        public async Task<IActionResult> Register(LoginVM loginVM)
        {
            if (ModelState.IsValid) //wprowadzone wartości logowania zgodne z walidacją; ModelState-model predefiniowany
            {
                var user = new IdentityUser() { UserName = loginVM.Username };
                var result = await _userManager.CreateAsync(user, loginVM.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home"); //(metoda, controller)
                }
            }

            return View(loginVM);
        }


        //Wylogowanie
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
