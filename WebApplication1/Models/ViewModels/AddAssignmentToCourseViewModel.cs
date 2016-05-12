using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models.ViewModels
{
    public class AddAssignmentToCourseViewModel
    {
        public int AssignmentID { get; set; }
        public int CourseID { get; set; }
        public List<SelectListItem> AvailableAssignments { get; set; }
    }
}



/*[Display(Name = "Select student")]
public string UserID { get; set; }

public int CourseID { get; set; }

public List<SelectListItem> AvailableStudents { get; set; }*/