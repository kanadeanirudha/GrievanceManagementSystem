using GMS.DataAcessLayer;
using GMS.Model;
using System.Collections.Generic;

namespace GMS.BusinessLogicLayer
{
    public class GrievanceDetailsDataBusinessLogic
    {
        public GrievanceDetailsDataBusinessLogic()
        {

        }

        public bool CreateGrievance(GrievanceDetailsModel model)
        {
            bool status = new GrievanceDetailsDataDAL().CreateGrievance(model);
            return status;
        }
    }
}
