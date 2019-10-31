using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Demo.Core.Domain.Models;

namespace Demo.Modules.RolesModule.Repository
{
    public interface IRolesRepository
    {
        Task<Role> Create(Role role);
        Task<Role> Update(Role role);
        Task<Role> Get(Guid guid);
        Task<IQueryable<Role>> Find(Expression<Func<Role, bool>> expr);
        Task<bool> Delete(Role role);
    }
}