﻿using GMS.DataAcessLayer;
using GMS.Model;

namespace GMS.BusinessLogicLayer
{
    public class GrievanceUserDetailsBusinessLogic
    {
        public GrievanceUserDetailsBusinessLogic()
        {

        }

        public bool UserRegistration(RegistrationModel model)
        {
            bool status = new GrievanceUserDetailsDAL().UserRegistration(model);
            return status;
        }
    }
}
