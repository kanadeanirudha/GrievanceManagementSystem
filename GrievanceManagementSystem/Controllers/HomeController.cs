using GMS.BusinessLogicLayer;
using GMS.Model;
using GMS.Model.Constant;

using GrievanceManagementSystem.ViewModels;

using System.Web.Mvc;
using System.Web.Security;

namespace GrievanceManagementSystem.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLoginViewModel registrationViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(registrationViewModel.EmailAddress) && !string.IsNullOrEmpty(registrationViewModel.Password))
                {
                    UserModel model = new GrievanceUserDetailsBusinessLogic().Login(registrationViewModel.EmailAddress, registrationViewModel.Password);
                    if (!model.HasError)
                    {
                        FormsAuthentication.SetAuthCookie(model.EmailAddress, false);
                        Session[Constant.UserSessionData] = model;
                        if (model?.EntityType == "S")
                        {
                            return RedirectToAction("Dashboard", "Student");
                        }
                        return RedirectToAction("Dashboard", "Dashboard");
                    }
                }
            }
            ModelState.AddModelError("", "invalid Username or Password");
            return View();
        }

        [HttpGet]
        public ActionResult Registor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registor(RegistrationViewModel registrationViewModel)
        {
            if (ModelState.IsValid)
            {
                UserModel model = new UserModel()
                {
                    FirstName = registrationViewModel.FirstName,
                    LastName = registrationViewModel.LastName,
                    EmailAddress = registrationViewModel.EmailAddress
                };

                bool status = new GrievanceUserDetailsBusinessLogic().UserRegistration(model);
            }
            return View(registrationViewModel);
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        public ActionResult LogOff()
        {
            Session.Clear();
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }
    }
}