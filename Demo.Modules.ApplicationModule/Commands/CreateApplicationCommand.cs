using Demo.Core.Domain.Dto;
using Demo.Core.Domain.Dto.Application;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

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
