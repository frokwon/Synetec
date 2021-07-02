using Microsoft.EntityFrameworkCore;
using System;

namespace SynetecAssessmentApi.Persistence.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        AppDbContext dbContext;
        DbContextOptions<AppDbContext> options;
        public AppDbContext Init()
        {
            return dbContext ?? (dbContext = new AppDbContext(options));
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
