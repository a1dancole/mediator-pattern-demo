using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo.Core.Domain.Models;
using Demo.Core.Infrastructure;
using Demo.Modules.ApplicationModule.Commands;

namespace Demo.Modules.ApplicationModule.BusinessRules
{
    public class ApplicationCannotBeDeleteWhenRecordDoesNotExistInDatabaseBusinessRule : IBusinessRule
    {
        private readonly DeleteApplicationCommand _command;
        private readonly IQueryable<Application> _applications;
        public ApplicationCannotBeDeleteWhenRecordDoesNotExistInDatabaseBusinessRule(DeleteApplicationCommand command, IQueryable<Application> applications)
        {
            _applications = applications;
            _command = command;
        }

        public bool IsBroken()
        {
            return !_applications.Any();
        }

        public string Message => $"Cannot delete application with Id {_command.ApplicationDeleteDto.ApplicationId} as it does not exist in the database";
    }
}
