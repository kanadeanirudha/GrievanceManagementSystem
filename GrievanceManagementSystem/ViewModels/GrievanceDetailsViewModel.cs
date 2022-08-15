using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrievanceManagementSystem.ViewModels
{
    public class GrievanceDetailsViewModel :BaseViewModel
    {
        public int GrievanceId { get; set; }
        public string GrievanceNumber { get; set; }
        public int UserId { get; set; }
        public Int16 StatusId { get; set; }
        public Int16 GrievanceTypeId { get; set; }
        public string Subject { get; set; }
        public Int16 PriorityId { get; set; }
        public Int16 DepartmentId { get; set; }
        public string AddCc { get; set; }
        public string Details { get; set; }
    }
}