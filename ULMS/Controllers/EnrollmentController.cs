using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ULMS.Models;

[Authorize]
public class EnrollmentController : Controller
{
    private ApplicationDbContext db = new ApplicationDbContext();

    public ActionResult Enroll(int id)
    {
        string userId = User.Identity.GetUserId();

        if (userId == null)
        {
            return Content("User not logged in");
        }

        var exists = db.Enrollments
            .FirstOrDefault(e => e.CourseId == id && e.StudentId == userId);

        if (exists == null)
        {
            var enrollment = new Enrollment
            {
                CourseId = id,
                StudentId = userId
            };

            db.Enrollments.Add(enrollment);
            db.SaveChanges();
        }

        TempData["Message"] = "Enrollment successful!";
        return RedirectToAction("Index", "Course");
    }
}