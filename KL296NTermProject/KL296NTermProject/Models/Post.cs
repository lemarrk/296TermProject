using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KL296NTermProject.Models
{
    public class Post
    {
        [Key]
        public int PostID { get; set; }

        [Required]
        public string Sender { get; set; }

        [Required]
        public string Subject { get; set; }

        public DateTime DateSent { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("TopicID")]
        public int TopicID { get; set; }

        public Topic Topic { get; set; }

        public List<Message> Messages { get { return messages; } }

        public List<Message> messages = new List<Message>();

    }
}
