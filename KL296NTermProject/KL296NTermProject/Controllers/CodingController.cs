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

        [HttpPost]
        public IActionResult Search(string topic, string content)
        {

            return View();
        }

        // Posts below

        [Authorize]
        [HttpGet]
        public IActionResult InputPost()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult InputPost(Post p, string id)
        {
            p.TopicID = Convert.ToInt32(id);

            if(p.TopicID != 0)
            {

                p.DateSent = DateTime.Now;

                switch (id)
                {
                    case "1":
                        context.Posts.Add(p);
                        context.SaveChanges();
                        var posts = context.Posts.Where(o => o.TopicID == p.TopicID).ToList();
                        return View("./Views/Coding/Cpp/Post.cshtml", posts);

                    case "2":
                        context.Posts.Add(p);
                        context.SaveChanges();
                        var posts1 = context.Posts.Where(o => o.TopicID == p.TopicID).ToList();
                        return View("./Views/Coding/CSharp/Post.cshtml", posts1);

                    case "3":
                        context.Posts.Add(p);
                        context.SaveChanges();
                        var posts2 = context.Posts.Where(o => o.TopicID == p.TopicID).ToList();
                        return View("./Views/Coding/JS/Post.cshtml", posts2);

                    default:
                        break;
                }
            }
            return View(new Post());
        }

        /////////////////////////////// LInks  below
   
        [Authorize]
        [HttpGet]
        public IActionResult InputLink()
        {
            return View(new Link());
        }

        [Authorize]
        [HttpPost]
        public IActionResult InputLink(Link p, string id)
        {
            p.TopicID = Convert.ToInt32(id);

            if(p.TopicID != 0)
            {
                p.DateSent = DateTime.Now;

                switch (id)
                {
                    case "1":
                        context.Links.Add(p);
                        context.SaveChanges();
                        var posts = context.Links.Where(o => o.TopicID == p.TopicID).ToList();
                        return View("./Views/Coding/Cpp/Link.cshtml", posts);

                    case "2":
                        context.Links.Add(p);
                        context.SaveChanges();
                        var posts1 = context.Links.Where(o => o.TopicID == p.TopicID).ToList();
                        return View("./Views/Coding/CSharp/Link.cshtml", posts1);

                    case "3":
                        context.Links.Add(p);
                        context.SaveChanges();
                        var posts2 = context.Links.Where(o => o.TopicID == p.TopicID).ToList();
                        return View("./Views/Coding/JS/Link.cshtml", posts2);

                    default:
                        break;
                }
            }

            return View(new Link());
        }


        /////////////////////////////// Input Below

        [Authorize]
        [HttpGet]
        public IActionResult InputMessage()
        {
           return View(new Message());
        }

        [Authorize]
        [HttpPost]
        public IActionResult InputMessage(Message p, string id)
        {
            if(id == null) {
                id = "0";
            }

            var post_id = Convert.ToInt32(id);

            if(post_id != 0)
            {
                p.DateSent = DateTime.Now;
                p.PostID = post_id;

                switch (id)
                {
                    case "1":
                        context.Messages.Add(p);
                        context.SaveChanges();
                        var posts = context.Messages.Where(o => o.Post.PostID == post_id).ToList();
                        return View("./Views/Coding/Cpp/Message.cshtml", posts);

                    case "2":
                        context.Messages.Add(p);
                        context.SaveChanges();
                        var posts1 = context.Messages.Where(o => o.Post.PostID == post_id).ToList();
                        return View("./Views/Coding/CSharp/Message.cshtml", posts1);

                    case "3":
                        context.Messages.Add(p);
                        context.SaveChanges();
                        var posts2 = context.Messages.Where(o => o.Post.PostID == post_id).ToList();
                        return View("./Views/Coding/JS/Message.cshtml", posts2);

                    default:
                        break;
                }

            }

            return View(new Message());
        }

        // // / // / //  //
        [Authorize]
        [HttpGet] 
        public IActionResult CppMessage()
        {
            //var posts = context.Topics.Include("Posts").Where(o => o.TopicName == "Cpp").Select(o => o).ToList();
            var message = context.Posts.Where(o => o.Topic.TopicName == "Cpp").ToList();
            //var messages = context.Messages.Where(o => o.PostID == id).Select(o => o).ToList();
            return View("./Views/Coding/CPP/Message.cshtml", message);
        }

        [Authorize]
        [HttpPost]
        public IActionResult CppMessage(int id)
        {
            //var posts = context.Topics.Include("Posts").Where(o => o.TopicName == "Cpp").Select(o => o).ToList();
            //var message = context.Messages.Include("Posts").Where(p => p.MessageID).ToList();
            //var messages = context.Messages.Where(o => o.PostID == id).Select(o => o).ToList();
            var messages = context.Messages.Where(o => o.Post.PostID == id).ToList();
            return View("./Views/Coding/CPP/Message.cshtml", messages);
        }

        [HttpGet]
        public IActionResult CppPost()
        {
            var posts = context.Posts.Where(o => o.Topic.TopicName == "Cpp").Select(o => o).ToList();
            return View("./Views/Coding/CPP/Post.cshtml", posts);
        }

        [Authorize]
        [HttpGet]
        public IActionResult CppLink()
        {
            var links = context.Links.Where(o => o.Topic.TopicName == "Cpp").ToList();
            return View("./Views/Coding/CPP/Link.cshtml", links);
        }

        /// ////

        [HttpGet]
        public IActionResult CSharpPost()
        {
            var posts = context.Posts.Where(o => o.Topic.TopicName == "CSharp").Select(o => o).ToList();
            return View("./Views/Coding/CSharp/Post.cshtml", posts);
        }

        [Authorize]
        [HttpGet]
        public IActionResult CSharpMessage()
        {
            var messages = context.Messages.ToList();
            return View("./Views/Coding/CSharp/Message.cshtml", messages);
        }

        // csharp section
        [Authorize]
        [HttpPost]
        public IActionResult CSharpMessage(int id)
        {
            var messages = context.Messages.Where(o => o.Post.PostID == id).ToList();
            return View("./Views/Coding/CSharp/Message.cshtml", messages);
        }

        //[Authorize]
        //public IActionResult CSharpTopic()
        //{
        //    return View("./Views/Coding/CSharp/Topic.cshtml");
        //}

        //[Authorize]
        //[HttpPost]
        //public IActionResult CSharpTopic(Post p)
        //{
        //    p.DateSent = DateTime.Now;
        //    context.Posts.Add(p);
        //    context.SaveChanges();

        //    return RedirectToAction("CSharpMessage");
        //}

        [Authorize]
        public IActionResult CSharpLink()
        {
            var links = context.Links.Where(o => o.Topic.TopicName == "CSharp").ToList();
            return View("./Views/Coding/CSharp/Link.cshtml", links);
        }

        //////////
        
        [HttpGet]
        public IActionResult JSPost()
        {
            var posts = context.Posts.Where(o => o.Topic.TopicName == "JS").Select(o => o).ToList();
            return View("./Views/Coding/JS/Post.cshtml", posts);
        }


        // begin js section
        [Authorize]
        [HttpGet]
        public IActionResult JSMessage()
        {
            var messages = context.Messages.ToList();
            return View("./Views/Coding/JS/Message.cshtml", messages);
        }

        // begin js section
        [Authorize]
        [HttpPost]
        public IActionResult JSMessage(int id)
        {
            var messages = context.Messages.Where(o => o.Post.PostID == id).ToList();
            return View("./Views/Coding/JS/Message.cshtml", messages);
        }

        //[Authorize]
        //public IActionResult JSTopic()
        //{
        //    return View("./Views/Coding/JS/Topic.cshtml");
        //}

        //[Authorize]
        //[HttpPost]
        //public IActionResult JSTopic(Post p)
        //{
        //    p.DateSent = DateTime.Now;
        //    context.Posts.Add(p);
        //    context.SaveChanges();

        //    return RedirectToAction("JSMessage");
        //}

        [Authorize]
        public IActionResult JSLink()
        {
            var links = context.Links.Where(o => o.Topic.TopicName == "JS").ToList();

            return View("./Views/Coding/JS/Link.cshtml", links);
        }

        // begin data manipulation for cpp

        [Authorize]
        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            var post = context.Posts.Find(id);
            var topic_id = post.TopicID;

            if (post != null)
            {
                // var post = posts.Where(p => p.MessageID == id).FirstOrDefault()
                context.Posts.Remove(post);
                context.SaveChanges();

                switch (topic_id)
                {
                    case 1:
                        var posts = context.Posts.Where(o => o.TopicID == topic_id).ToList();
                        return View("./Views/Coding/Cpp/Post.cshtml", posts);

                    case 2:
                        var posts1 = context.Posts.Where(o => o.TopicID == topic_id).ToList();
                        return View("./Views/Coding/CSharp/Post.cshtml", posts1);

                    case 3:
                        var posts2 = context.Posts.Where(o => o.TopicID == topic_id).ToList();
                        return View("./Views/Coding/JS/Post.cshtml", posts2);

                    default:
                        break;
                };
            }

            return RedirectToAction("Index", "Home");
        }


        [Authorize]
        [HttpPost]
        public IActionResult DeleteLink(int id)
        {
            var link = context.Links.Find(id);
            var topic_id = link.TopicID;

            if (link != null)
            {
                // var post = posts.Where(p => p.MessageID == id).FirstOrDefault()
                context.Links.Remove(link);
                context.SaveChanges();

                switch (topic_id)
                {
                    case 1:
                        var posts = context.Links.Where(o => o.TopicID == topic_id).ToList();
                        return View("./Views/Coding/Cpp/Link.cshtml", posts);

                    case 2:
                        var posts1 = context.Links.Where(o => o.TopicID == topic_id).ToList();
                        return View("./Views/Coding/CSharp/Link.cshtml", posts1);

                    case 3:
                        var posts2 = context.Links.Where(o => o.TopicID == topic_id).ToList();
                        return View("./Views/Coding/JS/Link.cshtml", posts2);

                    default:
                        break;
                };
            }

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpPost]
        public IActionResult DeleteMessage(int id)
        {
            var m = context.Messages.Find(id);
           // var message_id = m.Post.PostID;

            if (m != null)
            {
                // var post = posts.Where(p => p.MessageID == id).FirstOrDefault()
                context.Messages.Remove(m);
                context.SaveChanges();

                switch (m.PostID)
                {
                    case 1:
                        var posts = context.Messages.Where(o => o.Post.PostID == m.PostID).ToList();
                        return View("./Views/Coding/Cpp/Message.cshtml", posts);

                    case 2:
                        var posts1 = context.Messages.Where(o => o.Post.PostID == m.PostID).ToList();
                        return View("./Views/Coding/CSharp/Message.cshtml", posts1);

                    case 3:
                        var posts2 = context.Messages.Where(o => o.Post.PostID == m.PostID).ToList();
                        return View("./Views/Coding/JS/Message.cshtml", posts2);

                    default:
                        break;
                };
            }

            return RedirectToAction("Index", "Home");
        }

    }
}
