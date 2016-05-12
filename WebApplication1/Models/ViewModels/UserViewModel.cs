using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.ViewModels
{
    public class UserViewModel
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }
        /*public string SSN { get; set; }*/
        
    }

}