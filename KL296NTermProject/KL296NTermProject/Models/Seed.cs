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
                var siteadmin = new AppUser { UserName = "SiteAdmin", Name = "Site Admin", Role = "Admin" };
                //
                usrManager.CreateAsync(siteadmin, "Abc123!").Wait();
                //
                var admin = roleManager.FindByNameAsync("Admin").Result;
                // 
                usrManager.AddToRoleAsync(siteadmin, admin.Name);

                Link link = new Link();
                link.URL = "www.cplusplus.com";
                link.UrlName = "site";
                link.Sender = "me";
                link.DateSent = DateTime.Now;
                link.Subject = "A good informative site";
                context.Links.Add(link);
                context.SaveChanges();

                Post post = new Post();
                post.DateSent = DateTime.Now;
                post.Sender = "Website Creator";
                post.Subject = "Making yourself an admin";
                post.Body = "Login as 'SiteAdmin' to make yourself the admin (The password is 'Abc123!')";
                post.Name = siteadmin.UserName;
                //post.Message = new List<Message>();
                // post.Message.Add(m);

                context.Posts.Add(post);
                context.SaveChanges();

                Topic topic1 = new Topic();
                topic1.TopicName = "Cpp";
                context.Topics.Add(topic1);
                context.SaveChanges();

                Topic topic2 = new Topic();
                topic2.Post = new List<Post>();
                topic2.TopicName = "CSharp";

                context.Topics.Add(topic2);
                context.SaveChanges();

                Topic topic3 = new Topic();
                topic3.TopicName = "JS";
                topic3.Post = new List<Post>();
                topic3.Post.Add(post);

                context.Topics.Add(topic3);
                context.SaveChanges();

            }
        }
    }
}
