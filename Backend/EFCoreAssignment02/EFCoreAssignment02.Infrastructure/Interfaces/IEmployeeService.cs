using EFCoreAssignment02.Infrastructure.ModelDto;
using EFCoreAssignment02.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreAssignment02.Infrastructure.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<Employees>> GetAll();
        Task<Employees?> GetById(Guid id);
        Task<Employees> AddEmployee(EmployeeRequest employee);
        Task DeleteEmployee(Guid id);
        Task<Employees> UpdateEmployee(Guid id, EmployeeRequest employee);
        Task<bool> IsExist(Guid id);
        Task<List<string>> GetAllWithDepartment();
        Task<List<string>> GetAllWithProject();
        Task<List<string>> GetWithSalaryAndJoinDated();
    }
}
