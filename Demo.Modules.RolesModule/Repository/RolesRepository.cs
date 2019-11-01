using Demo.Core.Database;
using Demo.Core.Domain.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Demo.Modules.RolesModule.Repository
{
    public class RolesRepository : Core.Database.Repository, IRolesRepository
    {
        public RolesRepository(DatabaseContext context) : base(context)
        {

        }

        public async Task<Role> Create(Role role)
        {
            await Context.Roles.AddAsync(role);
            await SaveChangesAsync();
            return role;
        }

        public async Task<Role> Update(Role role)
        {
            Context.Roles.Update(role);
            await SaveChangesAsync();
            return await Task.FromResult(role);
        }

        public async Task<Role> Get(Guid guid)
        {
            return await Context.Roles.FindAsync(guid);
        }

        public async Task<IQueryable<Role>> Find(Expression<Func<Role, bool>> expr)
        {
            return await Task.FromResult(Context.Roles.Where(expr));
        }

        public async Task<bool> Delete(Role role)
        {
            Context.Roles.Remove(role);
            var response = await SaveChangesAsync();
            return response > 0;
        }
    }
}
