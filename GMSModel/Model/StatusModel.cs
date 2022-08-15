using System;

namespace GMS.Model
{
    public class StatusModel : BaseModel
    {
        public Int16 StatusId { get; set; }
        public string StatusName { get; set; }
        public string StatusCode { get; set; }
    }
}
