using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using WebApplication1.Models.Entities;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Services
{
    public class SubmissionService
    {
        private ApplicationDbContext _db;
        public SubmissionService()
        {
            _db = new ApplicationDbContext();
        }

        public void AddSubmissionToDB(Submission newSubmission)
        {
            _db.Submissions.Add(newSubmission);
        }

        public SubmissionViewModel GetSubmissionByID (int submissionID)
        {
            var submissions = _db.Submissions.SingleOrDefault(x => x.ID == submissionID);
            var ViewModel = new SubmissionViewModel();
            return null;

        }

    }
}