using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace KL296NTermProject.Models
{
    public class RegisterVM
    {
        [StringLength(60, MinimumLength = 1)]
        [Required(ErrorMessage = "Enter A user Name")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Compare("ConfirmPassword")]
        [Required(ErrorMessage = "Enter Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Confirm Password Your Password")]
        public string ConfirmPassword { get; set; }

        [StringLength(60, MinimumLength = 1)]
        [Required(ErrorMessage = "Role can only be 'Member' or 'Admin'")]
        public string Role { get; set; }

    }
}
