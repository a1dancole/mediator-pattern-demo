using Demo.Core.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Demo.StartupExtensions
{
    internal static class DatabaseStartupExtensions
    {
        internal static void InitializeDatabase(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            var database = scope.ServiceProvider.GetRequiredService<DatabaseContext>().Database;

            if (database.GetPendingMigrations().Any())
            {
                database.Migrate();
            }
        }
    }
}
