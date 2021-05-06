using lab1.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace lab1.Controllers
{
    public class StudentController : Controller
    {
        IStudentOperations _db;
        IWebHostEnvironment webHostEnvironment;

        public StudentController(IStudentOperations db, IWebHostEnvironment hostEnvironment)
        {
            _db = db ;
            webHostEnvironment = hostEnvironment;
        }
        public IActionResult AllStudents()
        {
            return View(_db.getStudents());
        }
        public IActionResult Details(int id)
        {
            var courses = _db.StudentCourses(id);
            var count =courses.Count();
            List<Topic> Topics = new List<Topic>();
            
            foreach(var c in courses)
            {
                
                var Topicss =_db.CoursesTopis(c.CourseID);
                foreach(var t in Topicss)
                {
                    Topics.Add(t);
                }
            }
            ViewBag.courseId = Topics;
            ViewBag.courses = courses;
            ViewBag.count = count;
            var st = _db.getStudent(id);
            return View(st);
        }
        public IActionResult Delete(int id)
        {
            _db.deleteStudent(id);
            return RedirectToAction("AllStudents");
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(CreateStudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);
                Student student = new Student()
                {
                    Age=model.Age,
                    City=model.City,
                    ConfirmPassword=model.ConfirmPassword,
                    Country=model.Country,
                    Email=model.Email,
                    FirstName=model.FirstName,
                    gender=model.gender,
                    LastName=model.LastName,
                    Password=model.Password,
                    ProfileImg=uniqueFileName,
                };
                _db.AddStudent(student);
                return View("Login");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel logedStudent)
        {
            if (ModelState.IsValid) { 
                var student = _db.login(logedStudent);
                if (student != null)
                {
                    CookieOptions options = new CookieOptions();
                    Response.Cookies.Append("stid", student.StudentId.ToString());


                    foreach (var role in student.StudentRoles)
                    {
                        if (role.RoleId == 1)
                        {
                            //  options.Expires = DateTime.Now.AddDays(1);
                            return RedirectToAction("Home", "Admin", new { id = student.StudentId });
                        }
                    }
                    return RedirectToAction("Details", new { id = student.StudentId });


                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
           var student =  _db.getStudent(id);
            return View(student);
        }
        [HttpPost]
        public IActionResult Edit(Student st)
        {
           // st.StudentId = 1;
            _db.EditStudent(st);
            return RedirectToAction("Details",new { id=st.StudentId});
        }
        public IActionResult Home(int id)
        {
            ViewBag.stid = id;
            var AllTopics = _db.Topics();
            ViewBag.AllTopics = AllTopics;
            var anotehrCourses = _db.anotherCourses(id);
            var recentCourses = anotehrCourses.Last();
            
            ViewBag.recentCourses = recentCourses;
            return View(anotehrCourses);
        }
        public IActionResult JoinCourse(int id, int stId)
        {
            ViewBag.stId = stId;
            _db.JoinCourse(id, stId);
            return RedirectToAction("Details",new {id=stId });
        }
        public IActionResult DeleteCourse(int id, int stId)
        {
            _db.deleteCourse(id, stId);
            return RedirectToAction("Details", new { id = stId });
        }


        /**********************/
        private string UploadedFile(CreateStudentViewModel model)
        {
            string uniqueFileName = null;

            if (model.ProfileImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfileImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProfileImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

    }
}
