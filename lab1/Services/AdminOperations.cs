using lab1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab1.Services
{
    public interface IAdminOperations
    {
        List<Student> getStudents();
        List<Course> getCourses();
        int countStudents();
        int countWaitingCourses();
        int countCourses();
        Student GetStudent(int id);
        List<waitingCourses> waitingCourses();
        void AcceptCourse(int id );
        void Rejected(int id);
        Course GetCourse(int id);
        void DeleteCourse(int id);
        Topic GetTopic(int id);
        void DeleteUser(int id);
    }
    public class AdminOperations:IAdminOperations
    {
        LearningModel db = new LearningModel();
        public List<Student> getStudents()
        {
            return db.students.Skip(1).ToList();
        }
        public List<Course> getCourses()
        {
            return db.Courses.ToList();
        }
        public int countStudents()
        {
            return getStudents().Count(); ;
        }
        public int countCourses()
        {
            return getCourses().Count(); ;
        }
        public int countWaitingCourses()
        {
            return waitingCourses().Count();
        }
        public Student GetStudent(int id)
        {
            return db.students.Include(a => a.StudentCourses).SingleOrDefault(a => a.StudentId == id);
        }
        public List<waitingCourses> waitingCourses()
        {
            return db.waitingCourses.Include(a => a.WaitingCourseTopics).ToList();
        }
        public void AcceptCourse(int id)
        {
            var course = db.waitingCourses.Include(a => a.WaitingCourseTopics).SingleOrDefault(a => a.CourseID == id);
            Course accepted = new Course();
            accepted.authName = course.authName;
            accepted.Cost = course.Cost;
            accepted.CourseImg = course.CourseImg;
            accepted.Name = course.Name;
            accepted.Description = course.Description;
            accepted.Hours = course.Hours;
            db.Courses.Add(accepted);
            db.SaveChanges();


            foreach (var topic in course.WaitingCourseTopics)
            {
                db.courseTopic.Add(new CourseTopic { CourseID = accepted.CourseID, TopicId = topic.TopicId });
            }

            db.waitingCourses.Remove(course);
            db.SaveChanges();
        }
        public void Rejected(int id)
        {
            var course = db.waitingCourses.Include(a => a.WaitingCourseTopics).SingleOrDefault(a => a.CourseID == id);
            db.waitingCourses.Remove(course);
            db.SaveChanges();
        }
        public Course GetCourse(int id)
        {
            return db.Courses.Include(a=>a.CourseTopics).SingleOrDefault(a => a.CourseID == id);
        }
        public void DeleteCourse (int id)
        {
            var course = db.Courses.SingleOrDefault(a => a.CourseID == id);
            db.Courses.Remove(course);
            db.SaveChanges();
        }
        public void DeleteUser(int id)
        {
            var student = db.students.SingleOrDefault(a => a.StudentId == id);
            db.students.Remove(student);
            db.SaveChanges();
        }
        public Topic GetTopic(int id)
        {
            return db.topics.SingleOrDefault(a => a.TopicId == id);
        }
        
    }
}
