using Demo.Core.Domain.Dto.Roles;
using MediatR;

namespace Demo.Modules.RolesModule.Commands
{
    public class UpdateRoleCommand : IRequest<RoleDto>
    {
        public UpdateRoleCommand(UpdateRoleDto updateDto)
        {
            UpdateRoleDto = updateDto;
        }

        public UpdateRoleDto UpdateRoleDto { get; set; }
    }
}
