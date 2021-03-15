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
        private RoleManager<IdentityRole> roleManager;

        public AccountController(UserManager<AppUser> u, SignInManager<AppUser> s, RoleManager<IdentityRole> _roleManager)
        {
            userManager = u;
            signInManager = s;
            roleManager = _roleManager;
        }

        [HttpGet]
        public IActionResult Login(string returnURL = "")
        {
            LoginVM login = new LoginVM();
            login.ReturnURL = returnURL;
            login.RuleVM = new RulesVM();
            RulesVM rules = new RulesVM();
            login.RuleVM.rules = new List<string>();
            login.RuleVM.rules.Add("Treat Others With Respect");
            login.RuleVM.rules.Add("No Politics");
            login.RuleVM.rules.Add("All the rules from Lcc apply");

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
            var user = new AppUser { UserName = model.UserName, Name = model.UserName, Role = model.Role};
            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: true);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
            }

            return View(model);
        }

        // register end

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
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

                    return RedirectToAction("Index", "Home");
                }

            }

            ModelState.AddModelError("", "Invalid UserName/Password");
            return View(model);
        }
    }
}

