using EFCoreAssignment02.Infrastructure.ModelDto;
using EFCoreAssignment02.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreAssignment02.Infrastructure.Interfaces
{
    public interface IProjectService
    {
        Task<List<Projects>> GetAll();
        Task<Projects?> GetById(Guid id);
        Task<Projects> AddProject(ProjectRequest project);
        Task DeleteProject(Guid id);
        Task<Projects> UpdateProject(Guid id, ProjectRequest project);
        Task<bool> IsExist(Guid id);
    }
}
