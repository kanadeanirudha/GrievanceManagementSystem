using GMS.Model;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace GrievanceManagementSystem.ViewModels
{
    public class GrievanceDetailsViewModel : BaseViewModel
    {
        public int GrievanceId { get; set; }
        public string GrievanceNumber { get; set; }
        public string FullName { get; set; }
        public string EnrollmentNumber { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public int UserId { get; set; }
        [Required]
        public Int16 StatusId { get; set; }
        [Required]
        public Int16 GrievanceTypeId { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public Int16 PriorityId { get; set; }
        [Required]
        public Int16 DepartmentId { get; set; }
        [Required]
        public Int16 GrievanceSendToId { get; set; }
        public string AddCc { get; set; }
        [Required]
        public string Details { get; set; }
        public List<SelectListItem> DepartmentList { get; set; }
        public List<SelectListItem> PriorityList { get; set; }
        public List<SelectListItem> StatusList { get; set; }
        public List<SelectListItem> GrievanceTypeList { get; set; }
        public List<SelectListItem> GrievanceSendToList { get; set; }
    }
}