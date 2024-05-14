using AutoMapper;
using EFCoreAssignment02.Infrastructure.Interfaces;
using EFCoreAssignment02.Infrastructure.ModelDto;
using EFCoreAssignment02.WebApp.Interfaces;
using EFCoreAssignment02.WebApp.Models;

namespace EFCoreAssignment02.WebApp.Services
{
    public class SalaryService : ISalaryService
    {
        private readonly IGenericRepository<Salaries> _repository;
        private readonly IMapper _mapper;

        public SalaryService(IGenericRepository<Salaries> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<Salaries>> GetAll()
        {
            return await _repository.GetAll();
        }
        public async Task<Salaries?> GetById(Guid id)
        {
            return await _repository.GetById(id);
        }
        public async Task<Salaries> AddSalary(SalaryRequest salary)
        {
            return await _repository.AddEntity(_mapper.Map<Salaries>(salary));
        }
        public async Task DeleteSalary(Guid id)
        {
            var deleteSalary = await GetById(id);
            await _repository.DeleteEntity(deleteSalary);
        }
        public async Task<Salaries> UpdateSalary(Guid id, SalaryRequest salary)
        {
            var updatedSalary = await GetById(id);
            updatedSalary.Salary = salary.Salary;
            var update = await _repository.UpdateEntity(updatedSalary);
            return update;
        }
        public async Task<bool> IsExist(Guid id)
        {
            return await _repository.IsExist(id);
        }
    }
}
