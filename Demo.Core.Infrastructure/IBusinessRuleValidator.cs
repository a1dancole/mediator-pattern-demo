using System.Threading.Tasks;

namespace Demo.Core.Infrastructure
{
    public interface IBusinessRuleValidator<in TRequest>
    {
        Task Validate(TRequest request);
    }
}