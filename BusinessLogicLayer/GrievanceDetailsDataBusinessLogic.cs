using GMS.DataAcessLayer;
using GMS.Model;
using System;
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

        public bool UpdateGrievance(GrievanceDetailsModel model)
        {
            bool status = new GrievanceDetailsDataDAL().UpdateGrievance(model);
            return status;
        }

        public List<GrievanceDetailsModel> GetGrievanceList(int userId, Int16 departmentId)
        {
            List<GrievanceDetailsModel> list = new GrievanceDetailsDataDAL().GetGrievanceList(userId, departmentId);
            return list;
        }

        public List<GrievanceDetailsModel> GetGrievanceListForEmployee(Int16 departmentId)
        {
            List<GrievanceDetailsModel> list = new GrievanceDetailsDataDAL().GetGrievanceListForEmployee(departmentId);
            return list;
        }

        public GrievanceDetailsModel GetGrievanceDetails(long grievanceId, int userId)
        {
            GrievanceDetailsModel grievanceDetailsModel = new GrievanceDetailsDataDAL().GetGrievanceDetails(grievanceId, userId);
            return grievanceDetailsModel;
        }
    }
}
