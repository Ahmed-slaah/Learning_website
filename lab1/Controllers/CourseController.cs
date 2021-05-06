using lab1.Models;
using lab1.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab1.Controllers
{
    public class CourseController : Controller
    {
        ICourseOperations _db;
        public CourseController(ICourseOperations db)
        {
            _db = db;
        }
        public IActionResult Details(int id,int stid)
        {
            
            int count = _db.CountStudentInCourse(id);
            var topics = _db.TopicsInCourse(id);
            
            ViewBag.count = count;
            ViewBag.stid = stid;

            ViewBag.topics = topics;
            return View(_db.CourseDetails(id));
        }
        [HttpPost]
        public IActionResult searchCourseName(string name)
        {
            int stid = int.Parse(Request.Cookies["stid"]);

            ViewBag.stid = stid;
            var AllTopics = _db.Alltopics();
            ViewBag.AllTopics = AllTopics;
            return PartialView("/Views/Shared/CourseListPartialView.cshtml", _db.searchCourseName(name));
        }

        [HttpPost]
        public IActionResult searchTagName(string tagName,int stid)
        {
            ViewBag.stid = stid;
            var AllTopics = _db.Alltopics();
            ViewBag.AllTopics = AllTopics;
            return PartialView("/Views/Shared/CourseListPartialView.cshtml", _db.searchCategory(tagName));

        }


        [HttpGet]
        public IActionResult CreateCourse()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult CreateCourse(waitingCourses course)
        {
            int Stid = int.Parse(Request.Cookies["stid"]);
            var author = _db.GetStudent(Stid);
            ViewBag.Stid = Stid;
            course.authName = author.FirstName + " " + author.LastName;
            _db.CreateWaitingCourse(course);
            return RedirectToAction("AddTopic",new {id = course.CourseID,stid=Stid });
        }

        [HttpGet]
        public IActionResult AddTopic(int stid)
        {
            ViewBag.stid = stid;
            var alltopics = _db.Alltopics();
            return View(alltopics);
        }
        [HttpPost]
        public IActionResult AddTopic(int id, Dictionary<string, bool> topics)
        {
            int Stid = int.Parse(Request.Cookies["stid"]);
            ViewBag.Stid = Stid;
            _db.AddTopics(id, topics);
            return RedirectToAction("Home","Student",new {id=Stid });
        }

    }
}
