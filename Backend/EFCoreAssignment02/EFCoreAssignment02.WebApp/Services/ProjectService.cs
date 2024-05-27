using AutoMapper;
using EFCoreAssignment02.Infrastructure.Interfaces;
using EFCoreAssignment02.Infrastructure.ModelDto;
using EFCoreAssignment02.WebApp.Interfaces;
using EFCoreAssignment02.WebApp.Models;

namespace EFCoreAssignment02.WebApp.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IGenericRepository<Projects> _repository;
        private readonly IMapper _mapper;

        public ProjectService(IGenericRepository<Projects> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<Projects>> GetAll()
        {
            return await _repository.GetAll();
        }
        public async Task<Projects?> GetById(Guid id)
        {
            return await _repository.GetById(id);
        }
        public async Task<Projects> AddProject(ProjectRequest project)
        {
            return await _repository.AddEntity(_mapper.Map<Projects>(project));
        }
        public async Task DeleteProject(Guid id)
        {
            var deleteProject = await GetById(id);
            await _repository.DeleteEntity(deleteProject);
        }
        public async Task<Projects> UpdateProject(Guid id, ProjectRequest project)
        {
            var updatedProject = await GetById(id);
            updatedProject.Name = project.ProjectName;
            var update = await _repository.UpdateEntity(updatedProject);
            return update;
        }
        public async Task<bool> IsExist(Guid id)
        {
            return await _repository.IsExist(id);
        }
    }
}
