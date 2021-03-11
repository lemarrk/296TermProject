using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KL296NTermProject.Models
{
    public class Rules
    {
        [Key]
        public int RulesID { get; set; }

        public string AdminName { get; set; }

        public List<string> Rule { get; set; }
    }
}
