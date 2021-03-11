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
    }
}
