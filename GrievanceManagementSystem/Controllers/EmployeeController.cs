using System;
using System.Collections.Generic;
using System.Web.Mvc;
using GMS.BusinessLogicLayer;
using GMS.Model;
using GMS.Model.Constant;
using GrievanceManagementSystem.ViewModels;
using GrievanceManagementSystem.Helper;
using System.Linq;

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

        public ActionResult GrievanceList(Int16 departmentId = 0)
        {
            if (IsEmaployeeAuthenticatedUser())
            {
                GrievanceDetailsListViewModel viewModel = new GrievanceDetailsListViewModel();
                UserModel userModel = Session[Constant.UserSessionData] as UserModel;
                viewModel.GrievanceDetailsList = grievanceDetailsDataBusinessLogic.GetGrievanceListForEmployee(departmentId);

                //Bind departments
                viewModel.DepartmentList = BindDepartments();

                return View(viewModel);
            }
            return RedirectToAction("Login", "Home");
        }

        [HttpGet]
        public ActionResult GetGrievanceDetail(int grievanceId)
        {
            if (IsEmaployeeAuthenticatedUser())
            {
                GrievanceDetailsViewModel grievanceDetailsViewModel = new GrievanceDetailsViewModel();
                //BindData(grievanceDetailsViewModel);
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
                //BindData(grievanceDetailsViewModel);
                return View(grievanceDetailsViewModel);
            }
            return RedirectToAction("Login", "Home");
        }

        //private GrievanceDetailsViewModel BindData(GrievanceDetailsViewModel grievanceDetailsViewModel)
        //{
        //    UserModel userModel = Session[Constant.UserSessionData] as UserModel;
        //    grievanceDetailsViewModel.UserId = userModel.UserId;
        //    grievanceDetailsViewModel.FullName = userModel.FirstName + " " + userModel.LastName;
        //    grievanceDetailsViewModel.EmailAddress = userModel.EmailAddress;
        //    grievanceDetailsViewModel.EnrollmentNumber = userModel.EnrollmentNumber;
        //    grievanceDetailsViewModel.ContactNumber = userModel.ContactNumber;

        //    grievanceDetailsViewModel.DepartmentList = BindDepartments();
        //    grievanceDetailsViewModel.StatusId = grievanceMasterDataBusinessLogic.GetGrievanceStatusList().FirstOrDefault(x => x.StatusCode == "S").StatusId;
        //    grievanceDetailsViewModel.PriorityList = BindPriority();
        //    grievanceDetailsViewModel.GrievanceTypeList = BindGrievanceType();
        //    grievanceDetailsViewModel.GrievanceSendToList = BindGrievanceSendToList();
        //    return grievanceDetailsViewModel;
        //}

        //private List<SelectListItem> BindGrievanceSendToList()
        //{
        //    //Bind Grievance Send To List
        //    List<SelectListItem> grievanceSendToListList = new List<SelectListItem>();
        //    grievanceSendToListList.Add(new SelectListItem()
        //    {
        //        Text = "--Select--",
        //        Value = ""
        //    });
        //    foreach (var item in grievanceMasterDataBusinessLogic?.GetGrievanceSendToList())
        //    {
        //        grievanceSendToListList.Add(new SelectListItem()
        //        {
        //            Text = item.GrievanceSendToName,
        //            Value = Convert.ToString(item.GrievanceSendToId)
        //        });
        //    }

        //    return grievanceSendToListList;
        //}

        //private List<SelectListItem> BindGrievanceType()
        //{
        //    //Bind Grievance Type
        //    List<SelectListItem> grievanceTypeList = new List<SelectListItem>();
        //    grievanceTypeList.Add(new SelectListItem()
        //    {
        //        Text = "--Select--",
        //        Value = ""
        //    });
        //    foreach (var item in grievanceMasterDataBusinessLogic?.GetGrievanceTypeList())
        //    {
        //        grievanceTypeList.Add(new SelectListItem()
        //        {
        //            Text = item.GrievanceTypeName,
        //            Value = Convert.ToString(item.GrievanceTypeId)
        //        });
        //    }

        //    return grievanceTypeList;
        //}

        //private List<SelectListItem> BindPriority()
        //{
        //    //Bind priority
        //    List<SelectListItem> priorityList = new List<SelectListItem>();
        //    priorityList.Add(new SelectListItem()
        //    {
        //        Text = "--Select--",
        //        Value = ""
        //    });
        //    foreach (var item in grievanceMasterDataBusinessLogic?.GetGrievancePriorityList())
        //    {
        //        priorityList.Add(new SelectListItem()
        //        {
        //            Text = item.PriorityName,
        //            Value = Convert.ToString(item.PriorityId)
        //        });
        //    }

        //    return priorityList;
        //}

        //Bind Departments
        private List<SelectListItem> BindDepartments()
        {
            List<SelectListItem> departmentList = new List<SelectListItem>();
            departmentList.Add(new SelectListItem()
            {
                Text = "--Select--",
                Value = ""
            });

            foreach (var item in grievanceMasterDataBusinessLogic?.GetGrievanceDepartmentList())
            {
                departmentList.Add(new SelectListItem()
                {
                    Text = item.DepartmentName,
                    Value = Convert.ToString(item.DepartmentId)
                });
            }

            return departmentList;
        }
    }
}