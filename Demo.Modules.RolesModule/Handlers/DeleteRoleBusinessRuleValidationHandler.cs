using System.Threading.Tasks;
using Demo.Core.Infrastructure;
using Demo.Modules.RolesModule.BusinessRules;
using Demo.Modules.RolesModule.Commands;
using Demo.Modules.RolesModule.Repository;

namespace Demo.Modules.RolesModule.Handlers
{
    public class DeleteRoleBusinessRuleValidationHandler : IBusinessRuleValidator<DeleteRoleCommand>
    {
        private readonly IRolesRepository _repository;
        public DeleteRoleBusinessRuleValidationHandler(IRolesRepository repository)
        {
            _repository = repository;
        }

        public async Task Validate(DeleteRoleCommand request)
        {
            var roles =
                await _repository.Find(o => o.ApplicationId == request.DeleteRoleDto.ApplicationId && o.RoleId == request.DeleteRoleDto.RoleId);

            var businessRule =
                new RoleCannotBeDeletedWhenRecordDoesNotExistBusinessRule(roles, request.DeleteRoleDto);

            if (businessRule.IsBroken())
            {
                throw new BusinessRuleValidationException(businessRule);
            }
        }
    }
}
