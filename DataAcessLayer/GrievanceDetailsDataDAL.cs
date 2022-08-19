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

        public bool UpdateGrievance(GrievanceDetailsModel model)
        {
            bool status = false;
            try
            {
                if (model != null)
                {
                    DateTime date = DateTime.Now;
                    GrievanceMaster grievanceMaster = null;
                    using (db = new GrievanceManagementSystemEntities())
                    {
                        grievanceMaster = db.GrievanceMasters.FirstOrDefault(x => x.GrievanceId == model.GrievanceId);
                        if (grievanceMaster != null)
                        {
                            grievanceMaster.PriorityId = model.PriorityId;
                            grievanceMaster.StatusId = model.StatusId;
                            grievanceMaster.ModifiedBy = model.UserId;
                            grievanceMaster.ModifiedDate = date;
                            db.GrievanceMasters.Add(grievanceMaster);
                            db.Entry(grievanceMaster).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                        }
                    }

                    if (grievanceMaster != null)
                    {
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
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }

        //Get Grievance List 
        public List<GrievanceDetailsModel> GetGrievanceList(int userId, short departmentId)
        {
            List<GrievanceDetailsModel> list = new List<GrievanceDetailsModel>();
            try
            {
                using (db = new GrievanceManagementSystemEntities())
                {
                    list = (from gm in db.GrievanceMasters
                            join gt in db.GrievanceTypeMasters on gm.GrievanceTypeId equals gt.GrievanceTypeId
                            join gp in db.GrievancePriorityMasters on gm.PriorityId equals gp.PriorityId
                            join gd in db.GrievanceDepartmentMasters on gm.DepartmentId equals gd.DepartmentId
                            join gst in db.GrievanceSendToMasters on gm.GrievanceSendToId equals gst.GrievanceSendToId
                            join gsm in db.GrievanceStatusMasters on gm.StatusId equals gsm.StatusId
                            where (gm.UserId == userId) && (gm.DepartmentId == departmentId || departmentId == 0)
                            orderby gm.CreatedDate descending
                            select new GrievanceDetailsModel
                            {
                                GrievanceId = gm.GrievanceId,
                                GrievanceNumber = gm.GrievanceNumber,
                                GrievanceTypeName = gt.GrievanceTypeName,
                                PriorityName = gp.PriorityName,
                                DepartmentName = gd.DepartmentName,
                                GrievanceSendToName = gst.GrievanceSendToName,
                                StatusName = gsm.StatusName
                            })?.ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }

        public List<GrievanceDetailsModel> GetGrievanceListForEmployee(short departmentId)
        {
            List<GrievanceDetailsModel> list = new List<GrievanceDetailsModel>();
            try
            {
                using (db = new GrievanceManagementSystemEntities())
                {
                    list = (from gm in db.GrievanceMasters
                            join gt in db.GrievanceTypeMasters on gm.GrievanceTypeId equals gt.GrievanceTypeId
                            join gp in db.GrievancePriorityMasters on gm.PriorityId equals gp.PriorityId
                            join gd in db.GrievanceDepartmentMasters on gm.DepartmentId equals gd.DepartmentId
                            join gst in db.GrievanceSendToMasters on gm.GrievanceSendToId equals gst.GrievanceSendToId
                            join gsm in db.GrievanceStatusMasters on gm.StatusId equals gsm.StatusId
                            join gud in db.GrievanceUserDetails on gm.UserId equals gud.UserId
                            where (gm.DepartmentId == departmentId || departmentId == 0)
                            orderby gm.CreatedDate descending
                            select new GrievanceDetailsModel
                            {
                                GrievanceId = gm.GrievanceId,
                                GrievanceNumber = gm.GrievanceNumber,
                                GrievanceTypeName = gt.GrievanceTypeName,
                                PriorityName = gp.PriorityName,
                                DepartmentName = gd.DepartmentName,
                                GrievanceSendToName = gst.GrievanceSendToName,
                                StatusName = gsm.StatusName,
                                FullName = gud.FirstName + " " + gud.LastName,
                            })?.ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }

        public GrievanceDetailsModel GetGrievanceDetails(long grievanceId, int userId)
        {
            GrievanceDetailsModel model = null;
            try
            {
                using (db = new GrievanceManagementSystemEntities())
                {
                    model = (from gm in db.GrievanceMasters
                             join gt in db.GrievanceTypeMasters on gm.GrievanceTypeId equals gt.GrievanceTypeId
                             join gp in db.GrievancePriorityMasters on gm.PriorityId equals gp.PriorityId
                             join gd in db.GrievanceDepartmentMasters on gm.DepartmentId equals gd.DepartmentId
                             join gst in db.GrievanceSendToMasters on gm.GrievanceSendToId equals gst.GrievanceSendToId
                             join gsm in db.GrievanceStatusMasters on gm.StatusId equals gsm.StatusId
                             join gud in db.GrievanceUserDetails on gm.UserId equals gud.UserId
                             where gm.GrievanceId == grievanceId && (gud.UserId == userId || userId == 0)
                             orderby gm.CreatedDate descending
                             select new GrievanceDetailsModel
                             {
                                 GrievanceId = gm.GrievanceId,
                                 GrievanceNumber = gm.GrievanceNumber,
                                 Subject = gm.Subject,
                                 GrievanceTypeName = gt.GrievanceTypeName,
                                 PriorityId = gm.PriorityId,
                                 PriorityName = gp.PriorityName,
                                 DepartmentName = gd.DepartmentName,
                                 GrievanceSendToName = gst.GrievanceSendToName,
                                 StatusName = gsm.StatusName,
                                 StatusId = gm.StatusId,
                                 FullName = gud.FirstName + " " + gud.LastName,
                                 ContactNumber = gud.ContactNo,
                                 EnrollmentNumber = gud.EnrollmentNumber,
                                 EmailAddress = gud.Email
                             })?.FirstOrDefault();

                    if (model != null)
                    {
                        model.DetailList = (from gd in db.GrievanceDetails
                                            join gud in db.GrievanceUserDetails on gd.CreatedBy equals gud.UserId
                                            where gd.GrievanceId == grievanceId
                                            orderby gd.CreatedDate ascending
                                            select gd.Details + "~" + (gud.FirstName + " " + gud.LastName) + "~" + gd.CreatedDate).ToList();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return model;
        }
    }
}
