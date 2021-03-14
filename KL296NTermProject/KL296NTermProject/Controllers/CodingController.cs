using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KL296NTermProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace KL296NTermProject.Controllers
{
    public class CodingController : Controller
    {
        private DataDbContext context;

        public CodingController(DataDbContext _context)
        {
            context = _context;
        }

        [Authorize]
        [HttpPost]
        public IActionResult Input(Post p, string id)
        {
            //p.TopicID = Convert.ToInt32(id);

            switch(id)
            {
                case "1":
                    context.Posts.Add(p);
                    context.SaveChanges();
                    var posts = context.Posts.ToList();
                    return View("~/Views/Coding/Cpp/Post.cshtml", posts);

                case "2":
                    context.Posts.Add(p);
                    context.SaveChanges();
                    var posts1 = context.Posts.ToList();
                    return View("~/Views/Coding/CSharp/Post.cshtml", posts1);

                case "3":
                    context.Posts.Add(p);
                    context.SaveChanges();
                    var posts2 = context.Posts.ToList();
                    return View("~/Views/Coding/JS/Post.cshtml", posts2);

                default:
                    break;
            }

            return View(new Post());
        }

        // 

        [HttpGet] 
        public IActionResult CppMessage()
        {
            //var posts = context.Topics.Include("Posts").Where(o => o.TopicName == "Cpp").Select(o => o).ToList();
            var message = context.Posts.Where(o => o.Topic.TopicName == "Cpp").ToList();
           
            return View("~/Views/Coding/CPP/Message.cshtml", message);
        }

        //[Authorize]
        //[HttpPost]
        //public IActionResult CppMessage(List<Post> posts)
        //{
        //    return View("~/Views/Coding/CPP/Message.cshtml", posts);
        //}


        [Authorize]
        public IActionResult CppInput()
        {
            var topic = new Post();
            return View("~/Views/Coding/CPP/Topic.cshtml", topic);
        }

        [Authorize]
        [HttpPost]
        public IActionResult CppTopic(Post p)
        {
            p.DateSent = DateTime.Now;
            context.Posts.Add(p);
            context.SaveChanges();
   
            return RedirectToAction("CppMessage");
        }

        [HttpGet]
        public IActionResult CppPost()
        {
            var posts = context.Posts.Where(o => o.Topic.TopicName == "Cpp").Select(o => o).ToList();
            return View("~/Views/Coding/CPP/Post.cshtml", posts);
        }

        //[Authorize]
        //[HttpPost]
        //public IActionResult CppInput(Link l)
        //{
        //    context.Links.Add(l);
        //    context.SaveChanges();

        //    return RedirectToAction("CppLink");
        //}

        [Authorize]
        public IActionResult CppLink()
        {
            var links = context.Links.ToList();
            return View("~/Views/Coding/CPP/Link.cshtml", links);
        }

        // csharp section

        [HttpGet]
        public IActionResult CSharpMessage()
        {
            var posts = context.Topics.Include("Posts").Where(o => o.TopicName == "CSharp").ToList();
            return View("~/Views/Coding/CSharp/Message.cshtml", posts);
        }

        //[Authorize]
        //[HttpPost]
        //public IActionResult CSharpMessage(List<Post> posts)
        //{
        //    return View("~/Views/Coding/CSharp/Message.cshtml", posts);
        //}

        [Authorize]
        public IActionResult CSharpTopic()
        {
            return View("~/Views/Coding/CSharp/Topic.cshtml");
        }

        [Authorize]
        [HttpPost]
        public IActionResult CSharpTopic(Post p)
        {
            p.DateSent = DateTime.Now;
            context.Posts.Add(p);
            context.SaveChanges();

            return RedirectToAction("CSharpMessage");
        }

        //[Authorize]
        //public IActionResult CSharpInput()
        //{
        //    return View("~/Views/Coding/CSharp/Input.cshtml", new Link());
        //}

        //[Authorize]
        //[HttpPost]
        //public IActionResult CSharpInput(Link l)
        //{
        //    context.Links.Add(l);
        //    context.SaveChanges();

        //    return RedirectToAction("CSharpLink");
        //}


        [Authorize]
        public IActionResult CSharpLink()
        {
            var links = context.Links.ToList();
            return View("~/Views/Coding/CSharp/Link.cshtml",links);
        }


        // begin js section
        [HttpGet]
        public IActionResult JSMessage()
        {
            var posts = context.Topics.Include("Posts").Where(o => o.TopicName == "JS").ToList();
            return View("~/Views/Coding/JS/Message.cshtml", posts);
        }

        [Authorize]
        public IActionResult JSTopic()
        {
            return View("~/Views/Coding/JS/Topic.cshtml");
        }

        [Authorize]
        [HttpPost]
        public IActionResult JSTopic(Post p)
        {
            p.DateSent = DateTime.Now;
            context.Posts.Add(p);
            context.SaveChanges();

            return RedirectToAction("JSMessage");
        }

        //[Authorize]
        //public IActionResult JSInput()
        //{
        //    return View("~/Views/Coding/JS/Input.cshtml", new Link());
        //}

        //[Authorize]
        //[HttpPost]
        //public IActionResult JSInput(Link l)
        //{
        //    context.Links.Add(l);
        //    context.SaveChanges();

        //    return RedirectToAction("JSLink");
        //}

        [Authorize]
        public IActionResult JSLink()
        {
            var links = context.Links.ToList();
            return View("~/Views/Coding/JS/Link.cshtml", links);
        }

        // begin data manipulation


        [Authorize]
        [HttpPost]
        public IActionResult GetCppMessages(int id)
        {
            var messages = context.Messages.Include("Posts").Where(p => p.PostID == id).ToList();
            return RedirectToAction("CppMessage", "Coding", messages);
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddCppLink(Link l)
        {
            context.Links.Add(l);
            context.SaveChanges();

            return RedirectToAction("CppLink", "Coding");
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddCppPost(Post p)
        {
            context.Posts.Add(p);
            context.SaveChanges();

            return RedirectToAction("CppTopic", "Coding");
        }

        [Authorize]
        [HttpPost]
        public IActionResult DeleteCppLink(int id)
        {
            var link = context.Links.Find(id);

            if (link != null)
            {
                // var post = posts.Where(p => p.MessageID == id).FirstOrDefault()
                context.Links.Remove(link);
                context.SaveChanges();
                return RedirectToAction("CppLink", "Coding");
            }

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpPost]
        public IActionResult DeleteCppMessage(int id)
        {
            var post = context.Posts.Find(id);

            if (post != null)
            {
               // var post = posts.Where(p => p.MessageID == id).FirstOrDefault()
                context.Posts.Remove(post);
                context.SaveChanges();
                return RedirectToAction("CppMessage", "Coding");
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
