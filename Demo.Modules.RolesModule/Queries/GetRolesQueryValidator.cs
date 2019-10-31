using FluentValidation;

namespace Demo.Modules.RolesModule.Queries
{
    public class GetRolesQueryValidator : AbstractValidator<GetRolesQuery>
    {
        public GetRolesQueryValidator()
        {
            RuleFor(x => x.SearchRolesDto.SearchTerm).NotEmpty().WithMessage("SearchTerm cannot be empty");
        }
    }
}
