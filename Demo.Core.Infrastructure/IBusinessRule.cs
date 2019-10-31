namespace Demo.Core.Infrastructure
{
    public interface IBusinessRule
    {
        bool IsBroken();

        string Message { get; }
    }
}