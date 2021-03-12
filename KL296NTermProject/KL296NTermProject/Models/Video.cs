using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KL296NTermProject.Models
{
    public class Video
    {
        [Key]
        public int VideoID { get; set; }

        public string Sender { get; set; }

        public string Subject { get; set; }

        public DateTime DateSent { get; set; }

        public string URL { get; set; }

        public Topic Topic { get; set; }

    }
}
