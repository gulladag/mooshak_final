﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Entities;
using WebApplication1.Models.ViewModels;
using WebApplication1.Services;


namespace WebApplication1.Controllers
{
    public class AssignmentsController : Controller
    {
        private AssignmentsService _service = new AssignmentsService();
        // GET: Assignments
        [Authorize(Roles = "Administrators, Teachers")]
        public ActionResult AddAssignment()
        {
            AssignmentViewModel model = new AssignmentViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrators, Teachers")]
        public ActionResult AddAssignment(AssignmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                char delimiter = '-';
                string[] StartDateSplit = model.StartDate.Split(delimiter);
                string[] EndDateSplit = model.EndDate.Split(delimiter);

                DateTime Start = Convert.ToDateTime(StartDateSplit[0] + "/" + StartDateSplit[1] + "/" + StartDateSplit[2] + " " + model.StartTime + ":00.00");
                DateTime End = Convert.ToDateTime(EndDateSplit[0] + "/" + EndDateSplit[1] + "/" + EndDateSplit[2] + " " + model.EndTime + ":00.00");

                Assignment newAssignment = new Assignment();
                newAssignment.Title = model.Title;
                newAssignment.Descriptin = model.Description;
                newAssignment.Start = Start;
                newAssignment.End = End;
                AssignmentsService Assdb = new AssignmentsService();
                Assdb.AddAssignmentToDB(newAssignment);

                return RedirectToAction("AddAssignment");
            }

            
            return View(model);
        }
        [HttpGet]
        [Route("Assignments/ViewAssignmentDetails/{id}")]
        public ActionResult ViewAssignmentDetails(int id)
        {
            var viewModel = _service.GetAssignmentByID(id);
            return View(viewModel);
        }

        [HttpGet]
        [Route("Assignments/EditAssignment/{assignmentID}")]
        public ActionResult EditAssignment(int? assignmentID)
        {
            AssignmentsService b = new AssignmentsService();
            AssignmentViewModel model = b.GetAssignmentByID(assignmentID.Value);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Assignments/EditAssignment/{assignmentID}")]
        public ActionResult EditAssignment(AssignmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                AssignmentsService assignmentdb = new AssignmentsService();
                assignmentdb.EditAssignmentInDB(model);

                return RedirectToAction("ViewCourseDetails", "Courses", new { id = model.CourseID });
            }
            return View(model);
        }

        [HttpGet]
        [Route("Assignments/CreateMilestone/{id}")]
        [Authorize(Roles = "Administrators, Teachers")]
        public ActionResult CreateMilestone (int id)
        {
            AssignmentMilestoneViewModel newMilestone = new AssignmentMilestoneViewModel();
            newMilestone.AssignmentID = id;

            return View(newMilestone);
        }

        [HttpPost]
        [Authorize(Roles = "Administrators, Teachers")]
        [ValidateAntiForgeryToken]
        //[Route("Assignments/ViewAssignmentDetails/{id}")]
        public ActionResult CreateMilestone(AssignmentMilestoneViewModel model)
        {
            if (ModelState.IsValid)
            {
                // _service.CreateAssignmentMilestone(model);
                
                AssignmentMilestone newMilestone = new AssignmentMilestone();
                newMilestone.Title = model.Title;
                newMilestone.Description = model.Description;
                newMilestone.AssignmentID = model.AssignmentID;
                newMilestone.weight = model.weight;
                newMilestone.Input = model.Input;
                newMilestone.Output = model.Output;
                AssignmentsService miledb = new AssignmentsService();
                miledb.AddMilestoneToDB(newMilestone);

            //return RedirectToAction("ViewAssignmentDetails", "Assignments");
                return RedirectToAction("ViewAssignmentDetails", "Assignments", new { id = model.AssignmentID });
            }
            return View(model);
        }



        [HttpGet]
        [Route("Assignments/DeleteAssignment/{assignmentID}")]
        public ActionResult DeleteAssignment(int? assignmentID)
        {
            AssignmentsService b = new AssignmentsService();
            AssignmentViewModel model = b.GetAssignmentByID(assignmentID.Value);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAssignment(AssignmentViewModel model)
        {
            if (model.ID != null)
            {
                AssignmentsService assignmentdb = new AssignmentsService();
                assignmentdb.DeleteAssignment(model);

                return RedirectToAction("ViewCourses", "Courses");
            }
            return View(model);
        }
    }
}

