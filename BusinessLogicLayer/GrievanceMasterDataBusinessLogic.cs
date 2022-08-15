using GMS.DataAcessLayer;
using GMS.Model;
using System.Collections.Generic;

namespace GMS.BusinessLogicLayer
{
    public class GrievanceMasterDataBusinessLogic
    {
        public GrievanceMasterDataBusinessLogic()
        {

        }

        public List<DepartmentModel> GetGrievanceDepartmentList()
        {
            List<DepartmentModel> departmentList = new GrievanceMasterDataDAL().GetGrievanceDepartmentList();
            return departmentList;
        }

        public List<PriorityModel> GetGrievancePriorityList()
        {
            List<PriorityModel> priorityList = new GrievanceMasterDataDAL().GetGrievancePriorityList();
            return priorityList;
        }

        public List<StatusModel> GetGrievanceStatusList()
        {
            List<StatusModel> statusList = new GrievanceMasterDataDAL().GetGrievanceStatusList();
            return statusList;
        }

        public List<GrievanceTypeModel> GetGrievanceTypeList()
        {
            List<GrievanceTypeModel> grievanceTypeList = new GrievanceMasterDataDAL().GetGrievanceTypeList();
            return grievanceTypeList;
        }

        public List<GrievanceSendToModel> GetGrievanceSendToList()
        {
            List<GrievanceSendToModel> grievanceSendToList = new GrievanceMasterDataDAL().GetGrievanceSendToList();
            return grievanceSendToList;
        }
    }
}
