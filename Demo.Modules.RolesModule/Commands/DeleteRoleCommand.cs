using Demo.Core.Domain.Dto.Roles;
using MediatR;

namespace Demo.Modules.RolesModule.Commands
{
    public class DeleteRoleCommand : IRequest<bool>
    {
        public DeleteRoleCommand(DeleteRoleDto deleteDto)
        {
            DeleteRoleDto = deleteDto;
        }

        public DeleteRoleDto DeleteRoleDto { get; }
    }
}
