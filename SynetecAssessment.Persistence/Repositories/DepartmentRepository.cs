using SynetecAssessmentApi.Domain;
using SynetecAssessmentApi.Persistence.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace SynetecAssessmentApi.Persistence.Repositories
{
    public interface IDepartmentRepository : IRepository<Department>
    {

    }

    public class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
    {
        public DepartmentRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}
