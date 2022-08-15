using System.Web.Mvc;

namespace GrievanceManagementSystem.Controllers
{
    public class DashboardController : BaseController
    {
        public ActionResult Dashboard()
        {
            if (IsEmaployeeAuthenticatedUser())
            {
                return View();
            }
            return RedirectToAction("Login", "Home");
        }
    }
}