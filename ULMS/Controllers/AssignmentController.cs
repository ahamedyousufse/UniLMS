using System.Linq;
using System.Web.Mvc;
using ULMS.Models;

//[Authorize(Roles = "Lecturer")]
[Authorize]
public class AssignmentController : Controller
{
    private ApplicationDbContext db = new ApplicationDbContext();

    public ActionResult Index()
    {
        return View(db.Assignments.ToList());
    }

    public ActionResult Create()
    {
        ViewBag.Courses = db.Courses.ToList();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Assignment assignment)
    {
        if (ModelState.IsValid)
        {
            db.Assignments.Add(assignment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        ViewBag.Courses = db.Courses.ToList();
        return View(assignment);
    }
}