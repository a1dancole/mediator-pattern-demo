using AutoMapper;
using Demo.Core.Domain.Dto.Application;
using Demo.Core.Domain.Models;
using Demo.Modules.ApplicationModule.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.Modules.ApplicationModule.Handlers
{
    public class CreateApplicationHandler : IRequestHandler<CreateApplicationCommand, ApplicationDto>
    {
        private readonly IApplicationRepository _repository;
        private readonly IMapper _mapper;

        public CreateApplicationHandler(IApplicationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ApplicationDto> Handle(CreateApplicationCommand command, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<Application>(command.ApplicationCreateDto);
            var response = await _repository.Create(model);
            return _mapper.Map<ApplicationDto>(response);
        }
    }
}
