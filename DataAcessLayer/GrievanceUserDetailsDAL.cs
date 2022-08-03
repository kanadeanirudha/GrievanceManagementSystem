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
    }
}
