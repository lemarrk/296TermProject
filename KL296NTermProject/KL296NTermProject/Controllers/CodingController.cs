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

        public IActionResult CppMessage()
        {
            var posts = context.Posts.ToList();
            return View("~/Views/Coding/CPP/Message.cshtml", posts);
        }

        [Authorize]
        [HttpPost]
        public IActionResult CppMessage(List<Post> posts)
        {
            return View("~/Views/Coding/CPP/Message.cshtml", posts);
        }

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
        public IActionResult CppLink()
        {
            var links = context.Links.ToList();
            return View("~/Views/Coding/CPP/Link.cshtml", links);
        }

        public IActionResult CSharpMessage()
        {
            var posts = context.Posts.ToList();
            return View("~/Views/Coding/CSharp/Message.cshtml", posts);
        }

        [Authorize]
        public IActionResult CSharpTopic()
        {
            return View("~/Views/Coding/CSharp/Topic.cshtml");
        }

        [Authorize]
        public IActionResult CSharpLink()
        {
            var links = context.Links.ToList();
            return View("~/Views/Coding/CSharp/Link.cshtml",links);
        }


        public IActionResult JSMessage()
        {
            var posts = context.Posts.ToList();
            return View("~/Views/Coding/JS/Message.cshtml", posts);
        }

        [Authorize]
        public IActionResult JSTopic()
        {
            return View("~/Views/Coding/JS/Topic.cshtml");
        }

        [Authorize]
        public IActionResult JSLink()
        {
            var links = context.Links.ToList();
            return View("~/Views/Coding/JS/Link.cshtml", links);
        }

        [Authorize]
        public IActionResult Input()
        {
            return View();
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
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
