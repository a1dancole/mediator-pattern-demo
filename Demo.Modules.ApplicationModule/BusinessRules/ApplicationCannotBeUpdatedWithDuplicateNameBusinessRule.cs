using Demo.Core.Domain.Dto.Application;
using Demo.Core.Domain.Models;
using Demo.Core.Infrastructure;
using System.Linq;

namespace Demo.Modules.ApplicationModule.BusinessRules
{
    public class ApplicationCannotBeUpdatedWithDuplicateNameBusinessRule : IBusinessRule
    {
        private readonly IQueryable<Application> _applications;
        private readonly UpdateApplicationDto _updateDto;
        public ApplicationCannotBeUpdatedWithDuplicateNameBusinessRule(IQueryable<Application> applications, UpdateApplicationDto updateDto)
        {
            _applications = applications;
            _updateDto = updateDto;
        }

        public bool IsBroken() => _applications.Any(o => o.ApplicationName == _updateDto.ApplicationName);

        public string Message => $"An application with {_updateDto.ApplicationName} already exists";
    }
}
