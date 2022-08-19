using GMS.BusinessLogicLayer;
using GMS.Model;
using GMS.Model.Constant;

using GrievanceManagementSystem.Helper;
using GrievanceManagementSystem.ViewModels;

using System;
using System.Web.Mvc;

namespace GrievanceManagementSystem.Controllers
{
    public class EmployeeController : BaseController
    {
        GrievanceMasterDataBusinessLogic grievanceMasterDataBusinessLogic = null;
        GrievanceDetailsDataBusinessLogic grievanceDetailsDataBusinessLogic = null;
        public EmployeeController()
        {
            grievanceMasterDataBusinessLogic = new GrievanceMasterDataBusinessLogic();
            grievanceDetailsDataBusinessLogic = new GrievanceDetailsDataBusinessLogic();
        }
        public ActionResult Dashboard()
        {
            if (IsEmaployeeAuthenticatedUser())
            {
                return View();
            }
            return RedirectToAction("Login", "Home");
        }

        public ActionResult GrievanceList(short departmentId = 0)
        {
            if (IsEmaployeeAuthenticatedUser())
            {
                GrievanceDetailsListViewModel viewModel = new GrievanceDetailsListViewModel();
                UserModel userModel = Session[Constant.UserSessionData] as UserModel;
                viewModel.GrievanceDetailsList = grievanceDetailsDataBusinessLogic.GetGrievanceListForEmployee(departmentId);

                //Bind departments
                viewModel.DepartmentList = BindDropdownHelper.BindDepartments();

                return View(viewModel);
            }
            return RedirectToAction("Login", "Home");
        }

        [HttpGet]
        public ActionResult UpdateGrievance(string grievanceId)
        {
            if (IsEmaployeeAuthenticatedUser())
            {
                GrievanceDetailsViewModel grievanceDetailsViewModel = BindData(Convert.ToInt64(grievanceId), 0, 0);
                return View(grievanceDetailsViewModel);
            }
            return RedirectToAction("Login", "Home");
        }

        [HttpPost]
        public ActionResult UpdateGrievance(GrievanceDetailsViewModel grievanceDetailsViewModel)
        {
            if (IsEmaployeeAuthenticatedUser())
            {
                if (!string.IsNullOrEmpty(grievanceDetailsViewModel.Details))
                {
                    bool status = grievanceDetailsDataBusinessLogic.UpdateGrievance(grievanceDetailsViewModel.ToModel<GrievanceDetailsModel>());
                    if (status)
                    {
                        return RedirectToAction("GrievanceList", "Employee");
                    }
                }
                grievanceDetailsViewModel = BindData(grievanceDetailsViewModel.GrievanceId, grievanceDetailsViewModel.StatusId, grievanceDetailsViewModel.PriorityId);
                grievanceDetailsViewModel.Details = grievanceDetailsViewModel.Details;
                return View(grievanceDetailsViewModel);
            }
            return RedirectToAction("Login", "Home");
        }

        #region Private

        private GrievanceDetailsViewModel BindData(long grievanceId, short statusId, short priorityId)
        {
            GrievanceDetailsModel grievanceDetailsModel = grievanceDetailsDataBusinessLogic.GetGrievanceDetails(Convert.ToInt64(grievanceId), 0);
            GrievanceDetailsViewModel grievanceDetailsViewModel = grievanceDetailsModel.ToViewModel<GrievanceDetailsViewModel>();
            if (grievanceDetailsViewModel != null)
            {
                UserModel userModel = Session[Constant.UserSessionData] as UserModel;
                grievanceDetailsViewModel.StatusId = statusId == 0 ? grievanceDetailsViewModel.StatusId : statusId;
                grievanceDetailsViewModel.PriorityId = priorityId == 0 ? grievanceDetailsViewModel.PriorityId : priorityId;
                grievanceDetailsViewModel.UserId = userModel.UserId;
                grievanceDetailsViewModel.StatusList = BindDropdownHelper.BindStatus(grievanceDetailsViewModel.StatusId);
                grievanceDetailsViewModel.PriorityList = BindDropdownHelper.BindPriority(grievanceDetailsViewModel.PriorityId);
            }
            return grievanceDetailsViewModel;
        }

        #endregion
    }
}