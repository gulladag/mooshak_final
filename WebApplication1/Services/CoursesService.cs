using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApplication1.Models;
using WebApplication1.Models.Entities;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Services
{
    public class CoursesService
    {
        private ApplicationDbContext _db;
        public CoursesService()
        {
            _db = new ApplicationDbContext();
        }
        public void AddCourseToDB(Course newCourse)
        {
            _db.Courses.Add(newCourse);
            _db.SaveChanges();
        }

        public CourseViewModel GetCourseByID(int courseID)
        {
            var course = _db.Courses.SingleOrDefault(x => x.ID == courseID);
            if (course == null) return null;

            return new CourseViewModel() { ID = course.ID, Name = course.Name, Students = course.Students.ToList() };
        }

        public void EditCourseInDB(CourseViewModel model)
        {
            var course = _db.Courses.SingleOrDefault(x => x.ID == model.ID);
            course.Name = model.Name;
            _db.Entry(course).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void DeleteCourse(CourseViewModel model)
        {
            var course = _db.Courses.SingleOrDefault(x => x.ID == model.ID);
            _db.Courses.Remove(course);
            _db.SaveChanges();
        }
        public List<CourseViewModel> GetAllCourses()
        {
            List<CourseViewModel> skil = new List<CourseViewModel>();
            var courses = _db.Courses.ToList();
            foreach (Course x in courses)
            {
                var temp = new CourseViewModel();
                temp.Name = x.Name;
                temp.ID = x.ID;
                skil.Add(temp);
            }
            skil.Sort((x, y) => string.Compare(x.Name, y.Name));
            return skil;
        }


        public List<UserViewModel> GetStudentsInCourse(int ThisCourseID)
        {
            /*
            List<UserViewModel> students = new List<UserViewModel>();
            var b = (from a in _db.CourseAndUser
                     where (a.CourseID == ThisCourseID)
                     select a).ToList();
            List<int> idlist = new List<int>();
            foreach (var x in b)
            {
                idlist.Add(x.UserID);
            }*/
            /*foreach(var x in idlist)
            {
                var y = from a in _db.
            }*/


            //students.Sort((x, y) => string.Compare(x.Name, y.Name));
            return null;//students;

        }

        public List<ApplicationUser> GetStudentsByCourseID(int courseID)
        {
            var course = (from courses in _db.Courses where courses.ID == courseID select courses).SingleOrDefault();
            return course.Students.ToList();
        }

        //Virkni ekki komið í lag
        public List<CourseViewModel> GetCoursesByUserID(string userID)
        {
            List<CourseViewModel> skil = new List<CourseViewModel>();
            var user = (from users in _db.Users where (users.Id == userID)select users ).SingleOrDefault();
            var courses = user.Courses.ToList();
            foreach (Course x in courses)
            {
                var temp = new CourseViewModel();
                temp.Name = x.Name;
                temp.ID = x.ID;
                skil.Add(temp);
            }
            skil.Sort((x, y) => string.Compare(x.Name, y.Name));
            return skil;
            

        }
       

        public void AddStudentToCourse(int courseId, string userId)
        {
            ApplicationUser studentToAdd = (from student in _db.Users where student.Id == userId select student).SingleOrDefault();
            Course courseToAdd = (from course in _db.Courses where course.ID == courseId select course).SingleOrDefault();
            if (studentToAdd != null && courseToAdd != null)
            {
                if (studentToAdd.Courses.Where(x => x.ID == courseId).Count() == 0)
                {
                    studentToAdd.Courses.Add(courseToAdd);
                    _db.SaveChanges();
                }
            }
        }

        public List<Assignment> GetAssignmentByCourseID(int courseID)
        {
            var course = (from courses in _db.Courses where courses.ID == courseID select courses).SingleOrDefault();
            return course.Assignments.ToList();
        }

        public void AddAssignmentToCourse(int courseID, int assignmentID)
        {
            Assignment assignmentToAdd = (from assignment in _db.Assignments where assignment.ID == assignmentID select assignment).SingleOrDefault();
            Course courseToAdd = (from course in _db.Courses where course.ID == courseID select course).SingleOrDefault();         
            if(assignmentToAdd != null && courseToAdd != null)
            {
                if (assignmentToAdd.Courses.Where(x => x.ID == courseID).Count() == 0)
                {
                    assignmentToAdd.Courses.Add(courseToAdd);
                    _db.SaveChanges();
                }
            }
            //throw new NotImplementedException();
        }
    } 
}

    
