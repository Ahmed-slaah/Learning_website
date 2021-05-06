using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace lab1.Models
{
    public class CreateStudentViewModel
    {
        [Required(ErrorMessage = "You must inter Your Email")]
        [RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$")]
        public String Email { get; set; }

        [Required(ErrorMessage = "You must inter Your First Name")]
        [StringLength(20, MinimumLength = 3)]
        public String FirstName { get; set; }

        public string gender { get; set; }

        [Required(ErrorMessage = "You must inter Your Last Name")]
        [StringLength(20, MinimumLength = 3)]
        public String LastName { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Range(6, 60)]
        public int? Age { get; set; }

        [Required(ErrorMessage = "You must inter Your Country")]
        public String Country { get; set; }

        [Required(ErrorMessage = "You must inter Your City")]
        public String City { get; set; }

        [Required(ErrorMessage = "You must inter Your Password")]
        public String Password { get; set; }

        [Compare("Password", ErrorMessage = "password and password confirm must be same")]
        [NotMapped]
        public String ConfirmPassword { get; set; }

        [Display(Name = "Profile Picture")]
        public IFormFile ProfileImage { get; set; }
    }
}
