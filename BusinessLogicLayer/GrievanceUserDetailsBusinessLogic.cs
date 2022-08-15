using GMS.DataAcessLayer;
using GMS.Model;

namespace GMS.BusinessLogicLayer
{
    public class GrievanceUserDetailsBusinessLogic
    {
        public GrievanceUserDetailsBusinessLogic()
        {

        }

        public bool UserRegistration(UserModel model)
        {
            bool status = new GrievanceUserDetailsDAL().UserRegistration(model);
            return status;
        }

        public UserModel Login(string emailAddress, string password)
        {
            UserModel model = new GrievanceUserDetailsDAL().Login(emailAddress, password);
            return model;
        }
    }
}
