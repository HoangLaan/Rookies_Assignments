using EFCoreAssignment02.Infrastructure.ModelDto;
using EFCoreAssignment02.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreAssignment02.Infrastructure.Interfaces
{
    public interface IDepartmentService
    {
        Task<List<Departments>> GetAll();
        Task<Departments?> GetById(Guid id);
        Task<Departments> AddDepartment(DepartmentsRequest department);
        Task DeleteDepartment(Guid id);
        Task<Departments> UpdateDepartment(Guid id,DepartmentsRequest department);
        Task<bool> IsExist(Guid id);
    }
}
