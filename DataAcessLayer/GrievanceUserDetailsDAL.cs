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

        public bool UserRegistration(RegistrationModel model)
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

        public RegistrationModel Login(string emailAddress, string password)
        {
            RegistrationModel model = new RegistrationModel();
            try
            {
                if (!string.IsNullOrEmpty(emailAddress) && !string.IsNullOrEmpty(password))
                {
                    using (db = new GrievanceManagementSystemEntities())
                    {
                        GrievanceUserDetail userDetail = db.GrievanceUserDetails?.FirstOrDefault(x => x.Email == emailAddress && x.Password == password);
                        if (!string.Equals(userDetail, null))
                        {
                            model = new RegistrationModel()
                            {
                                EmailAddress = userDetail.Email,
                                FirstName = userDetail.FirstName,
                                LastName = userDetail.LastName,
                                EntityType = userDetail.EntityType,
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                model.HasError = true;
            }
            return model; 
        }
    }
}
