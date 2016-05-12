using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication1.Models;
using WebApplication1.Models.Entities;
using WebApplication1.Models.ViewModels;
using WebApplication1.Services;
using WebApplication1.Utils;

namespace WebApplication1.Controllers
{
    
    public class CoursesController : Controller
    {
        //
        // GET: /Courses/
        public ActionResult AddCourse()
        {
            CourseViewModel model = new CourseViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCourse(CourseViewModel model)
        {
            if (ModelState.IsValid)
            {
                Course newcourse = new Course();
                newcourse.Name = model.Name;
                CoursesService coursedb = new CoursesService();
                coursedb.AddCourseToDB(newcourse);
                
               return RedirectToAction("ViewCourses");
           }
               
           return View(model);
        }

        public ActionResult ViewCourses()
        {
            CoursesService coursesservice = new CoursesService();
            UserService userservice = new UserService();
            List<CourseViewModel> model = new List<CourseViewModel>();
            if (User.IsInRole("Administrators"))
            {
                model = coursesservice.GetAllCourses();
            }
           else if (User.IsInRole("Teachers") || User.IsInRole("Students"))
            {
                //var name = User.Identity.Name;
                //var id = userservice.GetUserIDByName(name);

                //model = coursesservice.GetCoursesByUserID(id);
                model = coursesservice.GetAllCourses();
            }
            return View(model);
         
        }

        [HttpGet]
        [Route("Courses/ViewCourseDetails/{courseID}")]
        public ActionResult ViewCourseDetails(int? courseID)
        {
            CoursesService cs =  new CoursesService();
            AssignmentsService ass = new AssignmentsService();

            CourseViewModel model = cs.GetCourseByID(courseID.Value);
            model.Assignments = ass.GetAssignmentsByCourseID(courseID.Value);

            return View(model);
        }

        [HttpGet]
        [Route("Courses/AddStudentsToCourse/{courseID}")]
        public ActionResult AddStudentsToCourse(int courseID)
        {
            AddStudentToCourseViewModel model = new AddStudentToCourseViewModel();
            model.CourseID = courseID;

            UserService userService = new UserService();
            model.AvailableStudents = userService.GetAllUsers().Select(x=>new SelectListItem() { Value = x.Id, Text = x.UserName }).ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult AddStudentsToCourse(AddStudentToCourseViewModel model)
        {
            CoursesService courseService = new CoursesService();

            courseService.AddStudentToCourse(model.CourseID, model.UserID);

            return RedirectToAction("ViewCourseDetails", new { courseID = model.CourseID });
        }
   
        [HttpGet]
        [Route("Courses/AddAssignmentToCourse/{courseID}")]
        public ActionResult AddAssignmentsToCourse(int courseID)
        {
            AddAssignmentToCourseViewModel model = new AddAssignmentToCourseViewModel();
            model.CourseID = courseID;

            AssignmentsService assigmentService = new AssignmentsService();
            model.AvailableAssignments = assigmentService.GetAllAssignments().Select(x => new SelectListItem() { Value = x.ID.ToString(), Text = x.Title }).ToList();

            return View(model);
        }

        [HttpPost]
        [Route("Courses/AddAssignmentToCourse/{courseID}")]
        public ActionResult AddAssignmentsToCourse(AddAssignmentToCourseViewModel model)
        {
            CoursesService assignmentService = new CoursesService();

            assignmentService.AddAssignmentToCourse(model.CourseID, model.AssignmentID);

            return RedirectToAction("ViewCourseDetails", new { courseID = model.CourseID });
        }

        [HttpGet]
        [Route("Courses/EditCourse/{courseID}")]
        public ActionResult EditCourse(int? courseID)
        {
            CoursesService b = new CoursesService();
            CourseViewModel model = b.GetCourseByID(courseID.Value);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCourse(CourseViewModel model)
        {
            if (ModelState.IsValid)
            {
                CoursesService coursedb = new CoursesService();
                coursedb.EditCourseInDB(model);

                return RedirectToAction("ViewCourses");
            }
            return View(model);
        }

        [HttpGet]
        [Route("Courses/DeleteCourse/{courseID}")]
        public ActionResult DeleteCourse(int? courseID)
        {
            CoursesService b = new CoursesService();
            CourseViewModel model = b.GetCourseByID(courseID.Value);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCourse(CourseViewModel model)
        {
            if(model.ID != null)
            {
                CoursesService coursedb = new CoursesService();
                coursedb.DeleteCourse(model);

                return RedirectToAction("ViewCourses");
            }
            return View(model);
        }

    }
}