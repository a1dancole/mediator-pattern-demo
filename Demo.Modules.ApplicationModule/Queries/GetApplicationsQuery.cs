using Demo.Core.Domain.Dto.Application;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

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
