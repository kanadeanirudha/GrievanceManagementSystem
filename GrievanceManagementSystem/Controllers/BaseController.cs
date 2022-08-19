
using GMS.Model;
using GMS.Model.Constant;
using System.Web.Mvc;

namespace GrievanceManagementSystem.Controllers
{
    public class BaseController : Controller
    {
        protected bool IsEmaployeeAuthenticatedUser()
        {
            return User.Identity.IsAuthenticated && ((Session[Constant.UserSessionData] as UserModel)?.EntityType == Constant.EmployeeEntityType || (Session[Constant.UserSessionData] as UserModel)?.EntityType == "SA");
        }

        protected bool IsStudentAuthenticatedUser()
        {
            return User.Identity.IsAuthenticated && (Session[Constant.UserSessionData] as UserModel)?.EntityType == Constant.StudentEntityType;
        }


    }
}