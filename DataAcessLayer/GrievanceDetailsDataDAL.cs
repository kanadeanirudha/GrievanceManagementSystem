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
    }
}
