using System.Web.Mvc;

namespace GrievanceManagementSystem.Controllers
{
    public class DashboardController : BaseController
    {
        public ActionResult Dashboard()
        {
            if (IsAuthenticatedUser())
            {
                return View();
            }
            return RedirectToAction("Login", "Home");
        }
    }
}