﻿using System.Threading.Tasks;
using Demo.Core.Infrastructure;
using Demo.Modules.ApplicationModule.BusinessRules;
using Demo.Modules.ApplicationModule.Commands;

namespace Demo.Modules.ApplicationModule.Handlers
{
    public class CreateApplicationBusinessRuleValidationHandler : IBusinessRuleValidator<CreateApplicationCommand>
    {
        private readonly IApplicationRepository _applicationRepository;

        public CreateApplicationBusinessRuleValidationHandler(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }
        public async Task Validate(CreateApplicationCommand request)
        {
            var applications =
                await _applicationRepository.Find(o => o.ApplicationName == request.ApplicationCreateDto.ApplicationName);

            var businessRule =
                new ApplicationCannotBeCreatedWithDuplicateNameBusinessRule(applications, request.ApplicationCreateDto);

            if (businessRule.IsBroken())
            {
                throw new BusinessRuleValidationException(businessRule);
            }
        }
    }
}
