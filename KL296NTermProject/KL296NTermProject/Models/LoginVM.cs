using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KL296NTermProject.Models
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Enter a name")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter a password")]
        [StringLength(255)]
        public string Password { get; set; }

        public string ReturnURL { get; set; }

        public bool RememberMe { get; set; }

        public bool alreadyLoggedIn { get; set; } = false;

        public RulesVM RuleVM { get; set; }
    }
}
