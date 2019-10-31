using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Core.Database
{
    public abstract class Repository : IRepository
    {
        public DatabaseContext Context { get;  }
        protected Repository(DatabaseContext context)
        {
            Context = context;
        }

        public virtual int SaveChanges()
        {
            return Context.SaveChanges();
        }
        public virtual Task<int> SaveChangesAsync()
        {
            return Context.SaveChangesAsync();
        }
    }
}
