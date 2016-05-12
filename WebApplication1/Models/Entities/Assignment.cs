using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Entities
{
    public class Assignment
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Descriptin { get; set; }
        public DateTime  Start { get; set; }
        public DateTime End { get; set; }
        public virtual ICollection<Course> Courses { get; set; }



    }
}