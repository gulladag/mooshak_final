using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using WebApplication1.Models.Entities;

namespace WebApplication1.Models.ViewModels
{
   public class CourseViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }
        public List<ApplicationUser> Students { get; set; }
        public List<Assignment> Assignments { get; set; }
    }
}
