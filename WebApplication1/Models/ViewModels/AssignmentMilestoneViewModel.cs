using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.ViewModels
{
    public class AssignmentMilestoneViewModel
    {
        public int ID { get; set; }
        public int AssignmentID { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Weight")]
        public int weight { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Input")]
        public string Input { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Output")]
        public string Output { get; set; }
    }
}