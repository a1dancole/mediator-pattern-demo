using FluentValidation;

namespace Demo.Modules.ApplicationModule.Queries
{
    public class GetApplicationsQueryValidator : AbstractValidator<GetApplicationsQuery>
    {
        public GetApplicationsQueryValidator()
        {
            RuleFor(x => x.ApplicationSearchDto.SearchTerm).NotEmpty().WithMessage("SearchTerm cannot be empty");
        }
    }
}
