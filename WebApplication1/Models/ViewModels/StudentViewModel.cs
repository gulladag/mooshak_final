using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models.Entities;

namespace WebApplication1.Models.ViewModels
{
    public class StudentViewModel
    {
        public class Student
        {
            public int ID { get; set; }
            public string SSN { get; set; }
            public string Name { get; set; }
           
        }
    }
}