using StarCollege.DAL;
using System.Web.Mvc;
using StarCollege.ViewModels;
using System.Linq;

namespace StarCollege.Controllers
{
    public class HomeController : Controller
    {
        private SchoolContext db = new SchoolContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            System.Linq.IQueryable<EnrollmentDateGroup> data = from student in db.Students
                                                               group student by student.EnrollmentDate into dateGroup
                                                               select new EnrollmentDateGroup()
                                                               {
                                                                   EnrollmentDate = dateGroup.Key,
                                                                   StudentCount = dateGroup.Count()
                                                               };
            return View(data.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}