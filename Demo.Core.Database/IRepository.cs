using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Core.Database
{
    public interface IRepository
    {
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
