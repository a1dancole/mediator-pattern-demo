using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.Core.Infrastructure
{
    public class BusinessRuleValidationHandler<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IBusinessRuleValidator<TRequest>> _businessRules;

        public BusinessRuleValidationHandler(IEnumerable<IBusinessRuleValidator<TRequest>> businessRules)
        {
            _businessRules = businessRules;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var failures = await Task.WhenAll(_businessRules.Select(async o => await o.Validate(request)));

            if (failures.Any(o => o.IsBroken()))
            {
                throw new BusinessRuleValidationException(failures.First());
            }

            return await next();
        }
    }
}
