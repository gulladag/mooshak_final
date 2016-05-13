using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.ViewModels
{
    public class SubmissionViewModel
    {
        public int ID { get; set; }
        public string StudentID { get; set; }
        public int AssignmentID { get; set; }
        public int AssignmentMilestoneID { get; set; }
        public List<string> SubmittedCode { get; set; }
        public bool IsCorrect { get; set; } 
    }
}