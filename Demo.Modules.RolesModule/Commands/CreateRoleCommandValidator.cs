using System.Collections.Generic;
using FluentValidation;

namespace Demo.Modules.RolesModule.Commands
{
    public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleCommandValidator()
        {
            RuleFor(x => x.CreateRoleDto.ApplicationId).NotEmpty().WithMessage("ApplicationId cannot be empty");
            RuleFor(x => x.CreateRoleDto.RoleName).NotEmpty().WithMessage("RoleName cannot be empty");
        }
    }
}
