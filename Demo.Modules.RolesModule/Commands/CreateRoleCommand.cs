using Demo.Core.Domain.Dto.Roles;
using MediatR;

namespace Demo.Modules.RolesModule.Commands
{
    public class CreateRoleCommand : IRequest<RoleDto>
    {
        public CreateRoleCommand(CreateRoleDto createDto)
        {
            CreateRoleDto = createDto;
        }

        public CreateRoleDto CreateRoleDto { get; }
    }
}
