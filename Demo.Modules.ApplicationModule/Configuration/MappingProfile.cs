using AutoMapper;
using Demo.Core.Domain.Dto.Application;
using Demo.Core.Domain.Models;

namespace Demo.Modules.ApplicationModule.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateApplicationDto, Application>().ReverseMap();
            CreateMap<DeleteApplicationDto, Application>().ReverseMap();
            CreateMap<UpdateApplicationDto, Application>();
            CreateMap<Application, ApplicationDto>().ReverseMap();
        }
    }
}
