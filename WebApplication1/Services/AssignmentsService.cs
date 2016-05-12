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
    public class AssignmentsService
    {
        private ApplicationDbContext _db;
        public AssignmentsService()
        {
            _db = new ApplicationDbContext();
        }
        public void AddAssignmentToDB(Assignment newAssignment)
        {
            _db.Assignments.Add(newAssignment);
            _db.SaveChanges();
        }

        public void EditAssignmentInDB(AssignmentViewModel model)
        {
            var assignment = _db.Assignments.SingleOrDefault(x => x.ID == model.ID);
            assignment.Title = model.Title;
            _db.Entry(assignment).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void AddAssignmentToCourse(AssignmentViewModel model)
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
            _db.Assignments.Add(newAssignment);
            _db.SaveChanges();

        }



        /* public void AddStudentToCourse(int courseId, string userId)
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
         }*/
        public List<Assignment> GetAssignmentsByCourseID(int courseID)
        {
            var course = (from courses in _db.Courses where courses.ID == courseID select courses).SingleOrDefault();
            return course.Assignments.ToList();
        }

        public AssignmentViewModel GetAssignmentByID(int assignmentID)
        {
            var assignment = _db.Assignments.SingleOrDefault(x => x.ID == assignmentID);
            if (assignment == null)
            {
                //TODO: kasta villu!
            }

            var milestones = _db.Milestones
                .Where(x => x.AssignmentID == assignmentID)
                .Select(x => new AssignmentMilestoneViewModel
                {
                    Title = x.Title
                })
                .ToList();

            var viewModel = new AssignmentViewModel
            {
                Title = assignment.Title,
                Milestones = milestones
            };

            return null;
        }
        public List<Assignment> GetAllAssignments()
        {
            return _db.Assignments.ToList();
        }

        public bool CreateAssignmentMilestone(AssignmentMilestoneViewModel model)
        {
            AssignmentMilestone newMilestone = new AssignmentMilestone()
            {
                AssignmentID = model.AssignmentID,
                Title = model.Title,
                Description = model.Description,
                weight = model.weight,
                Input = model.Input,
                Output = model.Output
            };

            _db.Milestones.Add(newMilestone);
            _db.SaveChanges();

            return true;
        }
    }
}