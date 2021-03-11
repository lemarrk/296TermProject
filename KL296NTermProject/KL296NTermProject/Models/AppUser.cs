using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace KL296NTermProject.Models
{
    public class AppUser : IdentityUser
    {
        [NotMapped]
        public IList<string> RoleNames { get; set; }

        [StringLength(60, MinimumLength = 1)]
        [Required]
        public string Role { get; set; }
    }
}
