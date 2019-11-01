using AutoMapper;
using Demo.Core.Domain.Dto.Application;
using Demo.Modules.ApplicationModule.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.Modules.ApplicationModule.Handlers
{
    public class GetApplicationsHandler : IRequestHandler<GetApplicationsQuery, IEnumerable<ApplicationDto>>
    {
        private readonly IApplicationRepository _repository;
        private readonly IMapper _mapper;
        public GetApplicationsHandler(IApplicationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ApplicationDto>> Handle(GetApplicationsQuery command, CancellationToken cancellationToken)
        {
            var response =
                await _repository.Find(o => o.ApplicationName.Contains(command.ApplicationSearchDto.SearchTerm));
            return _mapper.Map<IEnumerable<ApplicationDto>>(response);
        }
    }
}
