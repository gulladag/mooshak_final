using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Utils;
using Microsoft.AspNet.Identity;
namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            InitializeUsersAndRoles();

            if (Request.IsAuthenticated)
            {
                return RedirectToAction("ViewCourses", "Courses");
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }
            
            //return View();
        }

        private static void InitializeUsersAndRoles()
        {
            if (!IdentityManager.RoleExists("Administrators"))
            {
                IdentityManager.CreateRole("Administrators");
            }
            if (!IdentityManager.RoleExists("Students"))
            {
                IdentityManager.CreateRole("Students");
            }
            if (!IdentityManager.RoleExists("Teachers"))
            {
                IdentityManager.CreateRole("Teachers");
            }
            if (!IdentityManager.UserExists("admin"))
            {
                ApplicationUser newAdmin = new ApplicationUser();
                newAdmin.UserName = "admin";
                IdentityManager.CreateUser(newAdmin, "123456");
                IdentityManager.AddUserToRole(newAdmin.Id, "Administrators");
            }

            if (!IdentityManager.UserExists("teacher"))
            {
                ApplicationUser newTeacher = new ApplicationUser();
                newTeacher.UserName = "teacher";
                IdentityManager.CreateUser(newTeacher, "123456");
                IdentityManager.AddUserToRole(newTeacher.Id, "Teachers");
            }

            if (!IdentityManager.UserExists("student"))
            {
                ApplicationUser newStudent = new ApplicationUser();
                newStudent.UserName = "student";
                IdentityManager.CreateUser(newStudent, "123456");
                IdentityManager.AddUserToRole(newStudent.Id, "Students");
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}