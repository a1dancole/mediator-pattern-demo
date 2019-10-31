using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Demo.Modules.ApplicationModule.Commands
{
    public class DeleteApplicationCommandValidator : AbstractValidator<DeleteApplicationCommand>
    {
        public DeleteApplicationCommandValidator()
        {
            RuleFor(x => x.ApplicationDeleteDto.ApplicationId).NotEmpty().WithMessage("ApplicationId cannot be empty");
            RuleFor(x => x.ApplicationDeleteDto.ApplicationName).NotEmpty()
                .WithMessage("ApplcationName cannot be empty");
        }
    }
}
