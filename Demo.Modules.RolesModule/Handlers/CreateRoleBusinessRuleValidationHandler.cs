using System.Threading.Tasks;
using Demo.Core.Infrastructure;
using Demo.Modules.RolesModule.BusinessRules;
using Demo.Modules.RolesModule.Commands;
using Demo.Modules.RolesModule.Repository;

namespace Demo.Modules.RolesModule.Handlers
{
    public class CreateRoleBusinessRuleValidationHandler : IBusinessRuleValidator<CreateRoleCommand>
    {
        private readonly IRolesRepository _repository;
        public CreateRoleBusinessRuleValidationHandler(IRolesRepository repository)
        {
            _repository = repository;
        }
        public async Task Validate(CreateRoleCommand request)
        {
            var roles =
                await _repository.Find(o => o.ApplicationId == request.CreateRoleDto.ApplicationId && o.RoleName == request.CreateRoleDto.RoleName);

            var businessRule =
                new RoleCannotBeCreatedWithDuplicateNameAssociatedToApplicationBusinessRule(roles, request.CreateRoleDto);

            if (businessRule.IsBroken())
            {
                throw new BusinessRuleValidationException(businessRule);
            }
        }
    }
}
