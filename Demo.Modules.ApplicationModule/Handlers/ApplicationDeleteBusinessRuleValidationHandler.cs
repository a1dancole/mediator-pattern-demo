using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Demo.Core.Infrastructure;
using Demo.Modules.ApplicationModule.BusinessRules;
using Demo.Modules.ApplicationModule.Commands;

namespace Demo.Modules.ApplicationModule.Handlers
{
    public class ApplicationDeleteBusinessRuleValidationHandler : IBusinessRuleValidator<DeleteApplicationCommand>
    {
        private readonly IApplicationRepository _applicationRepository;

        public ApplicationDeleteBusinessRuleValidationHandler(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }
        public async Task Validate(DeleteApplicationCommand request)
        {
            var applications =
                await _applicationRepository.Find(o => o.ApplicationId == request.ApplicationDeleteDto.ApplicationId);

            var businessRule =
                new ApplicationCannotBeDeleteWhenRecordDoesNotExistInDatabaseBusinessRule(request, applications);

            if (businessRule.IsBroken())
            {
                throw new BusinessRuleValidationException(businessRule);
            }
        }
    }
}
