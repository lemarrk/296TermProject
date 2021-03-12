using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KL296NTermProject.Models
{
    public class PostVM
    {
        public Post post { get; set; }

        public List<Message> messages { get; set; }
    }
}
