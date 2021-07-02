using Microsoft.EntityFrameworkCore;
using System;

namespace SynetecAssessmentApi.Persistence.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        AppDbContext dbContext;
        DbContextOptions<AppDbContext> Options;

        public DbFactory(DbContextOptions<AppDbContext> options)
        {
            Options = options;
        }
        public AppDbContext Init()
        {
            return dbContext ?? (dbContext = new AppDbContext(Options));
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
