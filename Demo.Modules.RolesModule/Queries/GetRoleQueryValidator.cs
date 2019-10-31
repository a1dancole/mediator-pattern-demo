using FluentValidation;

namespace Demo.Modules.RolesModule.Queries
{
    public class GetRoleQueryValidator : AbstractValidator<GetRoleQuery>
    {
        public GetRoleQueryValidator()
        {
            RuleFor(x => x.RoleId).NotEmpty().WithMessage("RoleId cannot be empty");
        }
    }
}
