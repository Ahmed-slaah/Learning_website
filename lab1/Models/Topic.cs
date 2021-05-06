using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab1.Models
{
    public class Topic
    {
        public int TopicId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<CourseTopic> CourseTopics { get; set; }
        public virtual ICollection<WaitingCourseTopic> WaitingCourseTopics { get; set; }

    }
}
