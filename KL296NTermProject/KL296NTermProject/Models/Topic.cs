using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KL296NTermProject.Models
{
    public class Topic
    {
        public int TopicID { get; set; }

        public List<Post> Posts { get; set; }

        public List<Video> Videos { get; set; }

        public List<Link> Links { get; set; }
    }
}
