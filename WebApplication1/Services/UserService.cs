using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using WebApplication1.Models.Entities;
using WebApplication1.Utils;

namespace WebApplication1.Services
{
    public class UserService
    {
        private ApplicationDbContext _db;

        public UserService()
        {
            _db = new ApplicationDbContext();
        }

        /*public List<ApplicationUser> GetAllUsers()
        {
            return _db.Users.ToList();
        }*/


        public string GetUserIDByName(string name)
        {
            var x = (from a in _db.Users where (a.Name == name) select a.Id.ToString()).ToString();
            return x;
        }

        public List<ApplicationUser> GetAllUsers()
        {
            List<ApplicationUser> skil = new List<ApplicationUser>();
            var users = _db.Users.ToList();
            foreach (ApplicationUser x in users)
            {
                var temp = new ApplicationUser();
                temp.Name = x.Name;
                temp.SSN = x.SSN;
                temp.UserName = x.UserName;
                temp.Id = x.Id;
                skil.Add(temp);
            }
            skil.Sort((x, y) => string.Compare(x.Name, y.Name));
            return skil;
        }
    }
}