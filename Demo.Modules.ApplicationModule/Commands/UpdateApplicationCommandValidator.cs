using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Demo.Modules.ApplicationModule.Commands
{
    public class UpdateApplicationCommandValidator : AbstractValidator<UpdateApplicationCommand>
    {
        public UpdateApplicationCommandValidator()
        {
            RuleFor(x => x.ApplicationUpdateDto.ApplicationId).NotEmpty().WithMessage("ApplicationId cannot be empty");
            RuleFor(x => x.ApplicationUpdateDto.ApplicationName).NotEmpty()
                .WithMessage("ApplicationName cannot be empty");
        }
    }
}
