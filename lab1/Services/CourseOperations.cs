using lab1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab1.Services
{
    public interface ICourseOperations
    {
        Course CourseDetails(int id);
        int CountStudentInCourse(int id);
        List<Topic> TopicsInCourse(int id);
        List<Course> searchCourseName(string name);
        List<Course> searchCategory(string name);

        List<Topic> Alltopics();
        void CreateCourse(Course course);
        void AddTopics(int id, Dictionary<string, bool> topics);
        void CreateWaitingCourse(waitingCourses Waitingcourse);
        Student GetStudent(int id);


    }
    public class CourseOperations: ICourseOperations
    {
        LearningModel db = new LearningModel();

        
        public Course CourseDetails(int id)
        {
            return db.Courses.SingleOrDefault(a => a.CourseID == id);
        }
        public int CountStudentInCourse(int id)
        {
            var AllStudent = db.students.ToList();
            int StudentInCourse = db.StudentCourses.Where(a => a.CourseID == id).Select(a => a.Student).Count();
            return StudentInCourse;
        }
        public List<Topic> TopicsInCourse(int id)
        {
            var AllTopics = db.topics.ToList();
            var TopicsInCourse = db.courseTopic.Where(a => a.CourseID == id).Select(a => a.Topic).ToList();
            return TopicsInCourse;
        }
        public  List<Course> searchCourseName(string name)
        {
            if (name != null)
            {
                var allCourses = db.Courses.ToList();

               var courses =  allCourses.Where(a => a.Name.Contains(name)).ToList();
                return courses;
            }
            return null;
           
        }

        public List<Course> searchCategory(string name)
        {

            if (name != null)
            {
                List<Course> selectedCourses = db.courseTopic.Include(a=>a.Course)
                                                                .Include(a=>a.Topic)
                                                                .Where(a => a.Topic.Name == name)
                                                                .Select(a => a.Course).ToList();

                return selectedCourses;
               
            }
            return null;
        }


        public List<Topic> Alltopics()
        {
           return db.topics.ToList();
        }
        public void CreateCourse(Course course)
        {
            db.Courses.Add(course);
            db.SaveChanges();
        }
        public void CreateWaitingCourse(waitingCourses Waitingcourse)
        {
            db.waitingCourses.Add(Waitingcourse);
            db.SaveChanges();
        }
        public void AddTopics(int id, Dictionary<string, bool> topics)
        {
            foreach (KeyValuePair<string, bool> item in topics)
            {
                if (item.Value == true)
                {
                    db.waitingCourseTopics.Add(new WaitingCourseTopic { CourseID = id, TopicId = int.Parse(item.Key) });
                }
            }
            db.SaveChanges();
        }
        public Student GetStudent(int id)
        {
           return db.students.SingleOrDefault(a => a.StudentId == id);
        }
    }
}
