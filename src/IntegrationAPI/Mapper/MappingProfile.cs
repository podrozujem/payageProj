using AutoMapper;
using IntegrationLibrary.Core.Dto.blood_bank;
using IntegrationLibrary.Core.Model;

namespace IntegrationAPI.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<BloodBankDto, BloodBank>();
        }
    }
}
