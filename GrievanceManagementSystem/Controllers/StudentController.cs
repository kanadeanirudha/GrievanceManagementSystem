using System.Web.Mvc;

namespace GrievanceManagementSystem.Controllers
{
    public class StudentController : BaseController
    {
        public ActionResult Dashboard()
        {
            if (IsStudentAuthenticatedUser())
            {
                return View();
            }
            return RedirectToAction("Login", "Home");
        }

        public ActionResult GrievanceList()
        {
            if (IsStudentAuthenticatedUser())
            {
                return View();
            }
            return RedirectToAction("Login", "Home");
        }

        public ActionResult CreateGrievance()
        {
            if (IsStudentAuthenticatedUser())
            {
                return View();
            }
            return RedirectToAction("Login", "Home");
        }

        public ActionResult UpdateGrievance()
        {
            if (IsStudentAuthenticatedUser())
            {
                return View();
            }
            return RedirectToAction("Login", "Home");
        }
    }
}