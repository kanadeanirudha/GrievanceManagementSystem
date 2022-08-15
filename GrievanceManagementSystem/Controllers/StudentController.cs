using System;
using System.Collections.Generic;
using System.Web.Mvc;
using GMS.BusinessLogicLayer;
using GMS.Model;
using GMS.Model.Constant;
using GrievanceManagementSystem.ViewModels;

namespace GrievanceManagementSystem.Controllers
{
    public class StudentController : BaseController
    {
        GrievanceMasterDataBusinessLogic grievanceMasterDataBusinessLogic = null;
        public StudentController()
        {
            grievanceMasterDataBusinessLogic = new GrievanceMasterDataBusinessLogic();
        }
        public ActionResult Dashboard()
        {
            if (IsStudentAuthenticatedUser())
            {
                return View();
            }
            return RedirectToAction("Login", "Home");
        }

        public ActionResult GrievanceList()
        {
            if (IsStudentAuthenticatedUser())
            {
                return View();
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


        private GrievanceDetailsViewModel BindData(GrievanceDetailsViewModel grievanceDetailsViewModel)
        {
            UserModel userModel = Session[Constant.UserSessionData] as UserModel;
            grievanceDetailsViewModel.FullName = userModel.FirstName + " " + userModel.LastName;
            grievanceDetailsViewModel.EmailAddress = userModel.EmailAddress;
            grievanceDetailsViewModel.EnrollmentNumber = userModel.EnrollmentNumber;
            grievanceDetailsViewModel.ContactNumber = userModel.ContactNumber;

            //Bind departments
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

            //Bind Status
            List<SelectListItem> statusList = new List<SelectListItem>();
            //statusList.Add(new SelectListItem()
            //{
            //    Text = "--Select--",
            //    Value = ""
            //});
            foreach (var item in grievanceMasterDataBusinessLogic?.GetGrievanceStatusList())
            {
                statusList.Add(new SelectListItem()
                {
                    Text = item.StatusName,
                    Value = Convert.ToString(item.StatusId),
                    Selected = item.StatusCode == "O" ? true : false
                });
            }

            //Bind Status
            List<SelectListItem> priorityList = new List<SelectListItem>();
            priorityList.Add(new SelectListItem()
            {
                Text = "--Select--",
                Value = ""
            });
            foreach (var item in grievanceMasterDataBusinessLogic?.GetGrievancePriorityList())
            {
                priorityList.Add(new SelectListItem()
                {
                    Text = item.PriorityName,
                    Value = Convert.ToString(item.PriorityId)
                });
            }

            //Bind Grievance Type
            List<SelectListItem> grievanceTypeList = new List<SelectListItem>();
            grievanceTypeList.Add(new SelectListItem()
            {
                Text = "--Select--",
                Value = ""
            });
            foreach (var item in grievanceMasterDataBusinessLogic?.GetGrievanceTypeList())
            {
                grievanceTypeList.Add(new SelectListItem()
                {
                    Text = item.GrievanceTypeName,
                    Value = Convert.ToString(item.GrievanceTypeId)
                });
            }

            //Bind Grievance Send To List
            List<SelectListItem> grievanceSendToListList = new List<SelectListItem>();
            grievanceSendToListList.Add(new SelectListItem()
            {
                Text = "--Select--",
                Value = ""
            });
            foreach (var item in grievanceMasterDataBusinessLogic?.GetGrievanceSendToList())
            {
                grievanceSendToListList.Add(new SelectListItem()
                {
                    Text = item.GrievanceSendToName,
                    Value = Convert.ToString(item.GrievanceSendToId)
                });
            }

            grievanceDetailsViewModel.DepartmentList = departmentList;
            grievanceDetailsViewModel.StatusList = statusList;
            grievanceDetailsViewModel.PriorityList = priorityList;
            grievanceDetailsViewModel.GrievanceTypeList = grievanceTypeList;
            grievanceDetailsViewModel.GrievanceSendToList = grievanceSendToListList;
            return grievanceDetailsViewModel;
        }




    }
}