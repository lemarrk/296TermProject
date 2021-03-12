using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace KL296NTermProject.Models
{
    public class AdminVM
    {
       public IEnumerable<AppUser> Users { get; set; }
       public IEnumerable<IdentityRole> Roles { get; set; }
    }
}
