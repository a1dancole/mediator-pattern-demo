using Demo.Core.Domain.Dto.Application;
using MediatR;

namespace Demo.Modules.ApplicationModule.Commands
{
    public class DeleteApplicationCommand : IRequest<bool>
    {
        public DeleteApplicationCommand(DeleteApplicationDto deleteDto)
        {
            ApplicationDeleteDto = deleteDto;
        }

        public DeleteApplicationDto ApplicationDeleteDto { get; }
    }
}
