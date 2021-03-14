using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KL296NTermProject.Models
{
    public class Link
    {
        [Key]
        public int LinkID { get; set; }

        public string Sender { get; set; }

        public string Subject { get; set; }

        public DateTime DateSent { get; set; }

        public string URL { get; set; }

        public string UrlName { get; set; }

        [ForeignKey("TopicID")]
        public int TopicID { get; set; }

        public Topic Topic { get; set; }
    }
}
