using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KL296NTermProject.Models
{
    public class Topic
    {
        [Key]
        public int TopicID { get; set; }

        public string AdminName { get; set; }

        public int PostsID { get; set; }

        public List<Post> Posts { get; set; }

        public int VideosID { get; set; }

        public List<Video> Videos { get; set; }

        public int LinksID { get; set; }

        public List<Link> Links { get; set; }
    }
}
