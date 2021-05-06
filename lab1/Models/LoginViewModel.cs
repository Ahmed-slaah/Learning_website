using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace lab1.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "You must inter Your Email")]
        [RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$")]
        public string Email { get; set; }
        [Required(ErrorMessage = "You must inter Your Password")]
        public string password { get; set; }
    }
}
