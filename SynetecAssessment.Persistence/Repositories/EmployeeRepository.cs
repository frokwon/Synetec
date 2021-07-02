using SynetecAssessmentApi.Domain;
using SynetecAssessmentApi.Persistence.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace SynetecAssessmentApi.Persistence.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {

    }

    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}
