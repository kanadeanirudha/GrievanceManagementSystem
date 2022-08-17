using GMS.Model;

using System.Collections.Generic;
using System.Web.Mvc;

namespace GrievanceManagementSystem.ViewModels
{
    public class GrievanceDetailsListViewModel : BaseModel
    {
        public List<GrievanceDetailsModel> GrievanceDetailsList { get; set; }
        public int DepartmentId { get; set; }
        public List<SelectListItem> DepartmentList { get; set; }
    }
}