using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KL296NTermProject.Models
{
    public class LoginVM
    {
        [StringLength(60, MinimumLength = 1)]
        [Required(ErrorMessage = "Enter a name")]
        public string Name { get; set; }


        [StringLength(60, MinimumLength = 1)]
        [Required(ErrorMessage = "Enter a password")]
        public string Password { get; set; }

        public string ReturnURL { get; set; }

        public bool RememberMe { get; set; }

        public bool alreadyLoggedIn { get; set; } = false;

        public RulesVM RuleVM { get; set; }
    }
}
