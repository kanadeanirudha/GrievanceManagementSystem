using GMS.BusinessLogicLayer;
using GMS.Model;

using GrievanceManagementSystem.Helper;
using GrievanceManagementSystem.ViewModels;

using System.Web.Mvc;
using System.Web.Security;
using GMS.Model.Constant;

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
                    RegistrationModel model = new GrievanceUserDetailsBusinessLogic().Login(registrationViewModel.EmailAddress, registrationViewModel.Password);
                    if (!model.HasError)
                    {
                        FormsAuthentication.SetAuthCookie(model.EmailAddress, false);
                        Session[Constant.UserSessionData] = model;
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
                RegistrationModel model = new RegistrationModel()
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