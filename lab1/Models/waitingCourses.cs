using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace lab1.Models
{
    public class waitingCourses
    {
        [Key]
        public int CourseID { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Range(1, 120)]
        public int Hours { get; set; }
        public String Name { get; set; }
        public string CourseImg { get; set; }
        public string Description { get; set; }
        public int Cost { get; set; }
        public string authName { get; set; }
        public virtual ICollection<WaitingCourseTopic> WaitingCourseTopics { get; set; }

    }
}
