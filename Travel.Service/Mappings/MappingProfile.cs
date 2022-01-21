using AutoMapper;
using Travel.Core.BusinessModels;
using Travel.Entities.Entity;

namespace Travel.Service.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDetails>().ReverseMap();
            CreateMap<Counter, CounterDetails>().ReverseMap();
        }
    }
}
