using System;

namespace SynetecAssessmentApi.Persistence.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        AppDbContext Init();
    }
}
