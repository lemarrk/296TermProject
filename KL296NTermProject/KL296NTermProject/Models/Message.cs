using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KL296NTermProject.Models
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }

        public Topic Topic { get; set; }

        public string Name { get; set; }

        public DateTime DateSent { get; set; }

        public string Body { get; set; }

        [ForeignKey("PostsID")]
        public List<Post> Posts { get; set; }
    }
}
