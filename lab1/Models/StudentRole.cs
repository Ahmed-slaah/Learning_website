using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace lab1.Models
{
    public class StudentRole
    {
        [ForeignKey("Role")]
        [Column(Order = 1)]
        public int RoleId { get; set; }
        [ForeignKey("Student")]
        [Column(Order = 0)]
        public int StudentId { get; set; }
        public Role Role{ get; set; }
        public Student Student { get; set; }
    }
}
