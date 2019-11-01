using Demo.Core.Domain.Dto.Application;
using MediatR;
using System.Collections.Generic;

namespace Demo.Modules.ApplicationModule.Queries
{
    public class GetApplicationsQuery : IRequest<IEnumerable<ApplicationDto>>
    {
        public GetApplicationsQuery(SearchApplicationDto query)
        {
            ApplicationSearchDto = query;
        }

        public SearchApplicationDto ApplicationSearchDto { get; }
    }
}
