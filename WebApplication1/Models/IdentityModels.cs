using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WebApplication1.Models.Entities;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string SSN { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Course> Courses { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        /// <summary>
        /// Eftir thvi sem vid setjum inn fleiri entity klasa the thrufa their allir ad koma her
        /// fyrir nedan.
        /// </summary>
        public DbSet<Assignment>          Assignments { get; set; }
        public DbSet<AssignmentMilestone> Milestones { get; set; }
        public DbSet<Course>              Courses { get; set; }
        public DbSet<Submission>          Submissions { get; set; }
        public DbSet<AssignmentSolution>  Solutions { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection"/*, throwIfV1Schema: false*/)
        {
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //public System.Data.Entity.DbSet<WebApplication1.Models.ViewModels.AssignmentViewModel> AssignmentViewModels { get; set; }

        //public System.Data.Entity.DbSet<WebApplication1.Models.ViewModels.CourseViewModel> CourseViewModels { get; set; }

        //public System.Data.Entity.DbSet<WebApplication1.Models.ViewModels.AssignmentMilestoneViewModel> AssignmentMilestoneViewModels { get; set; }

    }
}