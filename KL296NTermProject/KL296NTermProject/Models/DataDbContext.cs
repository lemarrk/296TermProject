using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace KL296NTermProject.Models
{
    public class DataDbContext : IdentityDbContext<AppUser>
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options) { }  

        public DbSet<Rules> Rules { get; set; }

        public DbSet<Topic> Topics { get; set; }

        public DbSet<Video> Videos { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Link> Links { get; set; }
    }
}
