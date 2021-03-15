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

        public string TopicName { get; set; }

        public List<Post> Posts { get { return posts; } }
        public List<Post> posts = new List<Post>();

        public List<Video> Videos { get { return videos; } }
        public List<Video> videos = new List<Video>();

        public List<Link> Links { get { return links; } }
        public List<Link> links = new List<Link>();
    }
}
