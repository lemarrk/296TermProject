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


                Topic topic1 = new Topic();
                //topic1.Post = new Post();
                topic1.TopicName = "Cpp";
                context.Topics.Add(topic1);
                context.SaveChanges();


                Topic topic2 = new Topic();
                //topic2.Post = new Post();
                topic2.TopicName = "CSharp";
                context.Topics.Add(topic2);
                context.SaveChanges();


                Topic topic3 = new Topic();
                topic3.TopicName = "JS";
               // topic3.Post = new Post();
                context.Topics.Add(topic3);
                context.SaveChanges();


                Link link = new Link();
                link.URL = "www.cplusplus.com";
                link.UrlName = "site";
                link.Sender = "me";
                link.DateSent = DateTime.Now;
                link.Subject = "A good informative site";
                link.TopicID = context.Topics.Where(o => o.TopicName == "Cpp").FirstOrDefault().TopicID;

                context.Links.Add(link);
                context.SaveChanges();

                Post post = new Post();
                post.DateSent = DateTime.Now;
                post.Sender = "Website Creator";
                post.Subject = "Making yourself an admin";
                post.Body = "Login as 'SiteAdmin' to make yourself the admin (The password is 'Abc123!')";
                post.Name = siteadmin.UserName;
                post.TopicID = context.Topics.Where(o => o.TopicName == "Cpp").FirstOrDefault().TopicID;
                //post.Message = new List<Message>();
              
                context.Posts.Add(post);
                context.SaveChanges();

                Link link2 = new Link();
                link2.URL = "www.w3schools.com/js/DEFAULT.asp";
                link2.UrlName = "site";
                link2.Sender = "me";
                link2.DateSent = DateTime.Now;
                link2.Subject = "A good informative site";
                link2.TopicID = context.Topics.Where(o => o.TopicName == "JS").FirstOrDefault().TopicID;

                context.Links.Add(link2);
                context.SaveChanges();

                Post post2 = new Post();
                post2.DateSent = DateTime.Now;
                post2.Sender = "Website Creator";
                post2.Subject = "Making ";
                post2.Body = "Login";
                post2.Name = siteadmin.UserName;
                post2.TopicID = context.Topics.Where(o => o.TopicName == "JS").FirstOrDefault().TopicID;
                //post2.Message = new List<Message>();

                context.Posts.Add(post2);
                context.SaveChanges();

                Link link3 = new Link();
                link3.URL = "www.w3schools.com/cs/default.asp";
                link3.UrlName = "site";
                link3.Sender = "me";
                link3.DateSent = DateTime.Now;
                link3.Subject = "A good informative site";
                link3.TopicID = context.Topics.Where(o => o.TopicName == "CSharp").FirstOrDefault().TopicID;

                context.Links.Add(link3);
                context.SaveChanges();

                Post post3 = new Post();
                post3.DateSent = DateTime.Now;
                post3.Sender = "Website Creator";
                post3.Subject = "Making ";
                post3.Body = "Login";
                post3.Name = siteadmin.UserName;
                post3.TopicID = context.Topics.Where(o => o.TopicName == "CSharp").FirstOrDefault().TopicID;
               // post3.Message = new List<Message>();

                context.Posts.Add(post3);
                context.SaveChanges();

            }
        }
    }
}
