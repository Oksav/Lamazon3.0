using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebModels.ViewModels
{
    public class RegisterViewModel
    {
        
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

       
        public string Username { get; set; }

      
        public string Email { get; set; }

      
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }
    }
}
