using Demo.Core.Domain.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Demo.Modules.ApplicationModule
{
    public interface IApplicationRepository
    {
        Task<Application> Create(Application application);

        Task<Application> Update(Application application);

        Task<Application> Get(Guid id);

        Task<IQueryable<Application>> Find(Expression<Func<Application, bool>> where);

        Task<bool> Delete(Application application);
    }
}
