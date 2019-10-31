﻿using Demo.Core.Domain.Dto.Application;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Modules.ApplicationModule.Queries
{
    public class GetApplicationQuery : IRequest<ApplicationDto>
    {
        public GetApplicationQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
