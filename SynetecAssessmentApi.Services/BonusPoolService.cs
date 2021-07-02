using SynetecAssessmentApi.Persistence.Dtos;
using SynetecAssessmentApi.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.Services
{
    public interface IBonusPoolService
    {
        Task<BonusPoolCalculatorResultDto> CalculateAsync(int bonusPoolAmount, int selectedEmployeeId);
        Task<IEnumerable<EmployeeDto>> GetEmployeesAsync();
    }

    public class BonusPoolService : IBonusPoolService
    {
        private readonly IEmployeeRepository EmployeeRepository;
        private readonly IDepartmentRepository DepartmentRepository;
        private readonly IBonusCalculator BonusCalculator;

        public BonusPoolService(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository, IBonusCalculator bonusCalculator)
        {
            EmployeeRepository = employeeRepository;
            DepartmentRepository = departmentRepository;
            BonusCalculator = bonusCalculator;
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync()
        {
            var employees = await EmployeeRepository.GetEmployeesAsync();

            List<EmployeeDto> result = new List<EmployeeDto>();

            foreach (var employee in employees)
            {
                result.Add(
                    new EmployeeDto
                    {
                        Fullname = employee.Fullname,
                        JobTitle = employee.JobTitle,
                        Salary = employee.Salary,
                        Department = new DepartmentDto
                        {
                            Title = employee.Department.Title,
                            Description = employee.Department.Description
                        }
                    });
            }

            return result;
        }

        public async Task<BonusPoolCalculatorResultDto> CalculateAsync(int bonusPoolAmount, int selectedEmployeeId)
        {
            var allEmployees = await EmployeeRepository.GetEmployeesAsync();

            var employee = allEmployees.FirstOrDefault(item => item.Id == selectedEmployeeId);

            if (employee == null)
                throw new ArgumentException("Invalid employee id passed : " + selectedEmployeeId);

            //get the total salary budget for the company
            int totalSalary = allEmployees.Sum(item => item.Salary);

            return new BonusPoolCalculatorResultDto
            {
                Employee = new EmployeeDto
                {
                    Fullname = employee.Fullname,
                    JobTitle = employee.JobTitle,
                    Salary = employee.Salary,
                    Department = new DepartmentDto
                    {
                        Title = employee.Department.Title,
                        Description = employee.Department.Description
                    }
                },

                Amount = BonusCalculator.CalculateBonus(employee.Salary, totalSalary, bonusPoolAmount)
            };
        }
    }
}
