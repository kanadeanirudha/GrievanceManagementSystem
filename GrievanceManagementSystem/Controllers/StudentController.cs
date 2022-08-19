using GMS.BusinessLogicLayer;
using GMS.Model;
using GMS.Model.Constant;

using GrievanceManagementSystem.Helper;
using GrievanceManagementSystem.ViewModels;

using System;
using System.Linq;
using System.Web.Mvc;

namespace GrievanceManagementSystem.Controllers
{
    public class StudentController : BaseController
    {
        GrievanceMasterDataBusinessLogic grievanceMasterDataBusinessLogic = null;
        GrievanceDetailsDataBusinessLogic grievanceDetailsDataBusinessLogic = null;
        public StudentController()
        {
            grievanceMasterDataBusinessLogic = new GrievanceMasterDataBusinessLogic();
            grievanceDetailsDataBusinessLogic = new GrievanceDetailsDataBusinessLogic();
        }
        public ActionResult Dashboard()
        {
            if (IsStudentAuthenticatedUser())
            {
                return View();
            }
            return RedirectToAction("Login", "Home");
        }

        public ActionResult GrievanceList(Int16 departmentId = 0)
        {
            if (IsStudentAuthenticatedUser())
            {
                GrievanceDetailsListViewModel viewModel = new GrievanceDetailsListViewModel();
                UserModel userModel = Session[Constant.UserSessionData] as UserModel;
                viewModel.GrievanceDetailsList = grievanceDetailsDataBusinessLogic.GetGrievanceList(userModel.UserId, departmentId);

                //Bind departments
                viewModel.DepartmentList = BindDropdownHelper.BindDepartments();

                return View(viewModel);
            }
            return RedirectToAction("Login", "Home");
        }

        [HttpGet]
        public ActionResult CreateGrievance()
        {
            if (IsStudentAuthenticatedUser())
            {
                GrievanceDetailsViewModel grievanceDetailsViewModel = new GrievanceDetailsViewModel();
                BindData(grievanceDetailsViewModel);
                return View(grievanceDetailsViewModel);
            }
            return RedirectToAction("Login", "Home");
        }

        [HttpPost]
        public ActionResult CreateGrievance(GrievanceDetailsViewModel grievanceDetailsViewModel)
        {
            if (IsStudentAuthenticatedUser())
            {
                if (ModelState.IsValid)
                {
                    bool status = grievanceDetailsDataBusinessLogic.CreateGrievance(grievanceDetailsViewModel.ToModel<GrievanceDetailsModel>());
                    if (status)
                    {
                        return RedirectToAction("GrievanceList", "Student");
                    }
                }
                BindData(grievanceDetailsViewModel);
                return View(grievanceDetailsViewModel);
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

        #region Private
        private GrievanceDetailsViewModel BindData(GrievanceDetailsViewModel grievanceDetailsViewModel)
        {
            UserModel userModel = Session[Constant.UserSessionData] as UserModel;
            grievanceDetailsViewModel.UserId = userModel.UserId;
            grievanceDetailsViewModel.FullName = userModel.FirstName + " " + userModel.LastName;
            grievanceDetailsViewModel.EmailAddress = userModel.EmailAddress;
            grievanceDetailsViewModel.EnrollmentNumber = userModel.EnrollmentNumber;
            grievanceDetailsViewModel.ContactNumber = userModel.ContactNumber;

            grievanceDetailsViewModel.DepartmentList = BindDropdownHelper.BindDepartments();
            grievanceDetailsViewModel.StatusId = grievanceMasterDataBusinessLogic.GetGrievanceStatusList().FirstOrDefault(x => x.StatusCode == "S").StatusId;
            grievanceDetailsViewModel.PriorityList = BindDropdownHelper.BindPriority();
            grievanceDetailsViewModel.GrievanceTypeList = BindDropdownHelper.BindGrievanceType();
            grievanceDetailsViewModel.GrievanceSendToList = BindDropdownHelper.BindGrievanceSendToList();
            return grievanceDetailsViewModel;
        }
        #endregion
    }
}