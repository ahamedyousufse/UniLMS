using System.Linq;
using System.Web.Mvc;
using ULMS.Models;

public class CourseController : Controller
{
    private ApplicationDbContext db = new ApplicationDbContext();

    public ActionResult Index()
    {
        return View(db.Courses.ToList());
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Course course)
    {
        if (ModelState.IsValid)
        {
            db.Courses.Add(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(course);
    }
}