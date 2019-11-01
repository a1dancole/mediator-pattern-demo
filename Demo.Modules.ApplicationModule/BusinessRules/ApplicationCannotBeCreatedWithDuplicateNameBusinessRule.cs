using Demo.Core.Domain.Dto.Application;
using Demo.Core.Domain.Models;
using Demo.Core.Infrastructure;
using System.Linq;

namespace Demo.Modules.ApplicationModule.BusinessRules
{
    public class ApplicationCannotBeCreatedWithDuplicateNameBusinessRule : IBusinessRule
    {
        private readonly IQueryable<Application> _applications;
        private readonly CreateApplicationDto _createDto;
        public ApplicationCannotBeCreatedWithDuplicateNameBusinessRule(IQueryable<Application> applications, CreateApplicationDto createDto)
        {
            _applications = applications;
            _createDto = createDto;
        }

        public bool IsBroken() => _applications.Any(o => o.ApplicationName == _createDto.ApplicationName);

        public string Message => $"An application named {_createDto.ApplicationName} already exists";
    }
}
