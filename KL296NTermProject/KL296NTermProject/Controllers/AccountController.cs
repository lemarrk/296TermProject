using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KL296NTermProject.Models;
using Microsoft.AspNetCore.Identity;

namespace KL296NTermProject.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager;
        bool loggedIn = false;

        public AccountController(UserManager<AppUser> u, SignInManager<AppUser> s)
        {
            userManager = u;
            signInManager = s;
        }


        public IActionResult Index(string returnURL = "")
        {
            LoginVM login = new LoginVM();
            login.ReturnURL = returnURL;

            RulesVM rules = new RulesVM();
            rules.rules = new List<string>();
            rules.rules.Add("Treat Others With Respect");
            rules.rules.Add("No Politics");
            rules.rules.Add("All the rules from Lcc apply");

            login.RuleVM = rules;

            if(loggedIn) {
                login.alreadyLoggedIn = true;
            }

            return View(login);
        }

        // register begin

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {

            if (ModelState.IsValid)
            {
                var user = new AppUser { UserName = model.UserName, Name = model.UserName};
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: true);
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    foreach (var err in result.Errors)
                    {
                        ModelState.AddModelError("", err.Description);
                    }
                }
            }

            return View(model);
        }

        // register end

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Name, model.Password, isPersistent: model.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                { 
                    if (!string.IsNullOrEmpty(model.ReturnURL) && Url.IsLocalUrl(model.ReturnURL))
                    {
                        return Redirect(model.ReturnURL);
                    }
                    else
                    {

                        loggedIn = true;
                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            ModelState.AddModelError("", "Invalid UserName/Password");
            return View(model);
        }
    }
}

