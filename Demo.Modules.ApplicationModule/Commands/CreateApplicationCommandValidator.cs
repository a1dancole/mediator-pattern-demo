using FluentValidation;

namespace Demo.Modules.ApplicationModule.Commands
{
    public class CreateApplicationCommandValidator : AbstractValidator<CreateApplicationCommand>
    {
        public CreateApplicationCommandValidator()
        {
            RuleFor(x => x.ApplicationCreateDto.ApplicationName).NotEmpty().WithMessage("ApplicationName cannot be empty");
        }
    }
}
