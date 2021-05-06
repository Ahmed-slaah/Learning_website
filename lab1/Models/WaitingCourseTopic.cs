using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace lab1.Models
{
    public class WaitingCourseTopic
    {
        [ForeignKey("Topic")]
        [Column(Order = 1)]
        public int TopicId { get; set; }
        public virtual Topic Topic { get; set; }

        [ForeignKey("WaitingCourse")]
        [Column(Order = 0)]
        public int CourseID { get; set; }
        public virtual waitingCourses WaitingCourse { get; set; }
    }
}
