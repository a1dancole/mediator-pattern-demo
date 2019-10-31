using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Demo.Core.Infrastructure;
using Demo.Modules.ApplicationModule.Queries;

namespace Demo.Modules.ApplicationModule.Handlers
{
    public class GetApplicationsBusinessRuleValidationHandler : IBusinessRuleValidator<GetApplicationsQuery>
    {
        public async Task Validate(GetApplicationsQuery request)
        {
        }
    }
}
