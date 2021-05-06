using lab1.Models;
using lab1.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab1.Controllers
{
    public class AdminController : Controller
    {
        IAdminOperations _db;
        public AdminController(IAdminOperations db)
        {
            _db = db;
        }
        public IActionResult Home(int id = 2004)
        {
            ViewBag.students=_db.countStudents();
            ViewBag.courses = _db.countCourses();
            ViewBag.waitingCourses = _db.countWaitingCourses();
            ViewBag.AllUsers = _db.getStudents();
            return View(_db.GetStudent(id));
        }
        public IActionResult Users()
        {
            return PartialView("~/Views/Shared/UsersPartialView.cshtml", _db.getStudents());
        }
        public IActionResult Courses()
        {
            return PartialView("~/Views/Shared/CoursesPartialView.cshtml", _db.getCourses());
        }
        public IActionResult WaitingCourses()
        {
            return PartialView("~/Views/Shared/WaitingCoursesPartialView.cshtml", _db.waitingCourses());
        }
        public IActionResult acceptCourse(int id)
        {
            _db.AcceptCourse(id);
            return RedirectToAction("Home","Admin",new {id=2004});
        }
        public IActionResult rejectCourse(int id)
        {
            _db.Rejected(id);
            return RedirectToAction("Home", "Admin", new { id = 2004 });
        }
        public IActionResult Delete(int id)
        {
            _db.DeleteCourse(id);
            return RedirectToAction("Home","Admin",new {id=2004 });
        }
        public IActionResult DeleteStudent(int id)
        {
            _db.DeleteUser(id);
            return RedirectToAction("Home", "Admin", new { id = 2004 });
        }
        public IActionResult Details(int id)
        {
            var course = _db.GetCourse(id);
            List<Topic> topics = new List<Topic>();
            foreach(var topic in course.CourseTopics)
            {
                var topicc = _db.GetTopic(topic.TopicId);
                topics.Add(topicc);
            }
            ViewBag.topics = topics;
            return View(course);
        }
        public IActionResult StudentDetails(int id)
        {
            return PartialView("~/Views/Shared/DetailsModal.cshtml", _db.GetStudent(id));
        }
    }
}
