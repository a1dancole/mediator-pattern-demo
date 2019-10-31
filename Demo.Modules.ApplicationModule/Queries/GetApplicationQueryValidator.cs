﻿using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Demo.Modules.ApplicationModule.Queries
{
    public class GetApplicationQueryValidator : AbstractValidator<GetApplicationQuery>
    {
        public GetApplicationQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id cannot be empty");
        }
    }
}
