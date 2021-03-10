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
        //[Key]
        public int MessageID { get; set; }

        public string Topic { get; set; }

        //[StringLength(255)]
        //[Required(ErrorMessage = "Sender must have at least one to 255 characters")]
        public string Name { get; set; }

        public DateTime DateSent { get; set; }

        //[StringLength(1000)]
        //[Required(ErrorMessage = "Message must have at least one to 1000 characters")]
        public string Body { get; set; }
    }
}
