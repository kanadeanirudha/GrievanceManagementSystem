using AutoMapper;
using GMS.Model;
using GrievanceManagementSystem.ViewModels;

namespace GrievanceManagementSystem
{
    public static class AutoMapperConfig
    {
        public static void Execute()
        {
            Mapper.CreateMap<RegistrationModel, RegistrationViewModel>().ReverseMap();
            Mapper.CreateMap<RegistrationModel, UserLoginViewModel>().ReverseMap();
        }
    }
}
