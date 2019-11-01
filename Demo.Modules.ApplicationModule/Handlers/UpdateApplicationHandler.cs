using AutoMapper;
using Demo.Core.Domain.Dto.Application;
using Demo.Core.Domain.Models;
using Demo.Modules.ApplicationModule.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.Modules.ApplicationModule.Handlers
{
    public class UpdateApplicationHandler : IRequestHandler<UpdateApplicationCommand, ApplicationDto>
    {
        private readonly IApplicationRepository _repository;
        private readonly IMapper _mapper;
        public UpdateApplicationHandler(IApplicationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ApplicationDto> Handle(UpdateApplicationCommand command, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<Application>(command.ApplicationUpdateDto);
            var response = await _repository.Update(model);
            return _mapper.Map<ApplicationDto>(response);
        }
    }
}
