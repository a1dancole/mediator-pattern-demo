using Demo.Core.Domain.Dto.Roles;
using Demo.Core.Domain.Models;
using Demo.Core.Infrastructure;
using System.Linq;

namespace Demo.Modules.RolesModule.BusinessRules
{
    public class RoleCannotBeDeletedWhenRecordDoesNotExistBusinessRule : IBusinessRule
    {
        private readonly IQueryable<Role> _roles;
        private readonly DeleteRoleDto _deleteDto;
        public RoleCannotBeDeletedWhenRecordDoesNotExistBusinessRule(IQueryable<Role> roles,
            DeleteRoleDto deleteDto)
        {
            _roles = roles;
            _deleteDto = deleteDto;
        }

        public bool IsBroken() => !_roles.Any(o => o.ApplicationId == _deleteDto.ApplicationId && o.RoleId == _deleteDto.RoleId);

        public string Message =>
            $"Cannot delete role with Id {_deleteDto.ApplicationId} as the role does not exist in Application {_deleteDto.ApplicationId}";
    }
}
