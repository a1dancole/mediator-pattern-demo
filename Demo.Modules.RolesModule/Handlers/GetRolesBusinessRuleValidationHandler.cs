using System.Threading.Tasks;
using Demo.Core.Infrastructure;
using Demo.Modules.RolesModule.Queries;

namespace Demo.Modules.RolesModule.Handlers
{
    public class GetRolesBusinessRuleValidationHandler : IBusinessRuleValidator<GetRolesQuery>
    {
        public async Task Validate(GetRolesQuery request)
        {
        }
    }
}
