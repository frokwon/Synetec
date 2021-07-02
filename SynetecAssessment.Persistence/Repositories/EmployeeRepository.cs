using Microsoft.EntityFrameworkCore;
using SynetecAssessmentApi.Domain;
using SynetecAssessmentApi.Persistence.Dtos;
using SynetecAssessmentApi.Persistence.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.Persistence.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<List<Employee>> GetEmployeesAsync();
    }

    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IDbFactory dbFactory) : base(dbFactory) { }
        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return await DbContext
                .Employees
                .Include(e => e.Department)
                .ToListAsync();
        }
    }
}
