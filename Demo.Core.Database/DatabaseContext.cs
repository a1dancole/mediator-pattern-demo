using Demo.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Core.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Application>().Property(o => o.ApplicationId).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Role>().Property(o => o.RoleId).HasDefaultValueSql("NEWID()");
        }
    }
}
