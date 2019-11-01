using Demo.Core.Domain.Dto.Application;
using MediatR;

namespace Demo.Modules.ApplicationModule.Commands
{
    public class CreateApplicationCommand : IRequest<ApplicationDto>
    {
        public CreateApplicationCommand(CreateApplicationDto application)
        {
            ApplicationCreateDto = application;
        }

        public CreateApplicationDto ApplicationCreateDto { get; }
    }
}
