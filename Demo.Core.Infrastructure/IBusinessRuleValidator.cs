using System.Threading.Tasks;

namespace Demo.Core.Infrastructure
{
    public interface IBusinessRuleValidator<in TRequest>
    {
        Task<IBusinessRule> Validate(TRequest request);
    }
}