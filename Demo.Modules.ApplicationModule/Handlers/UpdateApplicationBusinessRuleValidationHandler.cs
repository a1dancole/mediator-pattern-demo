using Demo.Core.Infrastructure;
using Demo.Modules.ApplicationModule.BusinessRules;
using Demo.Modules.ApplicationModule.Commands;
using System.Threading.Tasks;

namespace Demo.Modules.ApplicationModule.Handlers
{
    public class UpdateApplicationBusinessRuleValidationHandler : IBusinessRuleValidator<UpdateApplicationCommand>
    {
        private readonly IApplicationRepository _applicationRepository;

        public UpdateApplicationBusinessRuleValidationHandler(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public async Task<IBusinessRule> Validate(UpdateApplicationCommand request)
        {
            var applications =
                await _applicationRepository.Find(
                    o => o.ApplicationName == request.ApplicationUpdateDto.ApplicationName);

            return new ApplicationCannotBeUpdatedWithDuplicateNameBusinessRule(applications,
                request.ApplicationUpdateDto);
        }
    }
}
