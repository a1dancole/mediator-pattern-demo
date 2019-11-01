using Demo.Core.Domain.Dto.Roles;
using Demo.Core.Domain.Models;
using Demo.Core.Infrastructure;
using System.Linq;

namespace Demo.Modules.RolesModule.BusinessRules
{
    public class RoleCannotBeUpdatedWithDuplicateNameBusinessRule : IBusinessRule
    {
        private readonly IQueryable<Role> _roles;
        private readonly UpdateRoleDto _updateDto;

        public RoleCannotBeUpdatedWithDuplicateNameBusinessRule(IQueryable<Role> roles, UpdateRoleDto updateDto)
        {
            _roles = roles;
            _updateDto = updateDto;
        }

        public bool IsBroken() =>
            _roles.Any(o => o.ApplicationId == _updateDto.ApplicationId && o.RoleName == _updateDto.RoleName);

        public string Message =>
            $"Cannot update Role to name {_updateDto.RoleName} as there already exists a role with that name in application {_updateDto.ApplicationId}";
    }
}
