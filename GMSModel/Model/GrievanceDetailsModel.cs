using GMS.Model;

using System;
using System.Collections.Generic;

namespace GMS.Model
{
    public class GrievanceDetailsModel : BaseModel
    {
        public long GrievanceId { get; set; }
        public string GrievanceNumber { get; set; }
        public string FullName { get; set; }
        public string EnrollmentNumber { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public int UserId { get; set; }
        public short StatusId { get; set; }
        public short GrievanceTypeId { get; set; }
        public string GrievanceTypeName { get; set; }
        public string Subject { get; set; }
        public short PriorityId { get; set; }
        public string PriorityName { get; set; }
        public short DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string GrievanceSendToName { get; set; }
        public string StatusName { get; set; }
        public short GrievanceSendToId { get; set; }
        public string AddCc { get; set; }
        public string Details { get; set; }
        public List<string> DetailList { get; set; }
    }
}