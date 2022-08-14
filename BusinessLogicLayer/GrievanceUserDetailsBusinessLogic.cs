using GMS.DataAcessLayer;
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

        public RegistrationModel Login(string emailAddress, string password)
        {
            RegistrationModel model = new GrievanceUserDetailsDAL().Login(emailAddress, password);
            return model;
        }
    }
}
