using System.Threading.Tasks;
using Demo.Core.Infrastructure;
using Demo.Modules.RolesModule.Queries;

namespace Demo.Modules.RolesModule.Handlers
{
    public class GetRoleBusinessRuleValidationHandler : IBusinessRuleValidator<GetRoleQuery>
    {
        public async Task Validate(GetRoleQuery request)
        {
        }
    }
}
