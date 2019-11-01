using Demo.Core.Domain.Dto.Application;
using MediatR;

namespace Demo.Modules.ApplicationModule.Commands
{
    public class UpdateApplicationCommand : IRequest<ApplicationDto>
    {
        public UpdateApplicationCommand(UpdateApplicationDto application)
        {
            ApplicationUpdateDto = application;
        }

        public UpdateApplicationDto ApplicationUpdateDto { get; }
    }
}
