using GMS.DataAcessLayer.Data;
using GMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMS.DataAcessLayer
{
    public class GrievanceUserDetailsDAL
    {
        GrievanceManagementSystemEntities db = null;
        public GrievanceUserDetailsDAL()
        {
        }

        public bool UserRegistration(UserModel model)
        {
            bool status = false;
            try
            {
                if (model != null)
                {
                    using (db = new GrievanceManagementSystemEntities())
                    {
                        var userDetails = new GrievanceUserDetail()
                        {
                            Email = model.EmailAddress
                        };
                        db.GrievanceUserDetails.Add(userDetails);
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

        public UserModel Login(string emailAddress, string password)
        {
            UserModel model = new UserModel();
            try
            {
                if (!string.IsNullOrEmpty(emailAddress) && !string.IsNullOrEmpty(password))
                {
                    using (db = new GrievanceManagementSystemEntities())
                    {
                        GrievanceUserDetail userDetail = db.GrievanceUserDetails?.FirstOrDefault(x => x.Email == emailAddress && x.Password == password);
                        model = BindUserData(model, userDetail);
                    }
                }
            }
            catch (Exception ex)
            {
                model.HasError = true;
            }
            return model;
        }

        #region Private
        private static UserModel BindUserData(UserModel model, GrievanceUserDetail userDetail)
        {
            if (!string.Equals(userDetail, null))
            {
                model = new UserModel()
                {
                    UserId = userDetail.UserId,
                    EmailAddress = userDetail.Email,
                    FirstName = userDetail.FirstName,
                    LastName = userDetail.LastName,
                    EntityType = userDetail.EntityType,
                    EnrollmentNumber = userDetail.EnrollmentNumber,
                    ContactNumber = userDetail.ContactNo
                };
            }
            return model;
        }
        #endregion
    }
}
