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

        public bool Login(RegistrationModel model)
        {
            bool status = new GrievanceUserDetailsDAL().Login(model);
            return status;
        }
    }
}
