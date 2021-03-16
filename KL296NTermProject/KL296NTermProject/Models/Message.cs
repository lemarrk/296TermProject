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

        [Required]
        public string Sender { get; set; }

        [Required]
        public string Subject { get; set; }

        public DateTime DateSent { get; set; }

        [Required]
        public string Body { get; set; }

        [ForeignKey("PostID")]
        public int PostID { get; set; }

        public Post Post { get; set; }
    }
}
