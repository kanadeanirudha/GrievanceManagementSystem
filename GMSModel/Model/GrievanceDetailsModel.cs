using GMS.Model;

using System;

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
        public Int16 StatusId { get; set; }
        public Int16 GrievanceTypeId { get; set; }
        public string GrievanceTypeName { get; set; }
        public string Subject { get; set; }
        public Int16 PriorityId { get; set; }
        public string PriorityName { get; set; }
        public Int16 DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string GrievanceSendToName { get; set; }
        public string StatusName { get; set; }
        public Int16 GrievanceSendToId { get; set; }
        public string AddCc { get; set; }
        public string Details { get; set; }
    }
}