using Demo.Core.Infrastructure;
using Demo.Modules.RolesModule.BusinessRules;
using Demo.Modules.RolesModule.Commands;
using Demo.Modules.RolesModule.Repository;
using System.Threading.Tasks;

namespace Demo.Modules.RolesModule.Handlers
{
    public class UpdateRoleBusinessRuleValidationHandler : IBusinessRuleValidator<UpdateRoleCommand>
    {
        private readonly IRolesRepository _repository;
        public UpdateRoleBusinessRuleValidationHandler(IRolesRepository repository)
        {
            _repository = repository;
        }
        public async Task<IBusinessRule> Validate(UpdateRoleCommand request)
        {
            var roles = await _repository.Find(o =>
                o.ApplicationId == request.UpdateRoleDto.ApplicationId && o.RoleName == request.UpdateRoleDto.RoleName);

            return new RoleCannotBeUpdatedWithDuplicateNameBusinessRule(roles, request.UpdateRoleDto);
        }
    }
}
