﻿using System;
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

        public string Sender { get; set; }

        public string Subject { get; set; }

        public DateTime DateSent { get; set; }

        public string Body { get; set; }

        public string Name { get; set; }

        [ForeignKey("MessageID")]
        public List<Post> Posts { get; set; }
    }
}
