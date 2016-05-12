using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace WebApplication1.Models.ViewModels
{
    public class AssignmentViewModel
    {
        public string Title { get; set; }
        public int ID { get; set; }
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        [Display(Name = "Start Date")]
        public string StartDate { get; set; }
        [RegularExpression("([01]?[0-9]|2[0-3]):[0-5][0-9]", ErrorMessage = "The time has to be in 24 hour format, f.e. 13:37")]
        [Required]
        [Display(Name = "Start time")]
        public string StartTime { get; set; }

        [Display(Name = "Due Date")]
        public string EndDate { get; set; }

        [RegularExpression("([01]?[0-9]|2[0-3]):[0-5][0-9]", ErrorMessage = "The time has to be in 24 hour format, f.e. 13:37")]
        [Required]
        [Display(Name = "Due time")]
        public string EndTime { get; set; }


        public List<AssignmentMilestoneViewModel> Milestones { get; set; }
    }
}