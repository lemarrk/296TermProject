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

                context.Rules.Add(rules);
                context.SaveChanges();

                Topic topic = new Topic();
                topic.Post = new Post();
                topic.Video = new Video();
                topic.Link = new Link();

                topic.Post.DateSent = DateTime.Now;
                topic.Post.Sender = "Website Creator";
                topic.Post.Subject = "Making yourself an admin";
                topic.Post.Body = "Login as 'SiteAdmin' to make yourself the admin (The password is 'Abc123!')";
                topic.Post.Name = siteadmin.UserName;
                topic.Post.Messages = new List<Message>();

                context.Topics.Add(topic);
                context.SaveChanges();
            }
        }
    }
}
