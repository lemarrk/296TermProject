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

        public int? PostID { get; set; }

        [ForeignKey("PostID")]
        public ICollection<Post> Post { get; set; }

        public int? VideoID { get; set; }

        [ForeignKey("VideoID")]
        public ICollection<Video> Video { get; set; }

        public int? LinkID { get; set; }

        [ForeignKey("LinkID")]
        public ICollection<Link> Link { get; set; }
    }
}
