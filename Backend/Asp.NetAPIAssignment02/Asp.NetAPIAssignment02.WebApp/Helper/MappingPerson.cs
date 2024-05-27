using Asp.NetAPIAssignment02.WebApp.Dto;
using Asp.NetAPIAssignment02.WebApp.Models;
using AutoMapper;

namespace Asp.NetAPIAssignment02.WebApp.Helper
{
    public class MappingPerson : Profile
    {
        public MappingPerson()
        {
            CreateMap<PersonDto, PersonModel>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
