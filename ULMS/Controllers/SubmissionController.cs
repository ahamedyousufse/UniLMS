using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ULMS.Models;

namespace ULMS.Controllers
{
    public class SubmissionController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var submissions = db.Submissions.ToList();
            return View(submissions);
        }

        public ActionResult Grade(int id)
        {
            var submission = db.Submissions.Find(id);
            return View(submission);
        }

        [HttpPost]
        public ActionResult Grade(int id, int grade, string feedback)
        {
            var submission = db.Submissions.Find(id);

            submission.Grade = grade;
            submission.Feedback = feedback;

            db.SaveChanges();

            TempData["Message"] = "Graded successfully!";
            return RedirectToAction("Index");
        }

        // GET: Submission
        public ActionResult Submit(int id)
        {
            ViewBag.AssignmentId = id;
            return View();
        }

        [HttpPost]
        public ActionResult Submit(int id, HttpPostedFileBase file)
        {
            string userId = User.Identity.GetUserId();

            string fileName = System.IO.Path.GetFileName(file.FileName);
            string path = System.IO.Path.Combine(Server.MapPath("~/Uploads"), fileName);
            file.SaveAs(path);

            var submission = new Submission
            {
                AssignmentId = id,
                StudentId = userId,
                FilePath = "/Uploads/" + fileName,
                Grade = 0,
                Feedback = ""
            };

            db.Submissions.Add(submission);
            db.SaveChanges();

            TempData["Message"] = "Assignment submitted successfully!";
            return RedirectToAction("Index", "Assignment");
        }
    }
}