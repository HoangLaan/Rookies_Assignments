using AutoMapper;
using EFCoreAssignment02.Infrastructure.Interfaces;
using EFCoreAssignment02.Infrastructure.ModelDto;
using EFCoreAssignment02.WebApp.Database;
using EFCoreAssignment02.WebApp.Interfaces;
using EFCoreAssignment02.WebApp.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;

namespace EFCoreAssignment02.WebApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IGenericRepository<Employees> _employeeRepository;
        private readonly IGenericRepository<Departments> _departmentRepository;
        private readonly IGenericRepository<Projects> _projectRepository;
        private readonly IGenericRepository<Salaries> _salaryRepository;
        private readonly IGenericRepository<Project_Employee> _projectEmployeeRepository;
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public EmployeeService(IGenericRepository<Employees> employeeRepository, 
                               IGenericRepository<Departments> departmentRepository,
                               IGenericRepository<Projects> projectRepository,
                               IGenericRepository<Salaries> salaryRepository,
                               IGenericRepository<Project_Employee> projectEmployeeRepository,
                               DataContext dataContext,
                               IMapper mapper)                     
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
            _projectRepository = projectRepository;
            _salaryRepository = salaryRepository;
            _mapper = mapper;
            _dataContext = dataContext;
            _projectEmployeeRepository = projectEmployeeRepository;
        }

        public async Task<Employees> AddEmployee(EmployeeRequest employeeRequest)
        {
            var employee = _mapper.Map<Employees>(employeeRequest);
            //employee.Department = await _departmentRepository.GetById(departmentId);

            //var projectEmployee = new Project_Employee()
            //{
            //    Employee = employee,
            //    Project = project
            //};
            //await _projectEmployeeRepository.AddEntity(projectEmployee);

            return await _employeeRepository.AddEntity(employee);
        }


        public async Task DeleteEmployee(Guid id)
        {
            var deleteDepartment = await GetById(id);
            await _employeeRepository.DeleteEntity(deleteDepartment);
        }

        public async Task<List<Employees>> GetAll()
        {
            return await _employeeRepository.GetAll();
        }

        public async Task<List<string>> GetAllWithDepartment()
        {
            List<string> employeeDepartmentList = await (from e in _dataContext.Employees
                                                   join d in _dataContext.Departments on e.DepartmentId equals d.Id
                                                   select $"{e.Name} - {d.Name}").ToListAsync();
            return employeeDepartmentList;

        }

        public async Task<List<string>> GetAllWithProject()
        {
            List<string> employeeProjectList = await (from e in _dataContext.Employees
                                                join pe in _dataContext.ProjectEmployee on e.Id equals pe.EmployeeId into epGroup
                                                from ep in epGroup.DefaultIfEmpty()
                                                join p in _dataContext.Projects on ep.ProjectId equals p.Id into pjGroup
                                                from pj in pjGroup.DefaultIfEmpty()
                                                select $"{e.Name} - {(pj != null ? pj.Name : "No Project")}").ToListAsync();

            return employeeProjectList;
        }

        public async Task<Employees?> GetById(Guid id)
        {
            return await _employeeRepository.GetById(id);
        }

        public async Task<List<string>> GetWithSalaryAndJoinDated()
        {
            List<string> employeeNames = await (from e in _dataContext.Employees
                                          join s in _dataContext.Salaries on e.Id equals s.EmployeeId
                                          where s.Salary > 100 && e.JoinedDated >= new DateTime(2024, 1, 1)
                                          select e.Name).ToListAsync();
            return employeeNames;
        }

        public async Task<bool> IsExist(Guid id)
        {
            return await _employeeRepository.IsExist(id);
        }

        public async Task<Employees> UpdateEmployee(Guid id, EmployeeRequest department)
        {
            var updatedEmployee = await GetById(id);
            updatedEmployee.Name = department.Name;
            var update = await _employeeRepository.UpdateEntity(updatedEmployee);
            return update;
        }
    }
}
