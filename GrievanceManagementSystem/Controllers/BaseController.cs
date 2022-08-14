
using System.Web.Mvc;

namespace GrievanceManagementSystem.Controllers
{
    public class BaseController : Controller
    {
        protected bool IsAuthenticatedUser()
        {
            return User.Identity.IsAuthenticated;
        }
    }
}