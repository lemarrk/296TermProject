using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KL296NTermProject.Models
{
    public class Post
    {
        public int PostID { get; set; }

        public List<Message> Messages { get; set; }

        public string Sender { get; set; }

        public string Reciever { get; set; }

        public string Subject { get; set; }

        public DateTime DateSent { get; set; }

        public string Body { get; set; }

        public string Name { get; set; }
    }
}
