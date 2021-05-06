using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab1.Models
{
    public class LearningModel:DbContext
    {
        public LearningModel()
        {

        }
        public DbSet<Student> students { get;set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<waitingCourses> waitingCourses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<Topic> topics { get; set; }
        public DbSet<CourseTopic> courseTopic { get; set; }
        public DbSet<WaitingCourseTopic> waitingCourseTopics { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-OU52S1K\\AHMEDPC;database=Learning;trusted_connection=true;");
            //base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>().HasKey(k => new { k.CourseID, k.StudentId });
            modelBuilder.Entity<CourseTopic>().HasKey(k => new { k.CourseID, k.TopicId });
            modelBuilder.Entity<WaitingCourseTopic>().HasKey(k => new { k.CourseID, k.TopicId });
            modelBuilder.Entity<StudentRole>().HasKey(k => new { k.StudentId, k.RoleId });


        }
    }
}
