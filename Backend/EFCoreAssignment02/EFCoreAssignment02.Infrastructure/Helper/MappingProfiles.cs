using AutoMapper;
using EFCoreAssignment02.Infrastructure.ModelDto;
using EFCoreAssignment02.WebApp.Models;

namespace EFCoreAssignment02.Infrastructure.Helper
{
    internal class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //Map Department
            CreateMap<DepartmentsRequest, Departments>()
                .ForMember(des => des.Id,
                           src => src.MapFrom(x => Guid.NewGuid()));
            CreateMap<Departments, DepartmentResponse>();

            //Map Employee
            CreateMap<EmployeeRequest, Employees>()
                .ForMember(des => des.Id,
                           src => src.MapFrom(x => Guid.NewGuid()));
            CreateMap<Employees, EmployeeResponse>()
                //Get Salary for Employee
                .ForMember(des => des.Salary,
                            src => src.MapFrom(x => x.Salary.Salary))
                //get Department name for Employee
                .ForMember(des => des.Department,
                            src => src.MapFrom(x => x.Department.Name));

            //Map Salary
            CreateMap<SalaryRequest, Salaries>()
                .ForMember(des => des.Id,
                           src => src.MapFrom(x => Guid.NewGuid()));
            CreateMap<Salaries, SalaryResponse>()
                .ForMember(des => des.EmployeeName,
                            src => src.MapFrom(x => x.Employee.Name));

            //Map Project
            CreateMap<ProjectRequest, Projects>()
                .ForMember(des => des.Id,
                           src => src.MapFrom(x => Guid.NewGuid()))
                .ForMember(des => des.Name,
                            src => src.MapFrom(x => x.ProjectName));
            CreateMap<Projects, ProjectResponse>()
                .ForMember(des => des.ProjectName,
                            src => src.MapFrom(x => x.Name));
        }
    }
}
