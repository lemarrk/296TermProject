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

        public int PostID { get; set; }

        public List<Post> Post { get; set; }

        public int VideoID { get; set; }

        public List<Video> Video { get; set; }
    
        public int LinkID { get; set; }

        public List<Link> Link { get; set; }
    }
}
