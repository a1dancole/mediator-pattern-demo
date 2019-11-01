using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Core.Infrastructure
{
    public class ValidationExceptionProblemDetails : ProblemDetails
    {
        public ValidationExceptionProblemDetails(ValidationException exception)
        {
            this.Title = exception.Message;
            this.Status = StatusCodes.Status406NotAcceptable;
            this.Detail = exception.Errors.GetEnumerator()?.Current?.ErrorMessage;
            this.Type = exception.HelpLink;
        }
    }
}
