using Demo.Core.Database;
using Demo.Core.Domain.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Demo.Modules.ApplicationModule
{
    public class ApplicationRepository : Repository, IApplicationRepository
    {
        public ApplicationRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<Application> Create(Application application)
        {
            await Context.Applications.AddAsync(application);
            await SaveChangesAsync();
            return await Task.FromResult(application);
        }

        public async Task<Application> Update(Application application)
        {
            Context.Applications.Update(application);
            await SaveChangesAsync();
            return await Task.FromResult(application);
        }

        public async Task<Application> Get(Guid id)
        {
            return await Context.Applications.FindAsync(id);
        }

        public Task<IQueryable<Application>> Find(Expression<Func<Application, bool>> where)
        {
            return Task.FromResult(Context.Applications.Where(where));
        }

        public async Task<bool> Delete(Application application)
        {
            Context.Applications.Remove(application);
            var response = await SaveChangesAsync();
            return response > 0;
        }
    }
}
