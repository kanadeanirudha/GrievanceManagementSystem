using GMS.DataAcessLayer.Data;
using GMS.Model;

using System;
using System.Collections.Generic;
using System.Linq;

namespace GMS.DataAcessLayer
{
    public class GrievanceMasterDataDAL
    {
        GrievanceManagementSystemEntities db = null;
        public GrievanceMasterDataDAL()
        {
        }

        public List<DepartmentModel> GetGrievanceDepartmentList()
        {
            List<DepartmentModel> departmentList = null;
            try
            {
                using (db = new GrievanceManagementSystemEntities())
                {
                    List<GrievanceDepartmentMaster> departmentDBList = db.GrievanceDepartmentMasters?.Where(x => x.IsActive)?.ToList();
                    if (departmentDBList?.Count > 0)
                    {
                        departmentList = new List<DepartmentModel>();
                        foreach (GrievanceDepartmentMaster department in departmentDBList)
                        {
                            departmentList.Add(new DepartmentModel()
                            {
                                DepartmentId = department.DepartmentId,
                                DepartmentName = department.DepartmentName,
                                DepartmentCode = department.DepartmentCode
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return departmentList;
        }

        public List<PriorityModel> GetGrievancePriorityList()
        {
            List<PriorityModel> priorityList = null;
            try
            {
                using (db = new GrievanceManagementSystemEntities())
                {
                    List<GrievancePriorityMaster> priorityDBList = db.GrievancePriorityMasters?.Where(x => x.IsActive)?.ToList();
                    if (priorityDBList?.Count > 0)
                    {
                        priorityList = new List<PriorityModel>();
                        foreach (GrievancePriorityMaster priority in priorityDBList)
                        {
                            priorityList.Add(new PriorityModel()
                            {
                                PriorityId = priority.PriorityId,
                                PriorityName = priority.PriorityName,
                                PriorityCode = priority.PriorityCode
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return priorityList;
        }

        public List<StatusModel> GetGrievanceStatusList()
        {
            List<StatusModel> statusList = null;
            try
            {
                using (db = new GrievanceManagementSystemEntities())
                {
                    List<GrievanceStatusMaster> statusDBList = db.GrievanceStatusMasters?.Where(x => x.IsActive)?.ToList();
                    if (statusDBList?.Count > 0)
                    {
                        statusList = new List<StatusModel>();
                        foreach (GrievanceStatusMaster status in statusDBList)
                        {
                            statusList.Add(new StatusModel()
                            {
                                StatusId = status.StatusId,
                                StatusName = status.StatusName,
                                StatusCode = status.StatusCode
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return statusList;
        }

        public List<GrievanceTypeModel> GetGrievanceTypeList()
        {
            List<GrievanceTypeModel> grievanceTypeList = null;
            try
            {
                using (db = new GrievanceManagementSystemEntities())
                {
                    List<GrievanceTypeMaster> grievanceTypeDBList = db.GrievanceTypeMasters?.Where(x => x.IsActive)?.ToList();
                    if (grievanceTypeDBList?.Count > 0)
                    {
                        grievanceTypeList = new List<GrievanceTypeModel>();
                        foreach (GrievanceTypeMaster grievanceType in grievanceTypeDBList)
                        {
                            grievanceTypeList.Add(new GrievanceTypeModel()
                            {
                                GrievanceTypeId = grievanceType.GrievanceTypeId,
                                GrievanceTypeName = grievanceType.GrievanceTypeName,
                                GrievanceTypeCode = grievanceType.GrievanceTypeCode
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return grievanceTypeList;
        }

        public List<GrievanceSendToModel> GetGrievanceSendToList()
        {
            List<GrievanceSendToModel> grievanceSendToList = null;
            try
            {
                using (db = new GrievanceManagementSystemEntities())
                {
                    List<GrievanceSendToMaster> grievanceSendToDBList = db.GrievanceSendToMasters?.Where(x => x.IsActive)?.ToList();
                    if (grievanceSendToDBList?.Count > 0)
                    {
                        grievanceSendToList = new List<GrievanceSendToModel>();
                        foreach (GrievanceSendToMaster grievanceSendTo in grievanceSendToDBList)
                        {
                            grievanceSendToList.Add(new GrievanceSendToModel()
                            {
                                GrievanceSendToId = grievanceSendTo.GrievanceSendToId,
                                GrievanceSendToName = grievanceSendTo.GrievanceSendToName,
                                GrievanceSendToCode = grievanceSendTo.GrievanceSendToCode
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return grievanceSendToList;
        }
    }
}
