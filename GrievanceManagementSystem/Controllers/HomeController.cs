using GMS.BusinessLogicLayer;
using GMS.Model;
using GrievanceManagementSystem.Helper;
using GrievanceManagementSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrievanceManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(RegistrationViewModel registrationViewModel)
        {
            if (!string.IsNullOrEmpty(registrationViewModel.EmailAddress) && !string.IsNullOrEmpty(registrationViewModel.Password))
            {
                RegistrationModel model = registrationViewModel.ToModel<RegistrationModel>();
                bool status = new GrievanceUserDetailsBusinessLogic().Login(model);
            }
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

        public ActionResult Dashboard()
        {
            return View();
        }
    }
}