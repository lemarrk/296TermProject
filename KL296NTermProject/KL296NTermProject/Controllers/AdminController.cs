
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

using KL296NTermProject.Models;

namespace KL296NTermProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private UserManager<AppUser> usrManager;
        private RoleManager<IdentityRole> roleManager;

        public AdminController(UserManager<AppUser> u, RoleManager<IdentityRole> r)
        {
            usrManager = u;
            roleManager = r;
        }

        public async Task<IActionResult> Index()
        {
            // make empty lit for users to populate view
            List<AppUser> users = new List<AppUser>();

            foreach (AppUser user in usrManager.Users)
            {
                // find all roles
                user.RoleNames = await usrManager.GetRolesAsync(user);

                // add to list
                users.Add(user);
            }

            // make new User View Model with data from above
            AdminVM model = new AdminVM
            {
                Users = users,
                Roles = roleManager.Roles
            };

            // send to view
            return View(model);
        }

        // delete user here
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            AppUser usr = await usrManager.FindByIdAsync(id);

            if (usr != null)
            {
                var result = await usrManager.DeleteAsync(usr);

                if (!result.Succeeded)
                {
                    string errors = "";
                    foreach (var err in result.Errors)
                    {
                        errors += err;
                    }

                    TempData["message"] = errors;
                }
                else
                {
                    // clear errors
                    TempData["message"] = "";
                }
            }
            return RedirectToAction("Index");
        }

        // add to admin
        [HttpPost]
        public async Task<IActionResult> AddToAdmin(string id)
        {

            IdentityRole adminRole = await roleManager.FindByNameAsync("Admin");

            if (adminRole == null)
            {
                TempData["message"] = "Admin role does not exist." + " Click 'Create Admin Role' button to create it.";
            }
            else
            {
                AppUser usr = await usrManager.FindByIdAsync(id);
                await usrManager.AddToRoleAsync(usr, adminRole.Name);
            }

            return RedirectToAction("Index");
        }

        // remove from admin
        [HttpPost]
        public async Task<IActionResult> RemoveFromAdmin(string id)
        {
            var usr = await usrManager.FindByIdAsync(id);
            await usrManager.RemoveFromRoleAsync(usr, "Admin");
            return RedirectToAction("Index");
        }

        // delete admin role here

        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            await roleManager.DeleteAsync(role);
            return RedirectToAction("Index");
        }


        // create admin role here
        [HttpPost]
        public async Task<IActionResult> CreateAdminRole()
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser { UserName = model.UserName };
                var result = await usrManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
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
    }
}
