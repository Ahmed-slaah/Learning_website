using lab1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace lab1.Controllers
{
    public interface IStudentOperations
    {
        List<Student> getStudents();
        Student getStudent(int id);
        void deleteStudent(int id);
        void AddStudent(Student student);
        void EditStudent(Student st);
        List<Course> StudentCourses(int id);
        List<Course> anotherCourses(int id);
        List<Topic> CoursesTopis(int id);
        List<Topic> Topics();
        void JoinCourse(int courseId, int StudentId);
        void deleteCourse(int courseId, int StudentId);
        Student login(LoginViewModel login);

    }
    public class StudentOperation : IStudentOperations
    {
        LearningModel db = new LearningModel();
        public List<Student> getStudents()
        {
            var x = db.students.Include("StudentCourses").ToList();
            return x;
        }
        public Student getStudent(int id)
        {
            return (db.students.Include(a=>a.StudentRoles).SingleOrDefault(a => a.StudentId == id));
        }
        public Student login(LoginViewModel  login)
        {
            var student = db.students.Include(a => a.StudentRoles)
                .SingleOrDefault(a => a.Email == login.Email && a.Password == login.password);
           
                return (student);
            
        }
        public void deleteStudent(int id)
        {
            var s = db.students.SingleOrDefault(a => a.StudentId == id);
            db.students.Remove(s);
            db.SaveChanges();
        }
        public void AddStudent(Student student)
        {
            db.students.Add(student);
            db.SaveChanges();
        }
        public void EditStudent(Student st)
        {
            var student = db.students.SingleOrDefault(a => a.StudentId == st.StudentId);
            if (student != null)
            {
                student.FirstName = st.FirstName;
                student.LastName = st.LastName;
                student.gender = st.gender;
                student.Email = st.Email;
                student.City = st.City;
                student.Country = st.Country;
                student.Password = st.Password;
                student.Age = st.Age;
                db.SaveChanges();
            }

        }
        public List<Course> StudentCourses(int id)
        {
            var AllCourses = db.Courses.Include(a=>a.CourseTopics).ToList();

            var studentCourses = db.StudentCourses.Where(a => a.StudentId == id).Select(a => a.Course).ToList();
            return studentCourses;
        }
        public List<Course> anotherCourses(int id)
        {
            var AllCourses = db.Courses.ToList();
            var studentcourses = StudentCourses(id);
            return (AllCourses.Except(studentcourses).ToList());

        }
        public List<Topic> CoursesTopis(int id)
        {
            var allTopics = db.topics.ToList();
            var coursetopic = db.courseTopic.Where(a => a.CourseID == id).Select(a => a.Topic).ToList();
            return coursetopic;
        }
        public List<Topic> Topics()
        {
            return db.topics.ToList();
        }
        public void JoinCourse(int courseId, int StudentId)
        {
            db.StudentCourses.Add(new StudentCourse() { CourseID = courseId, StudentId = StudentId });
            db.SaveChanges();
        }
        public void deleteCourse(int courseId, int StudentId)
        {
            db.StudentCourses.Remove(new StudentCourse() { CourseID = courseId, StudentId = StudentId });
            db.SaveChanges();
        }
    }
}
