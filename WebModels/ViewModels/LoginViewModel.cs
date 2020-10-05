using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebModels.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        // password regex anotation za cliens side validacija a moze da se upotrebe i da se modificire 
        public string Password { get; set; }

    }
}
