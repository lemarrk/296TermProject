using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using KL296NTermProject.Models;

namespace KL296NTermProject.Models
{
    public class Seed 
    {
        public static void starter(DataDbContext context, UserManager<AppUser> usrManager, RoleManager<IdentityRole> roleManager)
        {

            if (!context.Topics.Any())
            {
                // create member role and admin
                var adminRole = roleManager.CreateAsync(new IdentityRole("Member")).Result;
                adminRole = roleManager.CreateAsync(new IdentityRole("Admin")).Result;
                // add user called "SiteAdmin" to the user manager
                var siteadmin = new AppUser() { UserName = "SiteAdmin", Role = "Site Admin" };
                //
                usrManager.CreateAsync(siteadmin, "Abc123!").Wait();
                //
                IdentityRole admin = roleManager.FindByNameAsync("Admin").Result;
                // 
                usrManager.AddToRoleAsync(siteadmin, admin.Name);

                Rules rules = new Rules();
                rules.Rule.Add("Treat Others With Respect");
                rules.Rule.Add("No Politics");
                rules.Rule.Add("All the rules from Lcc apply");
                rules.Rule.Add("Be Yourself");


                context.Rules.Add(rules);
                context.SaveChanges();

                //Message message = new Message();
                //message.DateSent = DateTime.Now;
                //message.Sender = "Website Creator";
                //message.Subject = "Making yourself an admin";
                //message.Body = "Login as 'SiteAdmin' to make yourself the admin (The password is 'Abc123!')";
                //message.Name = siteadmin.UserName;
                //message.Reply = new List<Reply>();

                //Reply reply = new Reply
                //{
                //    Name = "Kendall",
                //    DateSent = DateTime.Now,
                //    Body = "Make yourself at home",
                //    Subject = "Logging in",
                //    Sender = "Site User"
                //};

                //message.Reply.Add(reply);

                //context.Message.Add(message);
                //context.SaveChanges();
            }
        }
    }
}
