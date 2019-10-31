using FluentValidation;

namespace Demo.Modules.RolesModule.Commands
{
    public class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>
    {
        public UpdateRoleCommandValidator()
        {
            RuleFor(x => x.UpdateRoleDto.ApplicationId).NotEmpty().WithMessage("ApplicationId cannot be empty");
            RuleFor(x => x.UpdateRoleDto.RoleName).NotEmpty().WithMessage("RoleName cannot be empty");
            RuleFor(x => x.UpdateRoleDto.RoleId).NotEmpty().WithMessage("RoleId cannot be empty");
        }
    }
}
