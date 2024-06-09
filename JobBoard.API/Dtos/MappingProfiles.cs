using AutoMapper;
using JobBoard.API.Models;

namespace JobBoard.API.Dtos
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Job, JobDto>()
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.CompanyName))
                .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Categories.Select(jc => jc.Name)))
                .ForMember(dest => dest.Locations, opt => opt.MapFrom(src => src.Locations.Select(l => $"{l.City}, {l.Country}")));
        }
    }
}
