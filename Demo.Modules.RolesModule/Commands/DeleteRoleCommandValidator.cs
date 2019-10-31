using FluentValidation;

namespace Demo.Modules.RolesModule.Commands
{
    public class DeleteRoleCommandValidator : AbstractValidator<DeleteRoleCommand>
    {
        public DeleteRoleCommandValidator()
        {
            RuleFor(x => x.DeleteRoleDto.ApplicationId).NotEmpty().WithMessage("ApplicationId cannot be empty");
            RuleFor(x => x.DeleteRoleDto.RoleId).NotEmpty().WithMessage("RoleId cannot be empty");
        }
    }
}
