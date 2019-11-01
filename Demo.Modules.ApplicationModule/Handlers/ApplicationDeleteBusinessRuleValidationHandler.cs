using Demo.Core.Infrastructure;
using Demo.Modules.ApplicationModule.BusinessRules;
using Demo.Modules.ApplicationModule.Commands;
using System.Threading.Tasks;

namespace Demo.Modules.ApplicationModule.Handlers
{
    public class ApplicationDeleteBusinessRuleValidationHandler : IBusinessRuleValidator<DeleteApplicationCommand>
    {
        private readonly IApplicationRepository _applicationRepository;

        public ApplicationDeleteBusinessRuleValidationHandler(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }
        public async Task<IBusinessRule> Validate(DeleteApplicationCommand request)
        {
            var applications =
                await _applicationRepository.Find(o => o.ApplicationId == request.ApplicationDeleteDto.ApplicationId);

            return new ApplicationCannotBeDeleteWhenRecordDoesNotExistInDatabaseBusinessRule(request, applications);
        }
    }
}
