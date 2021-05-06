using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace lab1.Models
{
    public class StudentCourse
    {
        
        [ForeignKey("Student")]
        [Column(Order = 1)]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        
        [ForeignKey("Course")]
        [Column(Order = 0)]
        public int CourseID { get; set; }
        public virtual Course Course { get; set; }

        public int Degree { get; set; }

    }
}
