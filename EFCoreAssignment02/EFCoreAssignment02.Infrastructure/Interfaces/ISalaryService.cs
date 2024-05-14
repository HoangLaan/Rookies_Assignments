using EFCoreAssignment02.Infrastructure.ModelDto;
using EFCoreAssignment02.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreAssignment02.Infrastructure.Interfaces
{
    public interface ISalaryService
    {
        Task<List<Salaries>> GetAll();
        Task<Salaries?> GetById(Guid id);
        Task<Salaries> AddSalary(SalaryRequest salary);
        Task DeleteSalary(Guid id);
        Task<Salaries> UpdateSalary(Guid id, SalaryRequest salary);
        Task<bool> IsExist(Guid id);
    }
}
