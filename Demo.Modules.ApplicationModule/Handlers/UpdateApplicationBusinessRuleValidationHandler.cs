using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Demo.Core.Infrastructure;
using Demo.Modules.ApplicationModule.BusinessRules;
using Demo.Modules.ApplicationModule.Commands;

namespace Demo.Modules.ApplicationModule.Handlers
{
    public class UpdateApplicationBusinessRuleValidationHandler : IBusinessRuleValidator<UpdateApplicationCommand>
    {
        private readonly IApplicationRepository _applicationRepository;
        public UpdateApplicationBusinessRuleValidationHandler(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }
        public async Task Validate(UpdateApplicationCommand request)
        {
            var applications =
                await _applicationRepository.Find(o => o.ApplicationName == request.ApplicationUpdateDto.ApplicationName);

            var businessRule =
                new ApplicationCannotBeUpdatedWithDuplicateNameBusinessRule(applications, request.ApplicationUpdateDto);

            if (businessRule.IsBroken())
            {
                throw new BusinessRuleValidationException(businessRule);
            }
        }
    }
}
