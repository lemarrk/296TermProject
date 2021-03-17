using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KL296NTermProject.Models
{
    public class SearchVM
    {
        public string TopicName { get; set; }

        public List<Link> searchLinks = new List<Link>();
        public List<Post> searchPosts = new List<Post>();
        public List<Message> searchMessage = new List<Message>();

        public List<Link> SearchLink { get { return searchLinks; } }
        public List<Post> SearchPost { get { return searchPosts; } }
        public List<Message> SearchMessage { get { return searchMessage; } }
    }
}
