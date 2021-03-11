using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KL296NTermProject.Models;

namespace KL296NTermProject.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            LoginVM login = new LoginVM();

            return View(login);
        }


        //    private UserManager<AppUser> userManager;
        //    private SignInManager<AppUser> signInManager;

        //    public LoginRegister(UserManager<AppUser> u, SignInManager<AppUser> s)
        //    {
        //        userManager = u;
        //        signInManager = s;
        //    }

        //    public IActionResult Index()
        //    {
        //        return View();
        //    }

        //    [HttpGet]
        //    public IActionResult Index()
        //    {
        //        return View();
        //    }

        //    [HttpPost]
        //    public async Task<IActionResult> Register(RegistrationVM model)
        //    {

        //        if (ModelState.IsValid)
        //        {
        //            var user = new AppUser { UserName = model.UserName, Name = model.UserName };
        //            var result = await userManager.CreateAsync(user, model.Password);

        //            if (result.Succeeded)
        //            {
        //                await signInManager.SignInAsync(user, isPersistent: true);
        //                return RedirectToAction("Index", "Home");
        //            }
        //            else
        //            {
        //                foreach (var err in result.Errors)
        //                {
        //                    ModelState.AddModelError("", err.Description);
        //                }
        //            }
        //        }

        //        return View(model);
        //    }

        //    [HttpPost]
        //    public async Task<IActionResult> LogOut()
        //    {
        //        await signInManager.SignOutAsync();
        //        return RedirectToAction("Index", "Home");
        //    }


        //    [HttpGet]
        //    public IActionResult Register()
        //    {
        //        return View();
        //    }

        //    [HttpGet]
        //    public IActionResult Login(string returnURL = "")
        //    {
        //        var model = new LoginVM { ReturnURL = returnURL };
        //        return View(model);
        //    }

        //    [HttpPost]
        //    public async Task<IActionResult> Login(LoginVM model)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var result = await signInManager.PasswordSignInAsync(model.Username, model.Password, isPersistent: model.RememberMe, lockoutOnFailure: false);

        //            if (result.Succeeded)
        //            {
        //                if (!string.IsNullOrEmpty(model.ReturnURL) && Url.IsLocalUrl(model.ReturnURL))
        //                {
        //                    return Redirect(model.ReturnURL);
        //                }
        //                else
        //                {
        //                    return RedirectToAction("Index", "Home");
        //                }
        //            }
        //        }

        //        ModelState.AddModelError("", "Invalid UserName/Password");
        //        return View(model);
        //    }
    }
}

