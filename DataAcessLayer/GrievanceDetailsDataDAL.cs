using GMS.DataAcessLayer.Data;
using GMS.Model;

using System;
using System.Collections.Generic;
using System.Linq;

namespace GMS.DataAcessLayer
{
    public class GrievanceDetailsDataDAL
    {
        GrievanceManagementSystemEntities db = null;
        public GrievanceDetailsDataDAL()
        {
        }

        public bool CreateGrievance(GrievanceDetailsModel model)
        {
            bool status = false;
            try
            {
                if (model != null)
                {
                    DateTime date = DateTime.Now;
                    GrievanceMaster grievanceMaster = new GrievanceMaster()
                    {
                        GrievanceNumber = date.ToString("yyMMddmmHHmmss"),
                        UserId = model.UserId,
                        StatusId = model.StatusId,
                        GrievanceTypeId = model.GrievanceTypeId,
                        Subject = model.Subject,
                        PriorityId = model.PriorityId,
                        DepartmentId = model.DepartmentId,
                        GrievanceSendToId = model.GrievanceSendToId,
                        AddCc = model.AddCc,
                        CreatedBy = model.UserId,
                        CreatedDate = date
                    };
                    using (db = new GrievanceManagementSystemEntities())
                    {
                        db.GrievanceMasters.Add(grievanceMaster);
                        db.SaveChanges();
                    }

                    GrievanceDetail grievanceDetails = new GrievanceDetail()
                    {
                        GrievanceId = grievanceMaster.GrievanceId,
                        Details = model.Details,
                        CreatedBy = model.UserId,
                        CreatedDate = date,
                        ModifiedBy = model.UserId,
                        ModifiedDate = date
                    };
                    using (db = new GrievanceManagementSystemEntities())
                    {
                        db.GrievanceDetails.Add(grievanceDetails);
                        db.SaveChanges();
                        status = true;
                    }
                }
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }

        public List<GrievanceDetailsModel> GetGrievanceList(int userId, Int16 departmentId)
        {
            List<GrievanceDetailsModel> list = new List<GrievanceDetailsModel>();
            try
            {
                using (db = new GrievanceManagementSystemEntities())
                {
                    var dataList = (from gm in db.GrievanceMasters
                                    join gt in db.GrievanceTypeMasters on gm.GrievanceTypeId equals gt.GrievanceTypeId
                                    join gp in db.GrievancePriorityMasters on gm.PriorityId equals gp.PriorityId
                                    join gd in db.GrievanceDepartmentMasters on gm.DepartmentId equals gd.DepartmentId
                                    join gst in db.GrievanceSendToMasters on gm.GrievanceSendToId equals gst.GrievanceSendToId
                                    join gsm in db.GrievanceStatusMasters on gm.StatusId equals gsm.StatusId
                                    where (gm.UserId == userId) //&& (gm.DepartmentId == departmentId || gm.DepartmentId == 0)
                                    select new
                                    {
                                        gm.GrievanceNumber,
                                        gt.GrievanceTypeName,
                                        gp.PriorityName,
                                        gd.DepartmentName,
                                        gst.GrievanceSendToName,
                                        gsm.StatusName
                                    }).ToList();
                    if (dataList?.Count > 0)
                    {
                        foreach (var item in dataList)
                        {
                            list.Add(new GrievanceDetailsModel
                            {
                                GrievanceNumber = item.GrievanceNumber,
                                GrievanceTypeName = item.GrievanceTypeName,
                                PriorityName = item.PriorityName,
                                DepartmentName = item.DepartmentName,
                                GrievanceSendToName = item.GrievanceSendToName,
                                StatusName = item.StatusName
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }
    }
}
