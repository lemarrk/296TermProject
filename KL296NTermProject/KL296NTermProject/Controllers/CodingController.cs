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

        [HttpGet]
        public IActionResult CppMessage()
        {
            var posts = context.Posts.Where(o => o.Topic.TopicName ==  "Cpp").ToList();
            return View("~/Views/Coding/CPP/Message.cshtml", posts);
        }

        //[Authorize]
        //[HttpPost]
        //public IActionResult CppMessage(List<Post> posts)
        //{
        //    return View("~/Views/Coding/CPP/Message.cshtml", posts);
        //}

        [Authorize]
        public IActionResult CppTopic()
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

        [Authorize]
        public IActionResult CppInput()
        {
            return View("~/Views/Coding/CPP/Input.cshtml", new Link());
        }

        [Authorize]
        [HttpPost]
        public IActionResult CppInput(Link l)
        {
            context.Links.Add(l);
            context.SaveChanges();

            return RedirectToAction("CppLink");
        }

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
            var posts = context.Posts.Where(o => o.Topic.TopicName == "CSharp").ToList();
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

        [Authorize]
        public IActionResult CSharpInput()
        {
            return View("~/Views/Coding/CSharp/Input.cshtml", new Link());
        }

        [Authorize]
        [HttpPost]
        public IActionResult CSharpInput(Link l)
        {
            context.Links.Add(l);
            context.SaveChanges();

            return RedirectToAction("CSharpLink");
        }


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
            var posts = context.Posts.Where(o => o.Topic.TopicName == "JS").ToList();
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

        [Authorize]
        public IActionResult JSInput()
        {
            return View("~/Views/Coding/JS/Input.cshtml", new Link());
        }

        [Authorize]
        [HttpPost]
        public IActionResult JSInput(Link l)
        {
            context.Links.Add(l);
            context.SaveChanges();

            return RedirectToAction("JSLink");
        }

        [Authorize]
        public IActionResult JSLink()
        {
            var links = context.Links.ToList();
            return View("~/Views/Coding/JS/Link.cshtml", links);
        }

        // begin data manipulation

        [Authorize]
        public IActionResult Index()
        {
            return View();
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
