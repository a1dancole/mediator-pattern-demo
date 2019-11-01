using Demo.Core.Domain.Dto.Roles;
using Demo.Core.Domain.Models;
using Demo.Core.Infrastructure;
using System.Linq;

namespace Demo.Modules.RolesModule.BusinessRules
{
    public class RoleCannotBeCreatedWithDuplicateNameAssociatedToApplicationBusinessRule : IBusinessRule
    {
        private readonly IQueryable<Role> _roles;
        private readonly CreateRoleDto _createDto;
        public RoleCannotBeCreatedWithDuplicateNameAssociatedToApplicationBusinessRule(IQueryable<Role> roles, CreateRoleDto createDto)
        {
            _roles = roles;
            _createDto = createDto;
        }

        public bool IsBroken() => _roles.Any(role =>
            role.ApplicationId == _createDto.ApplicationId && role.RoleName == _createDto.RoleName);

        public string Message => $"A role named {_createDto.RoleName} already exists in application id {_createDto.ApplicationId}";
    }
}
