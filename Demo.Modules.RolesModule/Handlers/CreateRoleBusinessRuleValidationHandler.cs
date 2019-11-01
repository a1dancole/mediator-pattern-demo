using Demo.Core.Infrastructure;
using Demo.Modules.RolesModule.BusinessRules;
using Demo.Modules.RolesModule.Commands;
using Demo.Modules.RolesModule.Repository;
using System.Threading.Tasks;

namespace Demo.Modules.RolesModule.Handlers
{
    public class CreateRoleBusinessRuleValidationHandler : IBusinessRuleValidator<CreateRoleCommand>
    {
        private readonly IRolesRepository _repository;

        public CreateRoleBusinessRuleValidationHandler(IRolesRepository repository)
        {
            _repository = repository;
        }

        public async Task<IBusinessRule> Validate(CreateRoleCommand request)
        {
            var roles =
                await _repository.Find(o =>
                    o.ApplicationId == request.CreateRoleDto.ApplicationId &&
                    o.RoleName == request.CreateRoleDto.RoleName);

            return new RoleCannotBeCreatedWithDuplicateNameAssociatedToApplicationBusinessRule(roles,
                request.CreateRoleDto);
        }
    }
}
