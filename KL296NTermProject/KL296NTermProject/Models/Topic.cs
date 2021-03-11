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

        public Post Post { get; set; }

        public int VideosID { get; set; }

        public Video Video { get; set; }

        public int LinksID { get; set; }

        public Link Link { get; set; }
    }
}
