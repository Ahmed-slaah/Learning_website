using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace lab1.Models
{
    public class CourseTopic
    {
        [ForeignKey("Topic")]
        [Column (Order =1)]
        public int TopicId { get; set; }
        public virtual Topic Topic { get; set; }

        [ForeignKey("Course")]
        [Column(Order = 0)]
        public int CourseID { get; set; }
        public virtual Course Course { get; set; }


    }
}
