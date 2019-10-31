using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Demo.Core.Infrastructure;
using Demo.Modules.ApplicationModule.Queries;

namespace Demo.Modules.ApplicationModule.Handlers
{
    public class GetApplicationBusinessRuleValidatonHandler : IBusinessRuleValidator<GetApplicationQuery>
    {
        public async Task Validate(GetApplicationQuery request)
        {
        }
    }
}
