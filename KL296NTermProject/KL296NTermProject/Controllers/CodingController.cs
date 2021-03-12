using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KL296NTermProject.Models;
using Microsoft.EntityFrameworkCore;

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

        [HttpPost]
        public IActionResult CppMessage(List<Post> posts)
        {
            return View("~/Views/Coding/CPP/Message.cshtml", posts);
        }

        public IActionResult CppTopic()
        {
            var topic = new Post();
            return View("~/Views/Coding/CPP/Topic.cshtml", topic);
        }

        [HttpPost]
        public IActionResult CppTopic(Post p)
        {
            p.DateSent = DateTime.Now;
            context.Posts.Add(p);
            context.SaveChanges();
   
            return RedirectToAction("CppMessage");
        }

        public IActionResult CppLink()
        {
            var links = context.Links.ToList();
            return View("~/Views/Coding/CPP/Link.cshtml", links);
        }

        public IActionResult CSharpMessage()
        {
            return View("~/Views/Coding/CSharp/Message.cshtml", new List<Message>());
        }

        public IActionResult CSharpTopic()
        {
            return View("~/Views/Coding/CSharp/Topic.cshtml");
        }

        public IActionResult CSharpLink()
        {
            return View("~/Views/Coding/CSharp/Link.cshtml");
        }

        public IActionResult JSMessage()
        {
            return View("~/Views/Coding/JS/Message.cshtml", new List<Message>());
        }

        public IActionResult JSTopic()
        {
            return View("~/Views/Coding/JS/Topic.cshtml");
        }

        public IActionResult JSLink()
        {
            return View("~/Views/Coding/JS/Link.cshtml");
        }

        public IActionResult Input()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DeleteCppMessage(int id)
        {
            var post = context.Posts.Find(id);

            if (post != null)
            {
               // var post = posts.Where(p => p.MessageID == id).FirstOrDefault();

                context.Posts.Remove(post);
                context.SaveChanges();
            }

            return RedirectToAction("CppMessage");
        }
    }
}
