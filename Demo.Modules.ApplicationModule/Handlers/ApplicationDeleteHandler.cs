using AutoMapper;
using Demo.Core.Domain.Models;
using Demo.Modules.ApplicationModule.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.Modules.ApplicationModule.Handlers
{
    public class ApplicationDeleteHandler : IRequestHandler<DeleteApplicationCommand, bool>
    {
        private readonly IApplicationRepository _repository;
        private readonly IMapper _mapper;

        public ApplicationDeleteHandler(IApplicationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteApplicationCommand command, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<Application>(command.ApplicationDeleteDto);
            return await _repository.Delete(model);
        }
    }
}
