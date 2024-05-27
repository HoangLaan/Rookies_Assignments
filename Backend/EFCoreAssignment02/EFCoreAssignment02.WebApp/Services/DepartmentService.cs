using AutoMapper;
using EFCoreAssignment02.Infrastructure.Interfaces;
using EFCoreAssignment02.Infrastructure.ModelDto;
using EFCoreAssignment02.WebApp.Interfaces;
using EFCoreAssignment02.WebApp.Models;
using System.Collections.ObjectModel;

namespace EFCoreAssignment02.WebApp.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IGenericRepository<Departments> _repository;
        private readonly IMapper _mapper;

        public DepartmentService(IGenericRepository<Departments> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<Departments>> GetAll()
        {
            return await _repository.GetAll();
        }
        public async Task<Departments?> GetById(Guid id)
        {
            return await _repository.GetById(id);
        } 
        public async Task<Departments> AddDepartment(DepartmentsRequest department)
        {
            return await _repository.AddEntity(_mapper.Map<Departments>(department));
        }
        public async Task DeleteDepartment(Guid id)
        {
            var deleteDepartment = await GetById(id);
            await _repository.DeleteEntity(deleteDepartment);
        }
        public async Task<Departments> UpdateDepartment(Guid id, DepartmentsRequest department)
        {
            var updatedDepartment = await GetById(id);
            updatedDepartment.Name = department.Name;
            var update = await _repository.UpdateEntity(updatedDepartment);
            return update;
        }
        public async Task<bool> IsExist(Guid id)
        {
            return await _repository.IsExist(id);
        }
    }
}
