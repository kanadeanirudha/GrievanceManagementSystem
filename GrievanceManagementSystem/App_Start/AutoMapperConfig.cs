using AutoMapper;
using GMS.Model;
using GrievanceManagementSystem.ViewModels;

namespace GrievanceManagementSystem
{
    public static class AutoMapperConfig
    {
        public static void Execute()
        {
            Mapper.CreateMap<UserModel, RegistrationViewModel>().ReverseMap();
            Mapper.CreateMap<UserModel, UserLoginViewModel>().ReverseMap();
        }
    }
}
