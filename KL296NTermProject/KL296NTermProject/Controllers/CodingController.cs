using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KL296NTermProject.Models;

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

        public IActionResult CppTopic()
        {
            return View("~/Views/Coding/CPP/Topic.cshtml");
        }

        public IActionResult CppLink()
        {
            return View("~/Views/Coding/CPP/Link.cshtml");
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

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveMessage(Message m)
        {
            m = new Message();

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
