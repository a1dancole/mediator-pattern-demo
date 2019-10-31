using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Demo.Core.Infrastructure
{
    public class BusinessRuleValidationHandler<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IBusinessRuleValidator<TRequest> _validationHandler;

        public BusinessRuleValidationHandler(IBusinessRuleValidator<TRequest> validationHandler)
        {
            _validationHandler = validationHandler;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            await _validationHandler.Validate(request);
            return await next();
        }
    }
}
