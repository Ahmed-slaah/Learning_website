using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace lab1.Models
{
    public enum Gender { Male, Female };

    public class Student
    {
        [Key]
        public int StudentId { get; set; }

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
        public String ProfileImg { get; set; }

        [Required(ErrorMessage = "You must inter Your Password")]
        public String Password { get; set; }

        [Compare("Password", ErrorMessage = "password and password confirm must be same")]
        [NotMapped]
        public String ConfirmPassword { get; set; }

        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
        public virtual ICollection<StudentRole> StudentRoles { get; set; }



    }
}
