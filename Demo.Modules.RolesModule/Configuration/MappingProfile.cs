using AutoMapper;
using Demo.Core.Domain.Dto.Roles;
using Demo.Core.Domain.Models;

namespace Demo.Modules.RolesModule.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateRoleDto, Role>().ReverseMap();
            CreateMap<DeleteRoleDto, Role>().ReverseMap();
            CreateMap<UpdateRoleDto, Role>();
            CreateMap<Role, RoleDto>().ReverseMap();
        }
    }
}
