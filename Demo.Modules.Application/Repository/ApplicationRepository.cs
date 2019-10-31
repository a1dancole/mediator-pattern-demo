using Demo.Core.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Modules.ApplicationModule.Repository
{
    public class ApplicationRepository
    {
        private readonly DatabaseContext _context;
        public ApplicationRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task Create(Application application)
        {
            await _context.Applications.AddAsync(application);
        }
    }
}
