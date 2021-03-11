using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KL296NTermProject.Models
{
    public class LoginVM
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public string ReturnURL { get; set; }

        public bool RememberMe { get; set; }

        public bool alreadyLoggedIn { get; set; } = false;

        public RulesVm rules { get; set; }
    }
}
