using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KL296NTermProject.Models
{
    public class Video
    {
        public int VideoID { get; set; }

        public string Sender { get; set; }

        public string Subject { get; set; }

        public DateTime DateSent { get; set; }

        public string URL { get; set; }
    }
}
