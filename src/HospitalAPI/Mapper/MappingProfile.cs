using AutoMapper;
using HospitalLibrary.Dto.blood_bank;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Dto.user;

namespace HospitalAPI.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<BloodBankRegistrationDto, BloodBankDto>();
            CreateMap<BloodBankRegistrationDto, User>();
            CreateMap<UserDto, User>();
            CreateMap<UserEmailDto, User>();
            CreateMap<User, UserEmailDto>();
        }
    }
}
