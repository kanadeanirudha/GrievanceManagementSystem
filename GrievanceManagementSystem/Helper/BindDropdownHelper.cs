using GMS.BusinessLogicLayer;

using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace GrievanceManagementSystem.Helper
{
    public static class BindDropdownHelper
    {
        //Bind Priority
        static public List<SelectListItem> BindPriority(short priorityId = 0)
        {
            //Bind priority
            List<SelectListItem> priorityList = new List<SelectListItem>();
            if (priorityId == 0)
            {
                priorityList.Add(new SelectListItem()
                {
                    Text = "--Select--",
                    Value = ""
                });
            }
            foreach (var item in new GrievanceMasterDataBusinessLogic()?.GetGrievancePriorityList())
            {
                priorityList.Add(new SelectListItem()
                {
                    Text = item.PriorityName,
                    Value = Convert.ToString(item.PriorityId),
                    Selected = priorityId == 0 ? false : item.PriorityId == priorityId ? true : false
                });
            }
            return priorityList;
        }

        //Bind Departments
        static public List<SelectListItem> BindDepartments()
        {
            List<SelectListItem> departmentList = new List<SelectListItem>();
            departmentList.Add(new SelectListItem()
            {
                Text = "--Select--",
                Value = ""
            });

            foreach (var item in new GrievanceMasterDataBusinessLogic()?.GetGrievanceDepartmentList())
            {
                departmentList.Add(new SelectListItem()
                {
                    Text = item.DepartmentName,
                    Value = Convert.ToString(item.DepartmentId)
                });
            }

            return departmentList;
        }

        //Bind Status
        static public List<SelectListItem> BindStatus(short statusId = 0)
        {
            //Bind Grievance Type
            List<SelectListItem> statusList = new List<SelectListItem>();
            if (statusId == 0)
            {
                statusList.Add(new SelectListItem()
                {
                    Text = "--Select--",
                    Value = ""
                });
            }

            foreach (var item in new GrievanceMasterDataBusinessLogic()?.GetGrievanceStatusList())
            {
                statusList.Add(new SelectListItem()
                {
                    Text = item.StatusName,
                    Value = Convert.ToString(item.StatusId),
                    Selected = statusId == 0 ? false : item.StatusId == statusId ? true : false
                });
            }

            return statusList;
        }

        //Bind Grievance Send To List
        static public List<SelectListItem> BindGrievanceSendToList()
        {
            List<SelectListItem> grievanceSendToListList = new List<SelectListItem>();
            grievanceSendToListList.Add(new SelectListItem()
            {
                Text = "--Select--",
                Value = ""
            });
            foreach (var item in new GrievanceMasterDataBusinessLogic()?.GetGrievanceSendToList())
            {
                grievanceSendToListList.Add(new SelectListItem()
                {
                    Text = item.GrievanceSendToName,
                    Value = Convert.ToString(item.GrievanceSendToId)
                });
            }

            return grievanceSendToListList;
        }

        //Bind Grievance Type
        static public List<SelectListItem> BindGrievanceType()
        {
            List<SelectListItem> grievanceTypeList = new List<SelectListItem>();
            grievanceTypeList.Add(new SelectListItem()
            {
                Text = "--Select--",
                Value = ""
            });
            foreach (var item in new GrievanceMasterDataBusinessLogic()?.GetGrievanceTypeList())
            {
                grievanceTypeList.Add(new SelectListItem()
                {
                    Text = item.GrievanceTypeName,
                    Value = Convert.ToString(item.GrievanceTypeId)
                });
            }
            return grievanceTypeList;
        }
    }
}