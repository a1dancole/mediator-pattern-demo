using Demo.Core.Infrastructure;
using Demo.Modules.ApplicationModule.BusinessRules;
using Demo.Modules.ApplicationModule.Commands;
using System.Threading.Tasks;

namespace Demo.Modules.ApplicationModule.Handlers
{
    public class CreateApplicationBusinessRuleValidationHandler : IBusinessRuleValidator<CreateApplicationCommand>
    {
        private readonly IApplicationRepository _applicationRepository;

        public CreateApplicationBusinessRuleValidationHandler(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }
        public async Task<IBusinessRule> Validate(CreateApplicationCommand request)
        {
            var applications =
                await _applicationRepository.Find(o => o.ApplicationName == request.ApplicationCreateDto.ApplicationName);

            return new ApplicationCannotBeCreatedWithDuplicateNameBusinessRule(applications, request.ApplicationCreateDto);
        }
    }
}
