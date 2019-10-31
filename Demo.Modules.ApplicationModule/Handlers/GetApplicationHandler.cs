using AutoMapper;
using Demo.Core.Domain.Dto.Application;
using Demo.Modules.ApplicationModule.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.Modules.ApplicationModule.Handlers
{
    public class GetApplicationHandler : IRequestHandler<GetApplicationQuery, ApplicationDto>
    {
        private readonly IApplicationRepository _repository;
        private readonly IMapper _mapper;
        public GetApplicationHandler(IApplicationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ApplicationDto> Handle(GetApplicationQuery command, CancellationToken cancellationToken)
        {
            var response = await _repository.Get(command.Id);
            return _mapper.Map<ApplicationDto>(response);
        }
    }
}
